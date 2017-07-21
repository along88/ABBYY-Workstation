using SharperWorkstation;
using SharperWorkstation.WorkstationView;
using System;
using System.Windows.Forms;

namespace SharperWorkstation
{
    public partial class SharperWorkstation : CustomForm, ISearchView
    {
        bool isActive;
        public SharperWorkstation()
        {
            InitializeComponent();
            activeForms.Add(this);
            

        }

        public string ControlNo
        {

            get { return txtControlNo.Text; }

            set { txtControlNo.Text = value; }
        }

        public object Grid
        {
            get {return dgViewSOV.DataSource;}
            set { dgViewSOV.DataSource = value; }
        }

        public Panel EditPanel
        {
            get;
            set;
        }

        public event EventHandler<EventArgs> onStateChanged;

        private void txtControlNo_TextChanged(object sender , EventArgs e)
        {
            
            TextBox txtBox = sender as TextBox;
            if (!string.IsNullOrWhiteSpace(txtBox.Text))
            {
                
                onStateChanged(this, e);

            }

        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            isActive = false;
            activeForms.Remove(this);
            EditForm editForm = new EditForm();
            editForm.Visible = true;
        }
    }
}
