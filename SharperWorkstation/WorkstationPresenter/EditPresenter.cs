using SharperWorkstation.WorkstationView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharperWorkstation.WorkstationModels;
using System.Windows.Forms;

namespace SharperWorkstation.WorkstationPresenter
{
    class EditPresenter
    {
        private readonly IEditModel editModel;
        private readonly IEditView editView;

        public EditPresenter()
        {
            editModel = new EditModel();
            editView = new EditForm();
            PopulateGrid();
            editView.onExport += onExport;



        }

       private  void PopulateGrid()
        {
            editModel.ControlNo = editView.ControlNo;
            if (!string.IsNullOrWhiteSpace(editModel.ControlNo))
            {
                if (editModel.Connect())
                {
                    editModel.Grid = editView.Grid;
                    editView.Grid = editModel.LoadGrid(string.Format("exec Get140EditData {0} ", editModel.ControlNo.ToString()));
                }
                else
                {
                    MessageBox.Show(editModel.ErrorMessage);
                }


            }


        }

        private void onExport(object sender, EventArgs e)
        {
            editModel.Grid = editView.Grid;
            editView.Grid = editModel.ExportGrid();
        }
        
        

        


    }
}
