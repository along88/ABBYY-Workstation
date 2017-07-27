using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharperWorkstation.WorkstationModels;
using System.Windows.Forms;
using SharperWorkstation.WorkstationView;

namespace SharperWorkstation.WorkstationPresenter
{
    public class SearchPresenter
    {
        private readonly ISearchModel model;
        private readonly ISearchView view;

        private EditPresenter editPresenter;

        
        
        public SearchPresenter(ISearchModel model, ISearchView view)
        {
            this.model = model;
            this.view = view;
            
            EventListeners();
        }

        private void EventListeners()
        {
            view.onStateChanged += UpdateGrid;
            view.onFormLoad += LoadEditGrid;
            view.EditClicked += ClearGrid;
        }

        

        private void UpdateGrid(object sender, EventArgs e)
        {
            
            model.ControlNo = view.ControlNo;
            
            if(!string.IsNullOrWhiteSpace(model.ControlNo))
            {
                if (model.Connect())
                {
                    model.Grid = view.Grid;
                    // view.Grid = model.ReturnData(string.Format("SELECT* FROM Acord140_Critical WHERE ControlNoIMS = '{0}'",model.ControlNo));
                    view.Grid = model.ReturnData(string.Format(" exec Get140LocationInfo {0}",model.ControlNo.ToString()));
                }
                else
                {
                    MessageBox.Show(model.ErrorMessage);
                }
                
                
            }
        }

        private void LoadEditGrid(object sender, EventArgs e)
        {
            
            editPresenter = new EditPresenter();
            

        }
        private void ClearGrid(object sender, EventArgs e)
        {
            view.Grid = null;
            model.Grid = null;
        }
        

        

      
        

        

        
    }
}
