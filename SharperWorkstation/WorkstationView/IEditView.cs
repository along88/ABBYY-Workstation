using System;
using System.Collections.Generic;

namespace SharperWorkstation.WorkstationView
{
    internal interface IEditView
    {
        //object grid { get; }

        IList<string> SelectedCells { get;}

        event EventHandler<EventArgs> onStateChanged;
    }
}