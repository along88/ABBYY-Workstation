using System;
using System.Collections.Generic;

namespace SharperWorkstation.WorkstationView
{
    internal interface IEditView
    {


        IList<string> SelectedCells { get; }
    }
        
}