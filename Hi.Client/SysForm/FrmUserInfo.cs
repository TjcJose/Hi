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
    public partial class FrmUserInfo : Form
    {

        public FrmUserInfo()
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
            this.txtRoleName.Text = AppSetting.SysOption.OrgName;
            this.txtOrgName.Text = "";
            this.txtUserCode.Text = AppSetting.SysOption.UserCode;
            this.txtRealName.Text = AppSetting.SysOption.UserName;
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
           // Hi.Common.AppSetting.Save();
            ResetPassword();
            
        }
        private void ResetPassword()
        {
            string old_pwd= this.txtOldPwd.Text.Trim();
            string new_pwd= this.txtNewPwd.Text.Trim();
             string confirm_pwd= this.txtConfirmPwd.Text.Trim();

            if(string.IsNullOrEmpty(old_pwd))
            {
                MsgBox.ShowInformation("请输入原密码!");
                return ;
            }
            if(MD5.MD5Encrypt(old_pwd)!=AppSetting.SysOption.UserPassword)
            {
                MsgBox.ShowInformation("原密码错误!");
                return ;
            }
            if(string.IsNullOrEmpty(new_pwd))
            {
                MsgBox.ShowInformation("请输入新密码");
                return ;
            }
             if(new_pwd!=confirm_pwd)
            {
                MsgBox.ShowInformation("两次输入密码不正确!");
                return ;
            }


             Hi.BLL.User bll = new Hi.BLL.User();// HiBLL.HiInstanceBLL().UserBLL();
            bool blFlag = bll.ResetPassword(AppSetting.SysOption.UserId, new_pwd);
            if (blFlag)
            {
                MsgBox.ShowInformation("重置密码成功!");
                this.Close();
            }
            else
                MsgBox.ShowInformation("重置密码失败!");
        }
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
