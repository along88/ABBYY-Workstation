using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.LocationModels;
using WindowsFormsApplication1.LocationView;
using System.Windows.Forms;
namespace WindowsFormsApplication1.LocationPresenter
{
    public class Presenter
    {
        private readonly IModel model;
        private readonly IView view;
        
        public Presenter(IModel model, IView view)
        {
            this.model = model;
            this.view = view;
            EventListeners();
        }

        public Presenter()
        {
        }

        private void EventListeners()
        {
            view.onStateChanged += UpdateGrid;
        }

        private void UpdateGrid(object sender, EventArgs e)
        {
            
            model.ControlNo = view.ControlNo;
            
            if(!string.IsNullOrWhiteSpace(model.ControlNo))
            {
                if (model.Connect())
                {
                    model.Grid = view.Grid;
                    view.Grid = model.ReturnData(string.Format("SELECT* FROM Acord140_Critical WHERE ControlNoIMS = '{0}'",model.ControlNo));
                    
                }
                else
                {
                    MessageBox.Show(model.ErrorMessage);
                }
                
                
            }
        }

      
        

        

        
    }
}
