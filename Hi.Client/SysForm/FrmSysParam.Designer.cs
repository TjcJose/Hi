namespace Hi.Client
{
    partial class FrmSysParam
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtRoleName = new System.Windows.Forms.TextBox();
            this.lblOrgCode = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.btnSumbit = new System.Windows.Forms.Button();
            this.txtOrgName = new System.Windows.Forms.TextBox();
            this.lblOrgName = new System.Windows.Forms.Label();
            this.txtUpdateUrl = new System.Windows.Forms.TextBox();
            this.lblServicesUrl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrl.Location = new System.Drawing.Point(81, 124);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ReadOnly = true;
            this.txtUrl.Size = new System.Drawing.Size(236, 21);
            this.txtUrl.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "首页网址";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(200, 161);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtRoleName
            // 
            this.txtRoleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoleName.Location = new System.Drawing.Point(81, 12);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.ReadOnly = true;
            this.txtRoleName.Size = new System.Drawing.Size(236, 21);
            this.txtRoleName.TabIndex = 13;
            // 
            // lblOrgCode
            // 
            this.lblOrgCode.AutoSize = true;
            this.lblOrgCode.Location = new System.Drawing.Point(20, 14);
            this.lblOrgCode.Name = "lblOrgCode";
            this.lblOrgCode.Size = new System.Drawing.Size(53, 12);
            this.lblOrgCode.TabIndex = 12;
            this.lblOrgCode.Text = "角色类型";
            // 
            // btnSumbit
            // 
            this.btnSumbit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSumbit.Location = new System.Drawing.Point(126, 161);
            this.btnSumbit.Name = "btnSumbit";
            this.btnSumbit.Size = new System.Drawing.Size(68, 23);
            this.btnSumbit.TabIndex = 19;
            this.btnSumbit.Text = "关 闭";
            this.btnSumbit.UseVisualStyleBackColor = true;
            this.btnSumbit.Click += new System.EventHandler(this.btnSumbit_Click);
            // 
            // txtOrgName
            // 
            this.txtOrgName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrgName.Location = new System.Drawing.Point(81, 47);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.ReadOnly = true;
            this.txtOrgName.Size = new System.Drawing.Size(236, 21);
            this.txtOrgName.TabIndex = 15;
            // 
            // lblOrgName
            // 
            this.lblOrgName.AutoSize = true;
            this.lblOrgName.Location = new System.Drawing.Point(20, 49);
            this.lblOrgName.Name = "lblOrgName";
            this.lblOrgName.Size = new System.Drawing.Size(53, 12);
            this.lblOrgName.TabIndex = 14;
            this.lblOrgName.Text = "机构名称";
            // 
            // txtUpdateUrl
            // 
            this.txtUpdateUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateUrl.Location = new System.Drawing.Point(81, 84);
            this.txtUpdateUrl.Name = "txtUpdateUrl";
            this.txtUpdateUrl.ReadOnly = true;
            this.txtUpdateUrl.Size = new System.Drawing.Size(236, 21);
            this.txtUpdateUrl.TabIndex = 16;
            // 
            // lblServicesUrl
            // 
            this.lblServicesUrl.AutoSize = true;
            this.lblServicesUrl.Location = new System.Drawing.Point(22, 88);
            this.lblServicesUrl.Name = "lblServicesUrl";
            this.lblServicesUrl.Size = new System.Drawing.Size(53, 12);
            this.lblServicesUrl.TabIndex = 17;
            this.lblServicesUrl.Text = "升级网址";
            // 
            // FrmSysParam
            // 
            this.AcceptButton = this.btnSumbit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 198);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.txtRoleName);
            this.Controls.Add(this.lblOrgCode);
            this.Controls.Add(this.btnSumbit);
            this.Controls.Add(this.txtOrgName);
            this.Controls.Add(this.lblOrgName);
            this.Controls.Add(this.txtUpdateUrl);
            this.Controls.Add(this.lblServicesUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmSysParam";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户信息";
            this.Load += new System.EventHandler(this.FrmSysParam_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtRoleName;
        private System.Windows.Forms.Label lblOrgCode;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button btnSumbit;
        private System.Windows.Forms.TextBox txtOrgName;
        private System.Windows.Forms.Label lblOrgName;
        private System.Windows.Forms.TextBox txtUpdateUrl;
        private System.Windows.Forms.Label lblServicesUrl;
    }
}