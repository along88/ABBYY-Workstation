using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SharperWorkstation.WorkstationModels
{
    public interface ISearchModel
    {
        string ControlNo { get; set; }
        string ErrorMessage { get; set; }
        DataTable Grid { get; set; }
                      
        bool Connect();

        DataTable ReturnData(string query);
    }
}
