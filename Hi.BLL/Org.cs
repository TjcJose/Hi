using System;
using System.Collections.Generic;
using System.Collections;
using System.Data;


using Hi.DALFactory;
using Hi.IDAL;
using Hi.Model;

namespace Hi.BLL
{
    /// <summary>
    /// author:dhc
    /// date:2010-12-9
    /// description:部门信息维护业务层
    /// </summary>
    public class OrgBLL
    {
        private IOrg dal = DataAccess.CreateOrg();

        #region 单位机构维护
        public DataSet List(Dictionary<string, string> dict, int pageindex, int pagesize)
        {
            return dal.List(dict, pageindex, pagesize);
        }
        public int TotalCount(Dictionary<string, string> dict)
        {
            return dal.TotalCount(dict);
 
        }

        public bool Add(Org model)
        {
            return dal.Add(model);
 
        }
        public bool Update(Org model)
        {
            return dal.Update(model);
 
        }
        public bool Delete(string id)
        {
            return dal.Delete(id);
        }
        public bool Exists(string strvalue, int id)
        {
            return dal.Exists(strvalue, id);
        }
        //部门详细信息 Added Liangsx 2010-12-15
        public Org Detail( int id)
        {
            return dal.Detail(id);
        }
        //ID是否被引用
        public bool IsUsing(string department_id)
        {
            return dal.IsUsing(department_id);
        }
        #endregion
    }
}
