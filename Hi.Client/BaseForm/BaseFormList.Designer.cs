namespace Hi.Client.BaseForm
{
    partial class BaseFormList
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
            this.components = new System.ComponentModel.Container();
            this.gbQuerySpace = new System.Windows.Forms.GroupBox();
            this.pageDataGridViewEx1 = new Hi.UserControlEx.PageDataGridViewEx();
            this.SuspendLayout();
            // 
            // gbQuerySpace
            // 
            this.gbQuerySpace.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbQuerySpace.Location = new System.Drawing.Point(0, 0);
            this.gbQuerySpace.Name = "gbQuerySpace";
            this.gbQuerySpace.Size = new System.Drawing.Size(673, 67);
            this.gbQuerySpace.TabIndex = 0;
            this.gbQuerySpace.TabStop = false;
            this.gbQuerySpace.Visible = false;
            // 
            // pageDataGridViewEx1
            // 
            this.pageDataGridViewEx1.AutoNumber = 20;
            this.pageDataGridViewEx1.CurrentPage = 1;
            this.pageDataGridViewEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pageDataGridViewEx1.IsShowAll = false;
            this.pageDataGridViewEx1.IsShowCheckBox = -1;
            this.pageDataGridViewEx1.Location = new System.Drawing.Point(0, 67);
            this.pageDataGridViewEx1.MyColumnName = null;
            this.pageDataGridViewEx1.MyColumnTitle = null;
            this.pageDataGridViewEx1.MyDataTable = null;
            this.pageDataGridViewEx1.MyThread = null;
            this.pageDataGridViewEx1.Name = "pageDataGridViewEx1";
            this.pageDataGridViewEx1.PageSize = 20;
            this.pageDataGridViewEx1.Size = new System.Drawing.Size(673, 238);
            this.pageDataGridViewEx1.TabIndex = 1;
            this.pageDataGridViewEx1.TotalCount = 0;
            // 
            // BaseFormList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 305);
            this.Controls.Add(this.pageDataGridViewEx1);
            this.Controls.Add(this.gbQuerySpace);
            this.Name = "BaseFormList";
            this.Text = "显示列表基类";
            this.Load += new System.EventHandler(this.BaseFormList_Load);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox gbQuerySpace;
        public Hi.UserControlEx.PageDataGridViewEx pageDataGridViewEx1;

    }
}