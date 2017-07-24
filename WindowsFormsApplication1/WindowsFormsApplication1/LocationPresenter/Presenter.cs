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
    }
}
