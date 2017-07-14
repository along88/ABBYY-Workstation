using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1.WorkstationView
{
    public interface ISearchView
    {
        string ControlNo { get; set; }
        object Grid { get; set; }

        event EventHandler<EventArgs> onStateChanged;
        
    }
}
