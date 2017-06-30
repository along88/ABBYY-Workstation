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
    }
}
