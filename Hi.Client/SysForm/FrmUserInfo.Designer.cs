namespace Hi.Client
{
    partial class FrmUserInfo
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNewPwd = new System.Windows.Forms.TextBox();
            this.txtConfirmPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserCode = new System.Windows.Forms.TextBox();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrl.Location = new System.Drawing.Point(87, 126);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.ReadOnly = true;
            this.txtUrl.Size = new System.Drawing.Size(230, 21);
            this.txtUrl.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 22;
            this.label1.Text = "首页网址：";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(264, 163);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(68, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtRoleName
            // 
            this.txtRoleName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRoleName.Location = new System.Drawing.Point(88, 54);
            this.txtRoleName.Name = "txtRoleName";
            this.txtRoleName.ReadOnly = true;
            this.txtRoleName.Size = new System.Drawing.Size(230, 21);
            this.txtRoleName.TabIndex = 13;
            // 
            // lblOrgCode
            // 
            this.lblOrgCode.AutoSize = true;
            this.lblOrgCode.Location = new System.Drawing.Point(15, 58);
            this.lblOrgCode.Name = "lblOrgCode";
            this.lblOrgCode.Size = new System.Drawing.Size(71, 12);
            this.lblOrgCode.TabIndex = 12;
            this.lblOrgCode.Text = "部门/角色：";
            // 
            // btnSumbit
            // 
            this.btnSumbit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSumbit.Location = new System.Drawing.Point(190, 163);
            this.btnSumbit.Name = "btnSumbit";
            this.btnSumbit.Size = new System.Drawing.Size(68, 23);
            this.btnSumbit.TabIndex = 19;
            this.btnSumbit.Text = "保 存";
            this.btnSumbit.UseVisualStyleBackColor = true;
            this.btnSumbit.Click += new System.EventHandler(this.btnSumbit_Click);
            // 
            // txtOrgName
            // 
            this.txtOrgName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOrgName.Location = new System.Drawing.Point(90, 21);
            this.txtOrgName.Name = "txtOrgName";
            this.txtOrgName.ReadOnly = true;
            this.txtOrgName.Size = new System.Drawing.Size(230, 21);
            this.txtOrgName.TabIndex = 15;
            // 
            // lblOrgName
            // 
            this.lblOrgName.AutoSize = true;
            this.lblOrgName.Location = new System.Drawing.Point(24, 23);
            this.lblOrgName.Name = "lblOrgName";
            this.lblOrgName.Size = new System.Drawing.Size(65, 12);
            this.lblOrgName.TabIndex = 14;
            this.lblOrgName.Text = "机构名称：";
            // 
            // txtUpdateUrl
            // 
            this.txtUpdateUrl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUpdateUrl.Location = new System.Drawing.Point(87, 87);
            this.txtUpdateUrl.Name = "txtUpdateUrl";
            this.txtUpdateUrl.Size = new System.Drawing.Size(230, 21);
            this.txtUpdateUrl.TabIndex = 16;
            // 
            // lblServicesUrl
            // 
            this.lblServicesUrl.AutoSize = true;
            this.lblServicesUrl.Location = new System.Drawing.Point(23, 91);
            this.lblServicesUrl.Name = "lblServicesUrl";
            this.lblServicesUrl.Size = new System.Drawing.Size(65, 12);
            this.lblServicesUrl.TabIndex = 17;
            this.lblServicesUrl.Text = "升级网址：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtUpdateUrl);
            this.groupBox1.Controls.Add(this.lblOrgCode);
            this.groupBox1.Controls.Add(this.txtUrl);
            this.groupBox1.Controls.Add(this.lblServicesUrl);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblOrgName);
            this.groupBox1.Controls.Add(this.txtRoleName);
            this.groupBox1.Controls.Add(this.txtOrgName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(337, 155);
            this.groupBox1.TabIndex = 24;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "基本信息";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtRealName);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtNewPwd);
            this.groupBox2.Controls.Add(this.txtConfirmPwd);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtUserCode);
            this.groupBox2.Controls.Add(this.txtOldPwd);
            this.groupBox2.Controls.Add(this.btnSumbit);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 155);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 192);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "修改密码";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 29;
            this.label6.Text = "真实姓名：";
            // 
            // txtRealName
            // 
            this.txtRealName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRealName.Location = new System.Drawing.Point(81, 46);
            this.txtRealName.MaxLength = 30;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(236, 21);
            this.txtRealName.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 25;
            this.label4.Text = "新密码：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 136);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 27;
            this.label5.Text = "确认密码：";
            // 
            // txtNewPwd
            // 
            this.txtNewPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPwd.Location = new System.Drawing.Point(82, 103);
            this.txtNewPwd.MaxLength = 16;
            this.txtNewPwd.Name = "txtNewPwd";
            this.txtNewPwd.PasswordChar = '*';
            this.txtNewPwd.Size = new System.Drawing.Size(236, 21);
            this.txtNewPwd.TabIndex = 26;
            // 
            // txtConfirmPwd
            // 
            this.txtConfirmPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtConfirmPwd.Location = new System.Drawing.Point(82, 132);
            this.txtConfirmPwd.MaxLength = 16;
            this.txtConfirmPwd.Name = "txtConfirmPwd";
            this.txtConfirmPwd.PasswordChar = '*';
            this.txtConfirmPwd.Size = new System.Drawing.Size(236, 21);
            this.txtConfirmPwd.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 21;
            this.label2.Text = "用户名：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 23;
            this.label3.Text = "原密码：";
            // 
            // txtUserCode
            // 
            this.txtUserCode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserCode.Location = new System.Drawing.Point(82, 20);
            this.txtUserCode.Name = "txtUserCode";
            this.txtUserCode.ReadOnly = true;
            this.txtUserCode.Size = new System.Drawing.Size(236, 21);
            this.txtUserCode.TabIndex = 22;
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOldPwd.Location = new System.Drawing.Point(82, 73);
            this.txtOldPwd.MaxLength = 16;
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.PasswordChar = '*';
            this.txtOldPwd.Size = new System.Drawing.Size(236, 21);
            this.txtOldPwd.TabIndex = 24;
            // 
            // FrmUserInfo
            // 
            this.AcceptButton = this.btnSumbit;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 347);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmUserInfo";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "用户信息";
            this.Load += new System.EventHandler(this.FrmSysParam_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

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
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNewPwd;
        private System.Windows.Forms.TextBox txtConfirmPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserCode;
        private System.Windows.Forms.TextBox txtOldPwd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRealName;
    }
}