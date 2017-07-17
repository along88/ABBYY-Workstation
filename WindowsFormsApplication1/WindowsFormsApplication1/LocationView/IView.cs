using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1.LocationView
{
    public interface IView
    {
        string ControlNo { get; set; }
        DataTable Grid { get; set; }

        event EventHandler<EventArgs> OnStateChanged;
        
    }
}
