using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SharperWorkstation
{
    public class CustomForm : Form
    {
        protected static System.Windows.Forms.DataGridView dgViewSOV = new System.Windows.Forms.DataGridView();

        protected static List<Form> activeForms = new List<Form>();
        public CustomForm( ) : base()
        {
            
           
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 355);

            //DataGrid View
            dgViewSOV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgViewSOV.Location = new System.Drawing.Point(0, 38);
            dgViewSOV.Name = "dgViewSOV";
            dgViewSOV.Size = new System.Drawing.Size(719, 318);
            dgViewSOV.TabIndex = 0;
            this.Controls.Add(dgViewSOV);
            ((System.ComponentModel.ISupportInitialize)(dgViewSOV)).EndInit();
        }
    }
}
