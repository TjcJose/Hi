using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using Hi.Common;
namespace Hi.Client
{
    public partial class FrmSysParam : Form
    {

        public FrmSysParam()
        {

            InitializeComponent();
            this.Icon = HiBLL.GetIcoLogo;   

        }
       
        
        private void FrmSysParam_Load(object sender, EventArgs e)
        {
            GetParam();
        }
        private void GetParam()
        {
            Hi.Common.AppSetting.Read();
            this.txtUrl.Text = Hi.Common.AppSetting.SysOption.ServerUrl;
            this.txtUpdateUrl.Text = Hi.Common.AppSetting.SysOption.UpdateUrl;
            //this.txtRoleName.Text = AppSetting.SysOption.OrgName;
            this.txtOrgName.Text = AppSetting.SysOption.OrgName;
        }
        private void RunWhenStart(bool Started, string name, string path)
        {

            Microsoft.Win32.RegistryKey lm = Microsoft.Win32.Registry.LocalMachine;
            Microsoft.Win32.RegistryKey run = lm.CreateSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Run");
            if (Started == true)
            {
                try
                {
                    run.SetValue(name, path);
                    lm.Close();
                }
                catch (Exception ex)
                {
                    MsgBox.ShowError(ex.Message);
                }
            }
            else
            {
                try
                {
                    if (run.GetValue(name) != null)
                    {
                        run.DeleteValue(name, false);
                        lm.Close();
                    }
                }
                catch (Exception)
                {
                    // 
                }
            }
        }


        private void btnSumbit_Click(object sender, EventArgs e)
        {
            AppSetting.SysOption.ServerUrl = this.txtUrl.Text;
            AppSetting.SysOption.UpdateUrl = this.txtUpdateUrl.Text;
            Hi.Common.AppSetting.Save();
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
