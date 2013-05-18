namespace Hi.Client.SysForm
{
    partial class FrmDataAutoHand
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
            this.RefreshAutoData = new System.Windows.Forms.Button();
            this.MG_Month = new System.Windows.Forms.TextBox();
            this.RefreshHandData = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RefreshAutoData
            // 
            this.RefreshAutoData.Location = new System.Drawing.Point(91, 158);
            this.RefreshAutoData.Name = "RefreshAutoData";
            this.RefreshAutoData.Size = new System.Drawing.Size(104, 23);
            this.RefreshAutoData.TabIndex = 0;
            this.RefreshAutoData.Text = "Auto更新";
            this.RefreshAutoData.UseVisualStyleBackColor = true;
            this.RefreshAutoData.Click += new System.EventHandler(this.RefreshAutoData_Click);
            // 
            // MG_Month
            // 
            this.MG_Month.Location = new System.Drawing.Point(91, 35);
            this.MG_Month.Name = "MG_Month";
            this.MG_Month.Size = new System.Drawing.Size(100, 21);
            this.MG_Month.TabIndex = 1;
            // 
            // RefreshHandData
            // 
            this.RefreshHandData.Location = new System.Drawing.Point(90, 120);
            this.RefreshHandData.Name = "RefreshHandData";
            this.RefreshHandData.Size = new System.Drawing.Size(104, 23);
            this.RefreshHandData.TabIndex = 2;
            this.RefreshHandData.Text = "Hand更新";
            this.RefreshHandData.UseVisualStyleBackColor = true;
            this.RefreshHandData.Click += new System.EventHandler(this.RefreshHandData_Click);
            // 
            // FrmDataAutoHand
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.RefreshHandData);
            this.Controls.Add(this.MG_Month);
            this.Controls.Add(this.RefreshAutoData);
            this.Name = "FrmDataAutoHand";
            this.Text = "FrmDataAutoHand";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RefreshAutoData;
        private System.Windows.Forms.TextBox MG_Month;
        private System.Windows.Forms.Button RefreshHandData;
    }
}