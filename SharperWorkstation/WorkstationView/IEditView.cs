using System;
using System.Collections.Generic;

namespace SharperWorkstation.WorkstationView
{
    internal interface IEditView
    {
        IList<string> SelectedCells { get; set; }

        string ControlNo { get; set; }
        object Grid { get; set; }

        event EventHandler<EventArgs> LoadEditForm;
        event EventHandler<EventArgs> onExport;

    }
        
}