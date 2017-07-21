using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharperWorkstation.WorkstationModels
{
    interface IEditModel
    {
        IList<string> selectedCells { get; set; }
    }
}
