namespace Hi.Client
{
    partial class FrmMain
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
            this.ucTabControl1 = new Hi.UserControlEx.UcTabControl();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbpnl = new System.Windows.Forms.TableLayoutPanel();
            this.timerUpload = new System.Windows.Forms.Timer(this.components);
            this.timerVer = new System.Windows.Forms.Timer(this.components);
            this.pnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tbpnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucNotifyIcon
            // 
            this.ucNotifyIcon.Visible = true;
            // 
            // ucTimer
            // 
            this.ucTimer.Enabled = true;
            // 
            // ucTabControl1
            // 
            this.ucTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucTabControl1.Location = new System.Drawing.Point(0, 49);
            this.ucTabControl1.Name = "ucTabControl1";
            this.ucTabControl1.Size = new System.Drawing.Size(736, 390);
            this.ucTabControl1.TabIndex = 9;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.pictureBox1);
            this.pnlLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLeft.Location = new System.Drawing.Point(3, 3);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(730, 384);
            this.pnlLeft.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.ImageLocation = "Resources\\logobg.jpg";
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(730, 384);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // tbpnl
            // 
            this.tbpnl.ColumnCount = 2;
            this.tbpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbpnl.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 0F));
            this.tbpnl.Controls.Add(this.pnlLeft, 0, 0);
            this.tbpnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbpnl.Location = new System.Drawing.Point(0, 49);
            this.tbpnl.Name = "tbpnl";
            this.tbpnl.RowCount = 1;
            this.tbpnl.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tbpnl.Size = new System.Drawing.Size(736, 390);
            this.tbpnl.TabIndex = 10;
            // 
            // timerUpload
            // 
            this.timerUpload.Interval = 1000;
            // 
            // timerVer
            // 
            this.timerVer.Enabled = true;
            this.timerVer.Interval = 5000;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.ClientSize = new System.Drawing.Size(736, 461);
            this.Controls.Add(this.tbpnl);
            this.Controls.Add(this.ucTabControl1);
            this.IsShowMessage = 977;
            this.Name = "FrmMain";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.Controls.SetChildIndex(this.ucTabControl1, 0);
            this.Controls.SetChildIndex(this.tbpnl, 0);
            this.pnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tbpnl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Hi.UserControlEx.UcTabControl ucTabControl1;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.TableLayoutPanel tbpnl;
        private System.Windows.Forms.Timer timerUpload;
        private System.Windows.Forms.Timer timerVer;
        private System.Windows.Forms.PictureBox pictureBox1;

    }
}
