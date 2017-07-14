using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.WorkstationModels;
using WindowsFormsApplication1.WorkstationPresenter;
using WindowsFormsApplication1.WorkstationView;

namespace WindowsFormsApplication1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ISearchModel model = new SearchModel();
            ISearchView view = new SharperWorkstation();
            SearchPresenter presenter = new SearchPresenter(model, view);
            Application.Run(view as SharperWorkstation);
        }
    }
}
