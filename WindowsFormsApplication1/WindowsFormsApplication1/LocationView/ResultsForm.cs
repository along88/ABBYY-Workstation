using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.LocationView;

namespace WindowsFormsApplication1
{
    public partial class SharperWorkstation : Form, IView
    {
        public SharperWorkstation()
        {
            InitializeComponent();
        }

        public string ControlNo
        {
            get { return txtControlNo.Text; }

            set { txtControlNo.Text = value; }
        }

        public DataTable Grid
        {
            get { return (DataTable)dgViewSOV.DataSource;}
            set { dgViewSOV.DataSource = value; }
        }

        public Panel EditPanel
        {
            get;
            set;
        }

        public event EventHandler<EventArgs> OnStateChanged;

        private void txtControlNo_TextChanged(object sender , EventArgs e)
        {
            
            TextBox txtBox = sender as TextBox;
            if (!string.IsNullOrWhiteSpace(txtBox.Text))
            {
                OnStateChanged(this, e);
            }

        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            
            if (EditPanel == null)
            {
                EditPanel = new Panel();
                DataGridView editableDG = dgViewSOV;
                
                editableDG.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                editableDG.MultiSelect = true;
                editableDG.AllowUserToDeleteRows = true;
                editableDG.AllowUserToAddRows = true;
                editableDG.AllowDrop = true;

                this.Controls.Add(EditPanel);
                EditPanel.Size = this.ClientSize;
                EditPanel.Visible = true;
                EditPanel.BringToFront();

                //add dg view to editable panel here
                EditPanel.Controls.Add(editableDG);
                this.Editbtn.Text = "Back";
                EditPanel.Controls.Add(this.Editbtn);
            }
            else if (Editbtn.Text.Equals("Back"))
            {
                this.Editbtn.Text = "Edit";
                this.Controls.Remove(EditPanel);
                EditPanel = null;
                this.Controls.Add(Editbtn);
                this.Controls.Add(dgViewSOV);
                this.BringToFront();
            }
        }

        private void BtnExport_MouseClick(object sender, MouseEventArgs e)
        {
            List<WorkstationRow> allRows = new List<WorkstationRow>();

            foreach (DataGridViewRow dgRow in dgViewSOV.Rows)
            {
                foreach (DataGridViewCell dgCell in dgRow.Cells)
                {
                    allRows.Add();
                }
            }
            
        }

        // This method can iterate through all cells in a row, store them in an "object", and display them
        //private void BtnExport_MouseClick(object sender, MouseEventArgs e)
        //{
        //    List<List<string>> allRows = new List<List<string>>();
        //    List<string> currentRow;
        //    foreach (DataGridViewRow row in dgViewSOV.Rows)
        //    {
        //        currentRow = new List<string>();
        //        foreach (DataGridViewCell cell in row.Cells)
        //        {
        //            string currentCell = cell.Value.ToString();
        //            currentRow.Add(currentCell);
        //        }
        //        allRows.Add(currentRow);
        //    }

        //    foreach (var i in allRows)
        //    {
        //        string row = "";
        //        foreach (var item in i)
        //        {
        //            row += item + " ";
        //        }
        //        MessageBox.Show(row);
        //    }
        //}
    }
}
