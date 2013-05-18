using System;
using System.Windows.Forms;

namespace Hi.Client
{
    public partial class FrmTrail : Form
    {
        public FrmTrail()
        {
            InitializeComponent();
        }

        private void btnSumbit_Click(object sender, EventArgs e)
        {
            bool blResult = IBLL.HiInstanceBll.TrailBll().TrailUpdate(SetDetail());
            MessageBox.Show(!blResult ? "Fail!" : "Success");
        }

        /// <summary>
        /// 重写获取详细事件
        /// </summary>
        private Model.BasTrail SetDetail()
        {
            //从画面取值
            var model = new Model.BasTrail
                {
                    OrgName  = textBox1.Text.Trim(),
                    ParentId = textBox2.Text.Trim()
                };

            return model;
        }
    }
}
