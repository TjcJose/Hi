using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Hi.Common;
namespace Hi.Client
{
    public partial class FrmTrail : Form
    {
        public FrmTrail()
        {
            InitializeComponent();
        }

        private void FrmTrail_Load(object sender, EventArgs e)
        {
            //Test!
        }

        private void btnSumbit_Click(object sender, EventArgs e)
        {
            bool blResult;
            blResult = Hi.IBLL.HiInstanceBll.TrailBll().TrailUpdate(SetDetail());
            if (blResult)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Fail!");
            }
        }

        /// <summary>
        /// 重写获取详细事件
        /// </summary>
        private Hi.Model.BasTrail SetDetail()
        {
            Hi.Model.BasTrail model = new Hi.Model.BasTrail();
            //从画面取值
            model.OrgName = this.textBox1.Text.Trim();
            model.ParentId = this.textBox2.Text.Trim();

            return model;
        }
    }
}
