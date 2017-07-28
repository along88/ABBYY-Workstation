using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharperWorkstation.WorkstationModels
{
    interface IEditModel
    {
        string ControlNo { get; set; }
        IList<string> selectedCells { get; set; }
        object Grid { get; set; }
        string ErrorMessage { get; set; }

        bool Connect();
        DataTable LoadGrid(string query);
        DataTable ExportGrid();
    }
}
