using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;


namespace WindowsFormsApplication1.LocationView
{
    public interface ExportView
    {
        Workbook WB { get; set; }
        Worksheet WS { get; set; }
        string SaveLocation { get; set; }

        char Column { get; set; }
        char Row { get; set; }

        event EventHandler<EventArgs> onExport;
    }
}
