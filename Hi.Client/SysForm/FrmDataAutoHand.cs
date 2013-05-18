using System;
using System.Windows.Forms;
using Hi.BLL;
using Hi.Model;

namespace Hi.Client.SysForm
{
    public partial class FrmDataAutoHand : Form
    {
        public FrmDataAutoHand()
        {
            InitializeComponent();
        }

        private void RefreshAutoData_Click(object sender, EventArgs e)
        {
            var model = new BasDataAuto
                {
                    MgMonth = MG_Month.Text,
                    MgDay = "1",
                    MgHour = "2",
                    MgMinites = "3",
                    MgDistance = "4",
                    MgPower = "5"
                };

            DataAuto ownerData  = IBLL.HiInstanceBll.DataAutoBll();
            var blResult = IBLL.HiInstanceBll.DataAutoBll().Add(model);

            MessageBox.Show(blResult ? "Success" : "Fail");
        }

        private void RefreshHandData_Click(object sender, EventArgs e)
        {
            var model = new BasDataHand
                {
                    MgMonth = MG_Month.Text,
                    MgDay = "1",
                    MgHour = "2",
                    MgMinites = "3",
                    MgDistance = "4",
                    MgPower = "5"
                };

            DataHand ownerData = IBLL.HiInstanceBll.DataHandBll();
            var blResult = IBLL.HiInstanceBll.DataHandBll().Add(model);

            MessageBox.Show(blResult ? "Success" : "Fail");
        }
    }
}
