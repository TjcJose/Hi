using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

using Hi.Common;
using Hi.Remoting.Common;
namespace Hi.IBLL
{
    public class HiInstanceBLL
    {
        private static string ClientType = ConfigurationManager.AppSettings["ClientType"];

        #region Remoting对象
        private static IHiCoordinator _IHiCoordinator = null;
        private static EventWrapper _Wrapper = null;
        public static string _MessageInfo = null;
        public static ChannelModel ChannelDetail { get; set; }
        public static IHiCoordinator GetInstance()
        {
            try
            {
                if (ChannelDetail == null)
                    return null;
                if (_IHiCoordinator == null)
                    MsgBox.ShowInformation(ChannelDetail.Ip + "服务可能已经停止!");

                return _IHiCoordinator;
            }
            catch (Exception ex)
            {
                MsgBox.ShowInformation("请确保已成功连接" + ChannelDetail.Ip + ":" + ex.Message);
                return null;
            }
        }
        public static void SetDisConnection()
        {
            _IHiCoordinator = null;
        }
        public static bool ConnectionServer(ChannelModel model)
        {
            //获取远程对象
            ChannelGroup channelGroup;
            if (model.ChannelGroupType == "1")
                channelGroup = ChannelGroup.TCP;
            else
                channelGroup = ChannelGroup.HTTP;
            string protocol = "tcp";
            if (channelGroup == ChannelGroup.HTTP) protocol = "http";
            string uri = GetServerUrl(protocol, model);
            try
            {
                ChannelClass.StartChannel(channelGroup, model.ChannelName);
                _IHiCoordinator = Activator.GetObject(typeof(IHiCoordinator), uri) as IHiCoordinator;

                _Wrapper = new EventWrapper();
                _Wrapper.Server2ClientEvent += new IServer2ClientEventHandler(GetServerMessage);
                _IHiCoordinator.Server2ClientEvent += new IServer2ClientEventHandler(_Wrapper.OnServer2ClientEvent);
                ChannelDetail = model;
                string client_name = Hi.Common.ChannelClass.GetMyHostName();
                _IHiCoordinator.IClient2Server(client_name + "成功连接服务");
                return true;
            }
            catch (Exception ex)
            {
                MsgBox.ShowInformation("启动服务失败:" + ex.Message + "\n\n" + uri);
                return false;
            }
        }
        private static string GetServerUrl(string protocol, ChannelModel model)
        {
            return string.Format("{0}://{1}:{2}/{3}", protocol, model.Ip, model.Port, model.CoordinatorName);
        }
        private static void GetServerMessage(string msg)
        {
            _MessageInfo = msg;
        }
        #endregion

        /// <summary>
        /// 实例化用户类
        /// </summary>
        /// <returns></returns>
        public static Hi.BLL.User UserBLL()
        {
            if (ClientType == "1")
                return GetInstance().UserBLL();
            else
                return new BLL.User();
        }
        public static Hi.BLL.SysAdmin SysAdminBLL()
        {
            return new BLL.SysAdmin();
        }
        public static Hi.BLL.OrgBLL BasOrgBLL()
        {
            return new BLL.OrgBLL();
        }

        public static Hi.BLL.TrailBll TrailBLL()
        {
            return new BLL.TrailBll();
        }

        public static Hi.BLL.DataAuto DataAutoBLL()
        {
            return new BLL.DataAuto();
        }
    }
}
