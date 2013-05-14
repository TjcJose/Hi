using System;
using System.Data;
using Hi.Model;
using System.Collections.Generic;
namespace Hi.IDAL
{
    /// <summary>
    /// author:dhc
    /// date:2010-12-9
    /// description:部门信息维护数据接口
    /// </summary>
   public interface IOrg
    {
        #region 信息维护
       DataSet List(Dictionary<string, string> dict, int pageindex, int pagesize);
       int TotalCount(Dictionary<string, string> dict);

        bool Add(Org model);
        bool Update(Org model);
        bool Delete(string id);
        bool Exists(string strvalue, int id);
        Org Detail(int id);
        bool IsUsing(string department_id);

        #endregion
    }
}
