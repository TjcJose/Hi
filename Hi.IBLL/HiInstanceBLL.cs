using System;
using System.Configuration;

using Hi.Common;
using Hi.Remoting.Common;
namespace Hi.IBLL
{
    public class HiInstanceBll
    {
        private static readonly string ClientType = ConfigurationManager.AppSettings["ClientType"];

        #region Remoting对象
        private static IHiCoordinator _iHiCoordinator;
        private static EventWrapper _wrapper;
        public static string MessageInfo = null;
        public static ChannelModel ChannelDetail { get; set; }
        public static IHiCoordinator GetInstance()
        {
            try
            {
                if (ChannelDetail == null)
                    return null;
                if (_iHiCoordinator == null)
                    MsgBox.ShowInformation(ChannelDetail.Ip + "服务可能已经停止!");

                return _iHiCoordinator;
            }
            catch (Exception ex)
            {
                if (ChannelDetail != null) 
                    MsgBox.ShowInformation("请确保已成功连接" + ChannelDetail.Ip + ":" + ex.Message);
                return null;
            }
        }
        public static void SetDisConnection()
        {
            _iHiCoordinator = null;
        }
        public static bool ConnectionServer(ChannelModel model)
        {
            //获取远程对象
            var channelGroup = model.ChannelGroupType == "1" ? ChannelGroup.TCP : ChannelGroup.HTTP;
            string protocol = "tcp";
            if (channelGroup == ChannelGroup.HTTP) protocol = "http";
            string uri = GetServerUrl(protocol, model);
            try
            {
                ChannelClass.StartChannel(channelGroup, model.ChannelName);
                _iHiCoordinator = Activator.GetObject(typeof(IHiCoordinator), uri) as IHiCoordinator;

                _wrapper = new EventWrapper();
                _wrapper.Server2ClientEvent += GetServerMessage;
                if (_iHiCoordinator != null)
                    _iHiCoordinator.Server2ClientEvent += _wrapper.OnServer2ClientEvent;
                ChannelDetail = model;
                string clientName = ChannelClass.GetMyHostName();
                if (_iHiCoordinator != null) 
                    _iHiCoordinator.IClient2Server(clientName + "成功连接服务");
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
            MessageInfo = msg;
        }
        #endregion

        /// <summary>
        /// 实例化用户类
        /// </summary>
        /// <returns></returns>
        public static BLL.User UserBll()
        {
            if (ClientType == "1")
                return GetInstance().UserBLL();
            return new BLL.User();
        }

        public static BLL.SysAdmin SysAdminBll()
        {
            return new BLL.SysAdmin();
        }
        public static BLL.OrgBLL BasOrgBll()
        {
            return new BLL.OrgBLL();
        }

        public static BLL.TrailBll TrailBll()
        {
            return new BLL.TrailBll();
        }

        /// <summary>
        /// 实例化自动数据类
        /// </summary>
        /// <returns></returns>
        public static BLL.DataAuto DataAutoBll()
        {
            return new BLL.DataAuto();
        }

        /// <summary>
        /// 实例化手动数据类
        /// </summary>
        /// <returns></returns>
        public static BLL.DataHand DataHandBll()
        {
            return new BLL.DataHand();
        }
    }
}
