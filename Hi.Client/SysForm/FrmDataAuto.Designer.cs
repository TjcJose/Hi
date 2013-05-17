namespace Hi.Client.SysForm
{
    partial class FrmDataAuto
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
            this.RefreshData = new System.Windows.Forms.Button();
            this.MG_Month = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // RefreshData
            // 
            this.RefreshData.Location = new System.Drawing.Point(103, 145);
            this.RefreshData.Name = "RefreshData";
            this.RefreshData.Size = new System.Drawing.Size(75, 23);
            this.RefreshData.TabIndex = 0;
            this.RefreshData.Text = "更新";
            this.RefreshData.UseVisualStyleBackColor = true;
            this.RefreshData.Click += new System.EventHandler(this.RefreshData_Click);
            // 
            // MG_Month
            // 
            this.MG_Month.Location = new System.Drawing.Point(91, 35);
            this.MG_Month.Name = "MG_Month";
            this.MG_Month.Size = new System.Drawing.Size(100, 21);
            this.MG_Month.TabIndex = 1;
            // 
            // FrmDataAuto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.MG_Month);
            this.Controls.Add(this.RefreshData);
            this.Name = "FrmDataAuto";
            this.Text = "FrmDataAuto";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RefreshData;
        private System.Windows.Forms.TextBox MG_Month;
    }
}