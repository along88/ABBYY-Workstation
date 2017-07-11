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

            DataGridView editableDG = dgViewSOV;
            Grid = editableDG;


            //perhaps store a reference to current grid state and update the stored
            //reference every time a change is made

            //allow the grid to be exported into a locally saved Excel file
        }
    }
}
