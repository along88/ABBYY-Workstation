using SharperWorkstation.WorkstationView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharperWorkstation.WorkstationModels;

namespace SharperWorkstation.WorkstationPresenter
{
    class EditPresenter
    {
        private readonly IEditModel editModel;
        private readonly IEditView editView;

        public EditPresenter(IEditModel model, IEditView view)
        {
            this.editModel = model;
            this.editView = view;
        }
        private void EventListeners()
        {
            editView.onStateChanged += UpdateCells;
        }


        private void UpdateCells(object sender, EventArgs e)
        {
            

            if(editModel.selectedCells != null)
            {
                editModel.selectedCells = editView.selectedCells;
            }
        }
    }
}
