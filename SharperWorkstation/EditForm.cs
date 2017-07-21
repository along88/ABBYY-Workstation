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
            InitializeComponent();
            activeForms.Add(this);
            dgViewSOV.AllowDrop = true;
            dgViewSOV.KeyUp += PasteIntoSelectedCell;
            dgViewSOV.CellMouseDown += ValueClickedHold;
            dgViewSOV.CellMouseUp += ValueDropped;
            


        }

        private void ValueDropped(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgViewSOV.SelectedCells != null)
            {
                foreach (DataGridViewCell item in dgViewSOV.SelectedCells)
                {
                    if (item.ColumnIndex == columRestricted)
                        item.Value = grabbedValue;
                    else
                        MessageBox.Show("Can only slide up or down!");
                }
            }
            dgViewSOV.ClearSelection();
        }

        public object grid
        {
            get
            {
                return dgViewSOV.DataSource;
            }
        }
       
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

            //need to give datagrid view control back to the search form
            //MessageBox.Show(dgViewSOV.AllowDrop.ToString());

            if (dgViewSOV.SelectedCells != null)
            {
                foreach (DataGridViewCell item in dgViewSOV.SelectedCells)
                {
                    item.Value = debugClipBoardValue;
                }
            }

            //activeForms.Remove(this);
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
            if(e.Clicks < 2 && dgViewSOV.SelectedCells.Count < 2)
            {
                dgViewSOV.CurrentCell = dgViewSOV.Rows[r].Cells[c];
                grabbedValue = dgViewSOV.CurrentCell.Value.ToString();
                columRestricted = c;

            }
            
        }

      
      
    }
}
