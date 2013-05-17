using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Hi.Model;

namespace Hi.Client.SysForm
{
    public partial class FrmDataAuto : Form
    {
        public FrmDataAuto()
        {
            InitializeComponent();
        }

        private void RefreshData_Click(object sender, EventArgs e)
        {
            BasDataAuto model = new BasDataAuto();
            model.MgMonth = MG_Month.Text;
            model.MgDay = "1";
            model.MgHour = "2";
            model.MgMinites = "3";
            model.MgDistance = "4";
            model.MgPower = "5";

            bool blResult;
            blResult = Hi.IBLL.HiInstanceBLL.DataAutoBLL().Add(model);

            if (blResult)
            {
                MessageBox.Show("Success");
            }
            else
            {
                MessageBox.Show("Fail");
            }
        }
    }
}
