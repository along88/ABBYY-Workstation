using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.LocationModels;
using WindowsFormsApplication1.LocationView;
using System.Windows.Forms;
using OfficeOpenXml;
using System.IO;
using System.Data;

namespace WindowsFormsApplication1.LocationPresenter
{
    public class Presenter
    {
        // Class variables for the model and view interfaces - JM
        private readonly IModel model;
        private readonly IView view;


        // Ctor - JM
        public Presenter(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
            EventListeners();
        }
        
        // Event listener ctor - JM
        private void EventListeners()
        {
            view.OnStateChanged += UpdateGrid;
        }

        /// <summary>
        /// Based on input from the user, populates the DataGridView with the corresponding information from the ABBYY DB
        /// </summary>
        private void UpdateGrid(object sender, EventArgs e)
        {
            // Set the control number that the user input from the view as the control number for the model - JM
            model.ControlNo = view.ControlNo;

            // If the string provided is not empty - JM
            if (!string.IsNullOrWhiteSpace(model.ControlNo))
            {
                // If the connection to the database was successful - JM
                if (model.Connect())
                {
                    // Set the view DataGridView equal to the model DataGridView - JM
                    model.Grid = view.Grid;
                    // Have the model return the data from the database using the stored procedure - JM
                    view.Grid = model.ReturnData($"exec Get140Data {model.ControlNo.ToString()}");
                }
                else
                {
                    MessageBox.Show(model.ErrorMessage);
                }
            }
        }

        //public void ExportToExcel(DataGridView table)
        //{
        //    List<WorkstationRow> allRows = new List<WorkstationRow>();
        //    WorkstationRow currentRow;
        //    foreach (DataGridViewRow row in table.Rows)
        //    {
        //        currentRow = new WorkstationRow();
        //        foreach (DataGridViewCell cell in row.Cells)
        //        {
        //            string currentCell = cell.Value.ToString();
        //            currentRow.Add(currentCell);
        //        }
        //        allRows.Add(currentRow);
        //    }
        //    FileInfo excelFile = new FileInfo(filepath + $"Control Number - {view.ControlNo} ({today}).xlsx");
        //    if (excelFile.Exists)
        //    {
        //        excelFile.Delete();
        //        excelFile = new FileInfo(filepath + $"Control Number - {view.ControlNo} ({today}).xlsx");
        //    }
        //    using (ExcelPackage pkg = new ExcelPackage())
        //    {
        //        pkg.Workbook.Worksheets.Add("ABBYY Results");
        //        ExcelWorksheet sheet = pkg.Workbook.Worksheets[1];
        //        sheet.Name = "ABBYY Results";

        //        for (int i = 0; i < headers.Length; i++)
        //        {
        //            sheet.Cells[1, i + 1].Value = headers[i];
        //        }

        //        int excelRowStart = 2;
        //        foreach (var row in allRows)
        //        {
        //            for (int rowIndex = 0; rowIndex < row.Length(); rowIndex++)
        //            {
        //                sheet.Cells[excelRowStart, rowIndex + 1].Value = row.DataAtIndex(rowIndex);
        //            }
        //            excelRowStart++;
        //        }
        //        string excelBookName = $"Control Number - {view.ControlNo} ({today}).xlsx";
        //        Byte[] sheetAsBinary = pkg.GetAsByteArray();
        //        File.WriteAllBytes(Path.Combine(filepath, excelBookName), sheetAsBinary);
        //    }
        //}










    }
}
