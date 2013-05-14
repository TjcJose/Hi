namespace Hi.Client
{
    partial class FrmAdmin
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
            this.pnlWorkspace = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ucdgv = new System.Windows.Forms.DataGridView();
            this.module_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.memu_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.新增 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.修改 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.删除 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.打印 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.导出 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.tvMenu = new System.Windows.Forms.TreeView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCheckBoxColumn1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn2 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dataGridViewCheckBoxColumn5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.pnlWorkspace.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ucdgv)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlWorkspace
            // 
            this.pnlWorkspace.Controls.Add(this.panel2);
            this.pnlWorkspace.Controls.Add(this.panel1);
            this.pnlWorkspace.Controls.Add(this.splitter1);
            this.pnlWorkspace.Controls.Add(this.tvMenu);
            this.pnlWorkspace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkspace.Location = new System.Drawing.Point(0, 0);
            this.pnlWorkspace.Name = "pnlWorkspace";
            this.pnlWorkspace.Size = new System.Drawing.Size(725, 369);
            this.pnlWorkspace.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ucdgv);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(219, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(506, 324);
            this.panel2.TabIndex = 4;
            // 
            // ucdgv
            // 
            this.ucdgv.AllowUserToAddRows = false;
            this.ucdgv.AllowUserToDeleteRows = false;
            this.ucdgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.ucdgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ucdgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.module_code,
            this.memu_name,
            this.新增,
            this.修改,
            this.删除,
            this.打印,
            this.导出});
            this.ucdgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucdgv.Location = new System.Drawing.Point(0, 0);
            this.ucdgv.Name = "ucdgv";
            this.ucdgv.ReadOnly = true;
            this.ucdgv.RowTemplate.Height = 23;
            this.ucdgv.Size = new System.Drawing.Size(506, 324);
            this.ucdgv.TabIndex = 2;
            this.ucdgv.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ucdgv_CellContentClick);
            this.ucdgv.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.ucdgv_RowPostPaint);
            // 
            // module_code
            // 
            this.module_code.HeaderText = "编码";
            this.module_code.Name = "module_code";
            this.module_code.ReadOnly = true;
            // 
            // memu_name
            // 
            this.memu_name.HeaderText = "菜单名称";
            this.memu_name.Name = "memu_name";
            this.memu_name.ReadOnly = true;
            this.memu_name.Width = 200;
            // 
            // 新增
            // 
            this.新增.HeaderText = "新增";
            this.新增.Name = "新增";
            this.新增.ReadOnly = true;
            this.新增.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.新增.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.新增.ToolTipText = "新增权限";
            this.新增.Width = 40;
            // 
            // 修改
            // 
            this.修改.HeaderText = "修改";
            this.修改.Name = "修改";
            this.修改.ReadOnly = true;
            this.修改.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.修改.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.修改.ToolTipText = "修改编辑权限";
            this.修改.Width = 40;
            // 
            // 删除
            // 
            this.删除.HeaderText = "删除";
            this.删除.Name = "删除";
            this.删除.ReadOnly = true;
            this.删除.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.删除.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.删除.ToolTipText = "删除权限";
            this.删除.Width = 40;
            // 
            // 打印
            // 
            this.打印.HeaderText = "打印";
            this.打印.Name = "打印";
            this.打印.ReadOnly = true;
            this.打印.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.打印.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.打印.ToolTipText = "打印权限";
            this.打印.Width = 40;
            // 
            // 导出
            // 
            this.导出.HeaderText = "导出";
            this.导出.Name = "导出";
            this.导出.ReadOnly = true;
            this.导出.ToolTipText = "导出权限";
            this.导出.Width = 40;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInfo);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(219, 324);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 45);
            this.panel1.TabIndex = 3;
            // 
            // lblInfo
            // 
            this.lblInfo.AutoSize = true;
            this.lblInfo.Location = new System.Drawing.Point(43, 15);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(0, 12);
            this.lblInfo.TabIndex = 1;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(335, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "保  存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(216, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 369);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // tvMenu
            // 
            this.tvMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvMenu.Location = new System.Drawing.Point(0, 0);
            this.tvMenu.Name = "tvMenu";
            this.tvMenu.Size = new System.Drawing.Size(216, 369);
            this.tvMenu.TabIndex = 0;
            this.tvMenu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvMenu_AfterSelect);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "菜单名称";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 200;
            // 
            // dataGridViewCheckBoxColumn1
            // 
            this.dataGridViewCheckBoxColumn1.HeaderText = "新增";
            this.dataGridViewCheckBoxColumn1.Name = "dataGridViewCheckBoxColumn1";
            this.dataGridViewCheckBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn1.Width = 40;
            // 
            // dataGridViewCheckBoxColumn2
            // 
            this.dataGridViewCheckBoxColumn2.HeaderText = "修改";
            this.dataGridViewCheckBoxColumn2.Name = "dataGridViewCheckBoxColumn2";
            this.dataGridViewCheckBoxColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn2.Width = 40;
            // 
            // dataGridViewCheckBoxColumn3
            // 
            this.dataGridViewCheckBoxColumn3.HeaderText = "删除";
            this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
            this.dataGridViewCheckBoxColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn3.Width = 40;
            // 
            // dataGridViewCheckBoxColumn4
            // 
            this.dataGridViewCheckBoxColumn4.HeaderText = "打印";
            this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
            this.dataGridViewCheckBoxColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCheckBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewCheckBoxColumn4.Width = 40;
            // 
            // dataGridViewCheckBoxColumn5
            // 
            this.dataGridViewCheckBoxColumn5.HeaderText = "导出";
            this.dataGridViewCheckBoxColumn5.Name = "dataGridViewCheckBoxColumn5";
            this.dataGridViewCheckBoxColumn5.Width = 40;
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 369);
            this.Controls.Add(this.pnlWorkspace);
            this.Name = "FrmAdmin";
            this.Text = "系统设置";
            this.Load += new System.EventHandler(this.FrmAdmin_Load);
            this.pnlWorkspace.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ucdgv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlWorkspace;
        private System.Windows.Forms.TreeView tvMenu;
        private System.Windows.Forms.DataGridView ucdgv;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn module_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn memu_name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 新增;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 修改;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 删除;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 打印;
        private System.Windows.Forms.DataGridViewCheckBoxColumn 导出;
    }
}