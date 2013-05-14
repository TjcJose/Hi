using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Data;
using System.IO;
using System.Collections;
using System.Web.Services.Protocols;
using System.Configuration;
using System.Windows.Forms;
using System.Drawing;

using Hi.Common;
using Hi.Remoting.Common;
namespace Hi.Client
{
    public class HiBLL 
    {
        public static Icon GetIcoLogo
        {
            get { return ((Icon)(AppSetting.MyResourceManager.GetObject("logo"))); }
        }
        private static string DbConnectionString
        {
            get { return string.Format(ConfigurationManager.AppSettings["DbConnectionString"],Application.StartupPath+"\\"); }
        }
        private static string DbProviderName
        {
            get { return ConfigurationManager.AppSettings["DbProvider"]; }
        }
        public static bool SetConn()
        {
            bool blFlag = false;
            try
            {
                Hi.Common.Db.DbUtils.DbConfigFile = ConfigurationManager.AppSettings["DbConfigFile"];
                if (File.Exists(Hi.Common.Db.DbUtils.DbConfigFile))
                {
                    LoadDbConfigFile();
                    blFlag = true;
                }
                else
                {
                    FrmDbRegion f = new FrmDbRegion();
                    f.ShowDialog();
                    if (f.DialogResult == DialogResult.OK)
                    {
                        LoadDbConfigFile();
                        blFlag = true;
                    }
                    else
                    {
                        Application.Exit();
                        blFlag = false;
                    }
                }
            }
            catch (Exception ex) { MsgBox.ShowError(ex.Message); Error.ErrorMsg(ex); }
            return blFlag;
        }
        private static void LoadDbConfigFile()
        {
            DbConfig dbconfig = Hi.Common.Db.DbUtils.LoadFromBinaryFile(Hi.Common.Db.DbUtils.DbConfigFile);
            //Hi.Common.Db.DbUtils.ProviderName = DbProviderName;
            //Hi.Common.Db.DbUtils.ConnectionString = DbConnectionString;
            Hi.Common.Db.DbUtils.ProviderName = dbconfig.DbProviderName;
            Hi.Common.Db.DbUtils.ConnectionString = dbconfig.ConnectionString;
            Hi.Common.Db.DbUtils.Dal = ConfigurationManager.AppSettings[dbconfig.DbType];
        }
        #region 连接Remoting结构控制台
        //private static IHiCoordinator _IHiCoordinator = null;
        //private static EventWrapper _Wrapper = null;
        //public static string _MessageInfo = null;
        //public static ChannelModel ChannelDetail { get; set; }
        //public static string GetHostName()
        //{
        //    return Hi.Common.ChannelClass.GetMyHostName();
        //}

        //public static IHiCoordinator HiInstanceBLL()
        //{
        //    try
        //    {
        //        if (ChannelDetail == null)
        //            return null;
        //        if (_IHiCoordinator == null)
        //            MsgBox.ShowInformation(ChannelDetail.Ip + "服务可能已经停止!");

        //        return _IHiCoordinator;
        //    }
        //    catch (Exception ex)
        //    {
        //        MsgBox.ShowInformation("请确保已启动" + ChannelDetail.Ip + ":" + ex.Message);
        //        return null;
        //    }
        //}
        #endregion

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="user_code"></param>
        /// <param name="password"></param>
        /// <param name="strResult"></param>
        /// <returns></returns>
        public static bool DoLogin(string user_code, string password, out string strResult)
        {
            bool blResult = false;
           
            Hi.Model.BasUser model = new Model.BasUser();
            model = Hi.IBLL.HiInstanceBLL.UserBLL().Detail(user_code);
            if (model != null && Utils.StrToInt(model.UserId)>0 && model.UserPassword == MD5.MD5Encrypt(password.Trim()))
            {
                AppSetting.SysOption.UserId = model.UserId;
                AppSetting.SysOption.UserCode = model.UserCode;
                AppSetting.SysOption.UserName = model.RealName;
                AppSetting.SysOption.Purview = model.Purview;
                AppSetting.SysOption.UserPassword = model.UserPassword;
                AppSetting.SysOption.OrgId = model.OrgId.ToString();
                AppSetting.SysOption.OrgName = model.OrgName;
                AppSetting.SysOption.PurviewDetail = model.PurviewDetail;
                blResult = true;
                strResult = "登录成功！";
            }
            else
                strResult = "登录失败!";
            return blResult;
        }
        
    }
}
