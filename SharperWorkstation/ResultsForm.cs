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
using SharperWorkstation.WorkstationView;


namespace SharperWorkstation
{
    public partial class ResultsForm : CustomForm
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
     
        public ResultsForm(object grid)
        {
            InitializeComponent();
            this.Grid = grid;
            controlNumberLabel.Text += this.ControlNo.ToString();
        }


        public string ControlNo
        {
            get { return ControlNum; }

            set { ControlNum = value; }
        }

        public object Grid
        {
            get;
            set;
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
                    if (dgViewSOV.Columns[cell.ColumnIndex].HeaderText == "Raw Street Address" || dgViewSOV.Columns[cell.ColumnIndex].HeaderText == ("Construction Type Raw"))
                    {
                        continue;
                    }
                    if (cell.Value != null)
                    {
                        string currentCell = cell.Value.ToString();
                        currentRow.Add(currentCell);
                    }
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
            MessageBox.Show("Success! Submission exported to Desktop!");
        }
    }
}
