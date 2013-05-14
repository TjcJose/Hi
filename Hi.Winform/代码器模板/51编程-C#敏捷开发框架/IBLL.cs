using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;

using Hi.Common;
using Hi.DALFactory;
using Hi.IDAL;
using Hi.Model;

namespace Hi.IBLL
{
    /// <summary>
    /// 扩展业务逻辑类$TableName$ 的摘要说明。
    /// </summary>
    public class HiInstanceBLL
    {
       private static string ClientType = ConfigurationManager.AppSettings["ClientType"];
       /// <summary>
       /// 实例化$TableRemark$
       /// </summary>
       /// <returns></returns>
	   public  static Hi.BLL.$ClassName$ $ClassName$BLL()
       {
            return new Hi.BLL.$ClassName$();
       }
    }
}














