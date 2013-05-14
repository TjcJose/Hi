/*
------------------------------------------------------------------------------------------
 代码提供 ： 51编程-代码器
 作    者 ： 梁孙祥
       QQ ： 88130278
   EMail  ： LiangSunXiang@139.com
 官 方 网 ： www.51program.net
 个人博客 ： blog.csdn.net/liangsx
 温馨提示 ： 试用版本，附加版权内容。但不影响正常使用,请通过购买注册屏蔽此信息，谢谢！
 注册方法 ： 详情请访问官方网或来信咨询
-------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------------
 项目名称 ： 51编程-敏捷开发框架-客户端（单机版）
 功能描述 ： 
 创建信息 ：[开发员][版本][备注][日期]
            [Administrator][V1.0][51编程-代码器自动生成][2011-5-5 12:35:28]
 修改信息 ：(1)[开发员][V1.1][备注][日期]
            (2)[开发员][V1.2][备注][日期]
--------------------------------------------------------------------------------------------------
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Threading;
using System.Resources;
using System.Xml;
using System.Diagnostics;
using System.IO;
using System.Configuration;
using Hi.Common;

namespace Hi.Client
{
    public partial class FrmMain : Hi.UserControlEx.UcMain
    {
        #region 全局变量
        public Mutex mutex;
        #endregion 

        public FrmMain()
        {
            AppSetting.MyResourceManager = Properties.Resources.ResourceManager;
            //程序集名称
            this.ThisAssembly = Assembly.GetExecutingAssembly();
            this.ProgramName = this.ThisAssembly.ManifestModule.Name;
            Config.AppPath = Application.StartupPath;
            Icon icoLogo = HiBLL.GetIcoLogo;
            this.Icon = icoLogo;
            ucNotifyIcon.Icon = icoLogo;
            //配置文件参数
            this.Text = ConfigurationManager.AppSettings["ProjectName"];
            this.NameSpace = ConfigurationManager.AppSettings["ProjectNamespace"];
            AppSetting.UpdateXml = ConfigurationManager.AppSettings["UpdateXml"];
            Hi.Common.AppSetting.IniFileName = ConfigurationManager.AppSettings["SysConfigFile"];
            //gridview隔行变色
            Hi.Common.AppSetting.SkinStyle.RowColor = SystemColors.ControlLight;
            Config.IsDebug = false;

            InitializeComponent();   
            CheckForIllegalCrossThreadCalls = false;

            mutex = new Mutex(false, this.NameSpace+"_Single_MUTEX");
            if (!mutex.WaitOne(0, false))
            {
                mutex.Close();
                mutex = null;
            }
        }

        #region 初始化加载事件 
        
        protected override void Init()
        {
            //Hi.UserControlEx.UcSplash.SetStatus("正在生成系统菜单");

            ////系统菜单
            //InitMenu();

            //this.uclblUser.Text = "单位：" + AppSetting.SysOption.OrgName + "  用户：" + AppSetting.SysOption.UserName + "";
            ////this.uclblUserRole.Text = "角色：" + AppSetting.SysOption.;

            //Hi.UserControlEx.UcSplash.SetStatus("正在连接服务器...");
            ////HiBLL.ConnectedServices();
            ////系统参数

            //Hi.UserControlEx.UcSplash.SetStatus("正在初始化系统参数...");
            ////ModuleData.ParamDataSet();
        }
        private void FrmMain_Load(object sender, EventArgs e)
        {
            //新建窗体在tabPage显示
            this.ParentTabControl = this.ucTabControl1.tabWorkSpace;
            this.tbpnl.Dock = DockStyle.Fill;
            this.ucTabControl1.tabWorkSpace.TabPages[0].Controls.Add(this.tbpnl);

            Thread.Sleep(1500);
            Hi.UserControlEx.UcSplash.CloseForm();
            if (!HiBLL.SetConn())
                ExitApplication();
            Login();
            Init();
        }
 
        #endregion 

        #region 系统特殊事件或方法
        /// <summary>
        /// 用户验证
        /// </summary>
        private void Login()
        {
            this.uclblMsg.Text = "请输入用户名及密码登录...";
            FrmLogin frm = new FrmLogin();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.Cancel)
            {
                ExitApplication();
            }
            else
            {
                this.uclblMsg.Text = "就绪";
                InitThread(); 
            }
            FrmTrail frmttt = new FrmTrail();
            frmttt.Show();
        }

        /// <summary>
        /// 用户验证
        /// </summary>
        private void ReLogin()
        {
            this.uclblMsg.Text = "请输入用户名及密码登录...";
            FrmReLogin frm = new FrmReLogin();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                InitThread();
            }else
                this.uclblMsg.Text = "就绪";
        }
        /// <summary>
        /// 连接数据库
        /// </summary>
        private void ConnectedDb()
        {
            this.uclblMsg.Text = "请输入用户名及密码登录...";
            Hi.Common.FrmDbRegion frm = new FrmDbRegion();
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                InitThread();
            }
            else
                this.uclblMsg.Text = "就绪";
        }
        #endregion 

        #region 菜单或工具栏事件
        
        /// <summary>
        /// 重写UcMain中的虚方法
        /// </summary>
        public override void ShowNewForm()
        {
             if (this.MenuProperty == null)
                return;
            if (this.MenuProperty.ModuleCode.ToLower() == "login")
            {
                Login();
                return;
            }
            if (this.MenuProperty.ModuleCode.ToLower() == "relogin")
            {
                ReLogin();
                return;
            }
            if (this.MenuProperty.ModuleCode.ToLower() == "dbconfig")
            {
                ConnectedDb();
                return;
            }
            NewForm(this.ucTabControl1);
        }
        #endregion 
    }
}

