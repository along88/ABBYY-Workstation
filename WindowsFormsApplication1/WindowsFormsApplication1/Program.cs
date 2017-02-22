using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.LocationModels;
using WindowsFormsApplication1.LocationPresenter;
using WindowsFormsApplication1.LocationView;

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
            IModel model = new Model();
            IView view = new LocationComparison();
            Presenter presenter = new Presenter(model, view);
            Application.Run(view as LocationComparison);
        }
    }
}
