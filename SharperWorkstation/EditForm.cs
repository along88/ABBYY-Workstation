using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharperWorkstation.WorkstationView;

namespace SharperWorkstation
{
    public partial class EditForm : CustomForm, IEditView
    {
        public EditForm()
        {
            InitializeComponent();
            activeForms.Add(this);
            dgViewSOV.AllowDrop = true;
            
        }

        public object grid
        {
            get
            {
                return dgViewSOV.DataSource;
            }
        }

        public IList<string> selectedCells
        {
            get
            {
                return (IList<string>)dgViewSOV.SelectedCells;
            }
        }

        public event EventHandler<EventArgs> onStateChanged;

        private void backBtn_Click(object sender, EventArgs e)
        {

            //need to give datagrid view control back to the search form
            MessageBox.Show(dgViewSOV.AllowDrop.ToString());
            activeForms.Remove(this);
        }

        private void EditForm_DragDrop(object sender, DragEventArgs e)
        {
            string droppedVale = sender as string;
            for (int i = 0; i < selectedCells.Count; i++)
            {
                selectedCells[i] = droppedVale;
            }
        }

        string grabbedItem;
       

      
    }
}
