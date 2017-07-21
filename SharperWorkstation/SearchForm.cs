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
            isActive = true;

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

        public event EventHandler<EventArgs> onDeactive;

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
            //AddOwnedForm(editForm);
           
            //    foreach (var item in this.OwnedForms)
            //    {
            //        if (item.Name.Equals("EditForm"))
            //        {
            //            item.Visible = true;
            //            break;
            //        }

            //    }
            
            //if (EditPanel == null)
            //{
            //    EditPanel = new Panel();
            //    DataGridView editableDG = dgViewSOV;

            //    editableDG.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
            //    editableDG.MultiSelect = true;
            //    editableDG.AllowUserToDeleteRows = true;
            //    editableDG.AllowUserToAddRows = true;
            //    editableDG.AllowDrop = true;

            //    this.Controls.Add(EditPanel);
            //    EditPanel.Size = this.ClientSize;
            //    EditPanel.Visible = true;
            //    EditPanel.BringToFront();

            //    //add dg view to editable panel here
            //    EditPanel.Controls.Add(editableDG);
            //    this.Editbtn.Text = "Back";
            //    EditPanel.Controls.Add(this.Editbtn);
            //}
            //else if (Editbtn.Text.Equals("Back"))
            //{
            //    this.Editbtn.Text = "Edit";
            //    this.Controls.Remove(EditPanel);
            //    EditPanel = null;
            //    this.Controls.Add(Editbtn);
            //    this.Controls.Add(dgViewSOV);
            //    this.BringToFront();
            //}


        }

      

        
    }
}
