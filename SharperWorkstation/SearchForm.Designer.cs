namespace SharperWorkstation
{
    partial class SearchForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtControlNo = new System.Windows.Forms.TextBox();
            this.controlNumberLabel = new System.Windows.Forms.Label();
            this.Editbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtControlNo
            // 
            this.txtControlNo.Location = new System.Drawing.Point(277, 12);
            this.txtControlNo.Name = "txtControlNo";
            this.txtControlNo.Size = new System.Drawing.Size(100, 20);
            this.txtControlNo.TabIndex = 5;
            this.txtControlNo.TextChanged += new System.EventHandler(this.txtControlNo_TextChanged);
            // 
            // controlNumberLabel
            // 
            this.controlNumberLabel.AutoSize = true;
            this.controlNumberLabel.Location = new System.Drawing.Point(188, 15);
            this.controlNumberLabel.Name = "controlNumberLabel";
            this.controlNumberLabel.Size = new System.Drawing.Size(83, 13);
            this.controlNumberLabel.TabIndex = 7;
            this.controlNumberLabel.Text = "Control Number:";
            // 
            // Editbtn
            // 
            this.Editbtn.Location = new System.Drawing.Point(520, 10);
            this.Editbtn.Name = "Editbtn";
            this.Editbtn.Size = new System.Drawing.Size(65, 23);
            this.Editbtn.TabIndex = 8;
            this.Editbtn.Text = "Edit";
            this.Editbtn.UseVisualStyleBackColor = true;
            this.Editbtn.Click += new System.EventHandler(this.Editbtn_Click);
            // 
            // SearchForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 355);
            this.Controls.Add(this.Editbtn);
            this.Controls.Add(this.controlNumberLabel);
            this.Controls.Add(this.txtControlNo);
            this.Name = "SearchForm";
            this.Text = "Sharper Workstation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        //private System.Windows.Forms.DataGridView dgViewSOV;
        private System.Windows.Forms.TextBox txtControlNo;
        private System.Windows.Forms.Label controlNumberLabel;
        private System.Windows.Forms.Button Editbtn;
    }
}

