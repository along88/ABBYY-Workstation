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
        public static string ControlNum
        {
            get;
            set;
        }
        public CustomForm( ) : base()
        {
            dgvErrorHandler += view_DataError;

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 355);

            //DataGrid View
            dgViewSOV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgViewSOV.Location = new System.Drawing.Point(0, 40);
            dgViewSOV.Name = "dgViewSOV";
            dgViewSOV.Size = new System.Drawing.Size(719, 300);
            dgViewSOV.TabIndex = 0;
            dgViewSOV.Anchor = (AnchorStyles.Right | AnchorStyles.Left);
            dgViewSOV.Anchor = (this.Anchor | AnchorStyles.Right | AnchorStyles.Left | AnchorStyles.Bottom);
            dgViewSOV.Top = 50;
            this.Controls.Add(dgViewSOV);
            ((System.ComponentModel.ISupportInitialize)(dgViewSOV)).EndInit();
           
        }

        void view_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
             object value = dgViewSOV.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (!((DataGridViewComboBoxColumn)dgViewSOV.Columns[e.ColumnIndex]).Items.Contains(value))
                {
                    ((DataGridViewComboBoxColumn)dgViewSOV.Columns[e.ColumnIndex]).Items.Add(value);
                    e.ThrowException = false;
                }
            

        }
        DataGridViewDataErrorEventHandler dgvErrorHandler;
    }
}
