using System;
using System.Collections.Generic;
using System.Data;
using System.Collections;

using Hi.Common;
using Hi.DALFactory;
using Hi.IDAL;
using Hi.Model;

namespace Hi.BLL
{
    public class DataQuery
    {

        private IDataQuery dal = DataAccess.CreateDataQuery();

         #region 查询
        public DataSet List(Dictionary<string,string> dict, int pageIndex, int pageSize,string sort)
        {
            return dal.List(dict, pageIndex, pageSize);
        }
        /// <summary>
        /// 获得数据总记录数
        /// </summary>
        public int TotalCount(Dictionary<string,string> dict)
        {
            return dal.TotalCount(dict);
        }
      
        #endregion
    }
}
