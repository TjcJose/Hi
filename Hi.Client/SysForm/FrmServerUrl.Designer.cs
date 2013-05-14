namespace Hi.Client
{
    partial class FrmServerUrl
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtServicesUrl = new System.Windows.Forms.TextBox();
            this.lblServicesUrl = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSumbit = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtServicesUrl
            // 
            this.txtServicesUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtServicesUrl.Location = new System.Drawing.Point(80, 33);
            this.txtServicesUrl.Name = "txtServicesUrl";
            this.txtServicesUrl.Size = new System.Drawing.Size(236, 21);
            this.txtServicesUrl.TabIndex = 5;
            // 
            // lblServicesUrl
            // 
            this.lblServicesUrl.AutoSize = true;
            this.lblServicesUrl.Location = new System.Drawing.Point(9, 39);
            this.lblServicesUrl.Name = "lblServicesUrl";
            this.lblServicesUrl.Size = new System.Drawing.Size(65, 12);
            this.lblServicesUrl.TabIndex = 4;
            this.lblServicesUrl.Text = "服务器地址";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(196, 76);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(50, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSumbit
            // 
            this.btnSumbit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSumbit.Location = new System.Drawing.Point(124, 76);
            this.btnSumbit.Name = "btnSumbit";
            this.btnSumbit.Size = new System.Drawing.Size(50, 23);
            this.btnSumbit.TabIndex = 7;
            this.btnSumbit.Text = "确定";
            this.btnSumbit.UseVisualStyleBackColor = true;
            this.btnSumbit.Click += new System.EventHandler(this.btnSumbit_Click);
            // 
            // btnTest
            // 
            this.btnTest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTest.Location = new System.Drawing.Point(60, 76);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(50, 23);
            this.btnTest.TabIndex = 9;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Visible = false;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // FrmServerUrl
            // 
            this.AcceptButton = this.btnSumbit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 125);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSumbit);
            this.Controls.Add(this.txtServicesUrl);
            this.Controls.Add(this.lblServicesUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmServerUrl";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "修改服务器地址";
            this.Load += new System.EventHandler(this.FrmServerUrl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtServicesUrl;
        private System.Windows.Forms.Label lblServicesUrl;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSumbit;
        private System.Windows.Forms.Button btnTest;
    }
}