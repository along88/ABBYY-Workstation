namespace SharperWorkstation
{
    partial class EditForm
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
            this.backBtn = new System.Windows.Forms.Button();
            this.controlNumberLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // backBtn
            // 
            this.backBtn.Location = new System.Drawing.Point(520, 10);
            this.backBtn.Name = "backBtn";
            this.backBtn.Size = new System.Drawing.Size(65, 23);
            this.backBtn.TabIndex = 0;
            this.backBtn.Text = "Export View";
            this.backBtn.UseVisualStyleBackColor = true;
            this.backBtn.Click += new System.EventHandler(this.ExportBtn_Click);
            // 
            // EditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 355);
            this.Controls.Add(this.backBtn);
            this.Name = "EditForm";
            this.Text = "Sharper Workstation";
            this.ResumeLayout(false);
            // controlNumberLabel
            // 
            this.controlNumberLabel.AutoSize = true;
            this.controlNumberLabel.Location = new System.Drawing.Point(188, 15);
            this.controlNumberLabel.Name = "controlNumberLabel";
            this.controlNumberLabel.Size = new System.Drawing.Size(83, 13);
            this.controlNumberLabel.TabIndex = 7;
            this.controlNumberLabel.Text = "Control Number:";
            this.Controls.Add(this.controlNumberLabel);
        }
        #endregion
        private System.Windows.Forms.Button backBtn;
        private System.Windows.Forms.Label controlNumberLabel;
    }
}