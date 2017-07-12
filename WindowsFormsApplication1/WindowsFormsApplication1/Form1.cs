using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.LocationView;

namespace WindowsFormsApplication1
{
    public partial class LocationComparison : Form, IView
    {
        public LocationComparison()
        {
            InitializeComponent();
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

        private void btnExport_Click(object sender, EventArgs e)
        {
            //call Export here
        }

        private void Editbtn_Click(object sender, EventArgs e)
        {
            
            if (EditPanel == null)
            {
                EditPanel = new Panel();
                DataGridView editableDG = dgViewSOV;
                this.Controls.Add(EditPanel);
                EditPanel.Size = this.ClientSize;
                EditPanel.Visible = true;
                EditPanel.BringToFront();
                EditPanel.Controls.Add(this.dgViewSOV);
                this.Editbtn.Text = "Back";
                EditPanel.Controls.Add(this.Editbtn);
                
            }
            else if (Editbtn.Text.Equals("Back"))
            {
                this.Editbtn.Text = "Edit";
                this.Controls.Remove(EditPanel);
                EditPanel = null;
                this.Controls.Add(Editbtn);
                this.Controls.Add(dgViewSOV);
                this.BringToFront();
            }


            //perhaps store a reference to current grid state and update the stored
            //reference every time a change is made

            //allow the grid to be exported into a locally saved Excel file
        }
    }
}
