using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Hi.Common;
using Hi.Remoting.Common;
namespace Hi.Services.BLL
{
    public class HiCoordinator : MarshalByRefObject, IHiCoordinator
    {
       
        public string Test()
        {
            return Hi.Common.Db.DbUtils.ConnectionString;
        }
       
        #region 数据库对象
        public Hi.BLL.Log LogBLL()
        {
            return new Hi.BLL.Log();
        }
        public Hi.BLL.OrgBLL DepartmentBLL()
        {
            return new Hi.BLL.OrgBLL();
        }
       
        public Hi.BLL.SysAdmin SysAdminBLL()
        {
            return new Hi.BLL.SysAdmin();
        }
        public Hi.BLL.User UserBLL()
        {
            return new Hi.BLL.User();
        }

        public Hi.BLL.TrailBll TrailBLL()
        {
            return new Hi.BLL.TrailBll();
        }
        #endregion 

   

        #region 服务端对客户端发广播信息
        public event IServer2ClientEventHandler Server2ClientEvent;
        //[OneWay]
        public void IServer2Client(string msg)
        {
            if (Server2ClientEvent != null)
            {
                IServer2ClientEventHandler tempEvent = null;

                int index = 1; //记录事件订阅者委托的索引，为方便标识，从1开始。
                foreach (Delegate del in Server2ClientEvent.GetInvocationList())
                {
                    try
                    {
                        tempEvent = (IServer2ClientEventHandler)del;
                        tempEvent(msg);
                    }
                    catch
                    {
                        //MsgBox.ShowError("事件订阅者" + index.ToString() + "发生错误,系统将取消事件订阅!");
                        Server2ClientEvent -= tempEvent;
                    }
                    index++;
                }
            }
            else
            {
                //MsgBox.ShowError("事件未被订阅或订阅发生错误!");
            }
        }

        #endregion

        #region 客户发送传真内容
        public static event Client2ServerEventHandler Client2ServerEvent;
        public void IClient2Server(string msg)
        {
            if (Client2ServerEvent != null)
            {
                Client2ServerEvent(msg);
            }
        }
        #endregion 

        //重写远程对象的生命周期为无限大
        public override object InitializeLifetimeService()
        {
            return null;
        }

    }
}
