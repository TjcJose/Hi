using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Remoting;

namespace Hi.Remoting.Common
{
    /// <summary>
    /// 服务端对客户端发广播信息
    /// </summary>
    /// <param name="str"></param>
    public delegate void IServer2ClientEventHandler(string msg);
    /// <summary>
    /// 客户端对服务端发传真信息
    /// </summary>
    /// <param name="str"></param>
    public delegate void Client2ServerEventHandler(string msg);
    /// <summary>
    /// Remoting公共类
    /// </summary>
    public interface IHiCoordinator
    {
        event IServer2ClientEventHandler Server2ClientEvent;
        string Test();
        void IServer2Client(string msg);
        void IClient2Server(string msg);
        //void SetDbConfig();
        //string GetPrintXml(string xml_file);

      

        Hi.BLL.Log LogBLL();
        Hi.BLL.OrgBLL DepartmentBLL();
       
        Hi.BLL.User UserBLL();
        Hi.BLL.SysAdmin SysAdminBLL();
        Hi.BLL.TrailBll TrailBLL();
    }
}