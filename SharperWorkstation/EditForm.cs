using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharperWorkstation.WorkstationView;
using System.IO;
using OfficeOpenXml;
using System.Data.SqlClient;

namespace SharperWorkstation
{
    public partial class EditForm : CustomForm, IEditView
    {

        /// <summary>
        /// I will refactor this editForm to have its own DatagridView.
        /// I will copy much of the same pattern as the SearchForm
        /// The datatable that the editModel will use will need to make sure that it
        /// includes logic for the dropdown combo box for the construction type, wkfc occupancies, etc
        /// I may have to undo the customForm as it no longer makes sense to have each form pass around
        /// the same grid object. SearchForm has its own grid object with its own query
        /// the EditForm will have its own grid object that pulls up essentially what the form looks like now
        /// the goal is by doing it as a seperate concern I can have more free reign of how the columns and headers are presented
        /// and behave per form.
        /// Step 1. Populate the EditForms grid object with a query tailored for this editform
        ///     1a. Get EditForm grid view to display the Construction Type Column as a comboBox
        /// Step 2. Figure out how to move my logic from this EditForm.cs to the EditPresenter.cs
        /// Step 3. 
        /// Note: Will probably have to create object representation for each column
   
        /// </summary>

        private Color defaultColor;
        private string grabbedValue;
        private int columRestricted;
        private int value;

        private object grid;
        public object Grid { get; set; }
        public IList<string> SelectedCells
        {
            get
            {
                List<string> selectedCells = new List<string>();
                if (dgViewSOV.SelectedCells != null)
                {
                    foreach (DataGridViewCell item in dgViewSOV.SelectedCells)
                    {
                        selectedCells.Add(item.Value.ToString());
                    }
                }
                return selectedCells;
            }
            set {;}
        }

        public EditForm()
        {
            defaultColor = dgViewSOV.Columns[0].DefaultCellStyle.ForeColor;
            InitializeComponent();
            for (int i = 0; i < dgViewSOV.Columns.Count; i++)
            {
                dgViewSOV.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            activeForms.Add(this);
            dgViewSOV.MouseUp += RightClick;
            dgViewSOV.KeyUp += KeyBoardShortCuts;
            dgViewSOV.CellMouseDown += ValueClickedHold;
            dgViewSOV.CellMouseUp += ValueDropped;
            dgViewSOV.ColumnHeaderMouseClick += FreezeColumnHeader;
            
        }
        private void ExportBtn_Click(object sender, EventArgs e)
        {
            //will probably want to provide a datatable for the export btn to work with
            //the editform will make a copy of its current datagridview into a data table
            //the export will consume that data table and display it into its own datagridview
            activeForms.Remove(this);
            ResultsForm exportForm = new ResultsForm();
            exportForm.Visible = true;
            activeForms.Remove(this);
        }
        /// <summary>
        /// Checks for user keyboard shortcuts and presses against a selected cell ie. ctrl+v or Delete
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void KeyBoardShortCuts(object sender, KeyEventArgs e)
        {
           if ((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
                Paste(dgViewSOV.SelectedCells);
           if ((e.KeyCode == Keys.Delete))
                Delete(dgViewSOV.SelectedCells);
        }
        private void Delete(DataGridViewSelectedCellCollection SelectedCells)
        {
            if (SelectedCells != null)
                foreach (DataGridViewCell cell in SelectedCells)
                    cell.Value = null;
        }
        private void Paste(DataGridViewSelectedCellCollection SelectedCells)
        {
            IDataObject dataInClipboard = Clipboard.GetDataObject();
            string stringInClipBoard = (string)dataInClipboard.GetData(DataFormats.Text);
            if (SelectedCells != null)
                foreach (DataGridViewCell cell in SelectedCells)
                    cell.Value = stringInClipBoard;
        }
        private void ValueClickedHold(object sender, DataGridViewCellMouseEventArgs e)
        {
            int c = e.ColumnIndex;
            int r = e.RowIndex;
            try
            {
                grabbedValue = dgViewSOV.Rows[r].Cells[c].Value.ToString();
                    columRestricted = c;

            }
            catch(Exception exception)
            {
                for (int i = 0; i < dgViewSOV.Columns.Count; i++)
                {
                    if(dgViewSOV.Columns[i].DisplayIndex == e.ColumnIndex)
                    {
                        break;
                    }
                    else if(i == dgViewSOV.Columns.Count)
                    {
                        MessageBox.Show(exception.Message);
                    }
                }
                
            }
            
        }
        private void FreezeColumnHeader(object sender, DataGridViewCellMouseEventArgs e)
        {



            if (dgViewSOV.Columns[e.ColumnIndex].Frozen)
            {
                for (int i = 0; i < (e.ColumnIndex); i++)
                {
                    dgViewSOV.Columns[e.ColumnIndex].DefaultCellStyle.BackColor = defaultColor;
                    dgViewSOV.Columns[i].Frozen = false;
                }
            }
            else
            {
                dgViewSOV.Columns[e.ColumnIndex].DefaultCellStyle.BackColor = Color.Yellow;
                dgViewSOV.Columns[e.ColumnIndex].Frozen = true;
            }
        }
        private void RightClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip editMenu = new ContextMenuStrip();
                editMenu.Items.Add("Select All").Name = "SelectAll";
                editMenu.Items.Add("Copy").Name = "Copy";
                editMenu.Items.Add("Paste").Name = "Paste";
                editMenu.Show(dgViewSOV, e.X, e.Y);
                editMenu.ItemClicked += new ToolStripItemClickedEventHandler(menuItemClicked);


            }
        }
        private void menuItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            switch (e.ClickedItem.Name)
            {
                case "SelectAll":
                    dgViewSOV.SelectAll();
                    break;
                case "Copy":
                    Clipboard.SetText(dgViewSOV.CurrentCell.Value.ToString());
                    break;
                case "Paste":
                    dgViewSOV.CurrentCell.Value = Clipboard.GetText();
                    break;

            }
            if (e.ClickedItem.Name.Equals("SelectAll"))
            {
                dgViewSOV.SelectAll();
            }

        }
        private void ValueDropped(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (int.TryParse(grabbedValue, out value))
            {

                for (int i = (dgViewSOV.SelectedCells.Count - 1); i >= 0; i--)
                {
                    if (columRestricted == 1)
                        dgViewSOV.SelectedCells[i].Value = value++;
                    else
                        dgViewSOV.SelectedCells[i].Value = value;

                }
                grabbedValue = null;
            }
            else if (!string.IsNullOrWhiteSpace(grabbedValue))
            {
                for (int i = (dgViewSOV.SelectedCells.Count - 1); i >= 0; i--)
                {
                    if (dgViewSOV.SelectedCells[i].ColumnIndex == columRestricted)
                        dgViewSOV.SelectedCells[i].Value = grabbedValue;
                }
            }

        }

        
    }
}
