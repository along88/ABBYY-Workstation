using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.WorkstationModels
{
    public interface ISearchModel
    {
        string ControlNo { get; set; }
        string ErrorMessage { get; set; }

        object Grid { get; set; }

        
       
        bool Connect();
        DataTable ReturnData(string query);








    }
}
