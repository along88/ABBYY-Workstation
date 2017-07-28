using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using OfficeOpenXml;
using System.Windows.Forms;
using WindowsFormsApplication1.LocationView;

namespace WindowsFormsApplication1
{
    public partial class SharperWorkstation : Form, IView
    {
        private string[] headers =
        {
            "Loc #", "Bldg #", "Physical Building #", "Single Physical Building #",
            "Street 1", "Street 2", "City", "State", "Zip", "County", "Building Value",
            "Business Personal Property", "Busines Income", "Misc Real Property",
            "TIV", "# Units", "Building Description", "WKFC Major Occupancy", "WKFC Detailed Occupancy", "LRO",
            "ClassCodeDesc", "Building Usage", "Construction Type", "Dist. To Fire Hydrant (Feet)",
            "Dist. To Fire Station (Miles)", "Prot Class", "# Stories", "# Basements",
            "Year Built", "Sq Ftg", "Wiring Year", "Plumbing Year", "Roofing Year",
            "Heating Year", "Burglar Alarm Type", "Fire Alarm Type", "Sprinkler Alarm Type",
            "Sprinkler Wet/Dry", "Sprinkler Extent"
        };
        private readonly string filepath = $@"{Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)}";
        private readonly string today = DateTime.Now.ToString("MM-dd-yyyy");

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
            get { return (DataTable)dgViewSOV.DataSource; }
            set { dgViewSOV.DataSource = value; }
        }

        public Panel EditPanel
        {
            get;
            set;
        }

        public event EventHandler<EventArgs> OnStateChanged;

        private void TxtControlNo_TextChanged(object sender, EventArgs e)
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
            WorkstationRow currentRow;
            foreach (DataGridViewRow row in dgViewSOV.Rows)
            {
                currentRow = new WorkstationRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    string currentCell = cell.Value.ToString();
                    currentRow.Add(currentCell);
                }
                allRows.Add(currentRow);
            }
            FileInfo excelFile = new FileInfo(filepath + $"Control Number - {ControlNo} ({today}).xlsx");
            if (excelFile.Exists)
            {
                excelFile.Delete();
                excelFile = new FileInfo(filepath + $"Control Number - {ControlNo} ({today}).xlsx");
            }
            using (ExcelPackage pkg = new ExcelPackage())
            {
                pkg.Workbook.Worksheets.Add("ABBYY Results");
                ExcelWorksheet sheet = pkg.Workbook.Worksheets[1];
                sheet.Name = "ABBYY Results";

                for (int i = 0; i < headers.Length; i++)
                {
                    sheet.Cells[1, i + 1].Value = headers[i];
                }

                int excelRowStart = 2;
                foreach (var row in allRows)
                {
                    for (int rowIndex = 0; rowIndex < row.Length(); rowIndex++)
                    {
                        sheet.Cells[excelRowStart, rowIndex + 1].Value = row.DataAtIndex(rowIndex);
                    }
                    excelRowStart++;
                }
                string excelBookName = $"Control Number - {ControlNo} ({today}).xlsx";
                Byte[] sheetAsBinary = pkg.GetAsByteArray();
                File.WriteAllBytes(Path.Combine(filepath, excelBookName), sheetAsBinary);
            }


            //Export();

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
}
