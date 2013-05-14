namespace Hi.Client.BaseForm
{
    partial class BaseFormEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaseFormEdit));
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.tsTool = new System.Windows.Forms.ToolStrip();
            this.btnPrint = new System.Windows.Forms.ToolStripButton();
            this.btnAddAndSave = new System.Windows.Forms.ToolStripButton();
            this.btnSave = new System.Windows.Forms.ToolStripButton();
            this.btnCancel = new System.Windows.Forms.ToolStripButton();
            this.pnlWorkSpace = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.tsTool.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // tsTool
            // 
            this.tsTool.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tsTool.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnPrint,
            this.btnAddAndSave,
            this.btnSave,
            this.btnCancel});
            this.tsTool.Location = new System.Drawing.Point(0, 0);
            this.tsTool.Name = "tsTool";
            this.tsTool.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.tsTool.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tsTool.Size = new System.Drawing.Size(426, 25);
            this.tsTool.Stretch = true;
            this.tsTool.TabIndex = 0;
            this.tsTool.Text = "toolStrip1";
            // 
            // btnPrint
            // 
            this.btnPrint.Image = global::Hi.Client.Properties.Resources.print;
            this.btnPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(55, 22);
            this.btnPrint.Text = "打印";
            // 
            // btnAddAndSave
            // 
            this.btnAddAndSave.Image = global::Hi.Client.Properties.Resources.add;
            this.btnAddAndSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddAndSave.Name = "btnAddAndSave";
            this.btnAddAndSave.Size = new System.Drawing.Size(97, 22);
            this.btnAddAndSave.Text = "保存并新增";
            this.btnAddAndSave.Click += new System.EventHandler(this.btnAddAndSave_Click);
            // 
            // btnSave
            // 
            this.btnSave.Image = global::Hi.Client.Properties.Resources.accept;
            this.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(55, 22);
            this.btnSave.Text = "保存";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = global::Hi.Client.Properties.Resources.exit;
            this.btnCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(55, 22);
            this.btnCancel.Text = "关闭";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pnlWorkSpace
            // 
            this.pnlWorkSpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlWorkSpace.Location = new System.Drawing.Point(0, 25);
            this.pnlWorkSpace.Name = "pnlWorkSpace";
            this.pnlWorkSpace.Size = new System.Drawing.Size(426, 270);
            this.pnlWorkSpace.TabIndex = 1;
            // 
            // BaseFormEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.ClientSize = new System.Drawing.Size(426, 295);
            this.Controls.Add(this.pnlWorkSpace);
            this.Controls.Add(this.tsTool);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "BaseFormEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "显示编辑基类";
            this.Load += new System.EventHandler(this.BaseFormEdit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.tsTool.ResumeLayout(false);
            this.tsTool.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ToolStrip tsTool;
        public System.Windows.Forms.ToolStripButton btnAddAndSave;
        public System.Windows.Forms.ToolStripButton btnSave;
        public System.Windows.Forms.ToolStripButton btnCancel;
        public System.Windows.Forms.Panel pnlWorkSpace;
        public System.Windows.Forms.ToolStripButton btnPrint;

       
    }
}