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

namespace SharperWorkstation
{
    public partial class EditForm : CustomForm, IEditView
    {
        private string debugClipBoardValue = "788 Bloomfield Avenue";
        public EditForm()
        {
            DataGridViewComboBoxCell cbc = new DataGridViewComboBoxCell();
            cbc.Items.AddRange("1.Frame", "2.Joisted Masonry", "3.Fire Resistive");

           
            
            
            InitializeComponent();

            
            foreach (DataGridViewColumn column in dgViewSOV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                if (column.Index == 18)
                {
                    cbc.Value = column;
                    dgViewSOV.Columns.RemoveAt(column.Index);
                    
                    
                }
            }
            
            

            activeForms.Add(this);
            dgViewSOV.MouseUp += RightClick;
            dgViewSOV.KeyUp += PasteIntoSelectedCell;
            dgViewSOV.CellMouseDown += ValueClickedHold;
            dgViewSOV.CellMouseUp += ValueDropped;
            dgViewSOV.ColumnHeaderMouseClick += DgViewSOV_ColumnHeaderMouseClick;
        }
       
     
        private void DgViewSOV_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (dgViewSOV.Columns[e.ColumnIndex].Frozen)
            {
                for (int i = 0; i < (e.ColumnIndex); i++)
                {
                    dgViewSOV.Columns[i].Frozen = false;
                }
            }
            else
                dgViewSOV.Columns[e.ColumnIndex].Frozen = true;
        }

        private void RightClick(object sender, MouseEventArgs e)
        {
           if(e.Button == MouseButtons.Right)
            {
                ContextMenuStrip editMenu = new ContextMenuStrip();
                editMenu.Items.Add("Select All").Name ="SelectAll";
                editMenu.Items.Add("Copy").Name = "Copy";
                editMenu.Items.Add("Paste").Name = "Paste";
                editMenu.Show(dgViewSOV,e.X,e.Y);
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
        int value;

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
            else if(!string.IsNullOrWhiteSpace(grabbedValue))
            {
                for (int i = (dgViewSOV.SelectedCells.Count - 1); i >= 0; i--)
                {
                    if (dgViewSOV.SelectedCells[i].ColumnIndex == columRestricted)
                    dgViewSOV.SelectedCells[i].Value = grabbedValue;
                }
            }
           
        }

        //public object grid
        //{
        //    get
        //    {
        //        return dgViewSOV.DataSource;
        //    }
        //}
       
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
        }

        public event EventHandler<EventArgs> onStateChanged;

        private void backBtn_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World!");
        }

       
        private void PasteIntoSelectedCell(object sender, KeyEventArgs e)
        {
            if((e.Shift && e.KeyCode == Keys.Insert) || (e.Control && e.KeyCode == Keys.V))
            {
                IDataObject dataInClipboard = Clipboard.GetDataObject();
                string stringInClipBoard = (string)dataInClipboard.GetData(DataFormats.Text);
                if (dgViewSOV.SelectedCells != null)
                {
                    foreach (DataGridViewCell item in dgViewSOV.SelectedCells)
                    {
                        
                        item.Value = stringInClipBoard;
                    }
                }
            }
        }

        private string grabbedValue;
        private int columRestricted;
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
    }
}
