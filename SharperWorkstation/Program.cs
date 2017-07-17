using SharperWorkstation.WorkstationView;
using System;
using System.Windows.Forms;
using SharperWorkstation.WorkstationModels;
using SharperWorkstation.WorkstationPresenter;

namespace SharperWorkstation
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
