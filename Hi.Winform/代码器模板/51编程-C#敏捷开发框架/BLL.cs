using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;

using Hi.Common;
using Hi.DALFactory;
using Hi.IDAL;
using Hi.Model;

namespace Hi.BLL
{
    /// <summary>
    /// 业务逻辑类$TableName$ 的摘要说明。
    /// </summary>
    public class $ClassName$BLL
    {
        private readonly I$ClassName$ dal = DataAccess.Create$ClassName$();

        public $ClassName$()
        { }
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strwhere)
        {
            return dal.Exists(strwhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add($ClassName$ model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update($ClassName$ model)
        {
            return dal.Update(model);
        }

       
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {
           return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public $ClassName$ Detail(string id)
        {
            return dal.Detail(id);
        }

        public DataSet List(Dictionary<string, string> dict,int pageIndex, int pageSize ,string sort)
        {
            return dal.List(dict,pageIndex,  pageSize,sort);
        }
        /// <summary>
		/// 获得数据总记录数
		/// </summary>
		public  int TotalCount(Dictionary<string, string> dict)
		{
		     return dal.TotalCount(dict);
		}
        #endregion  成员方法
    }
}














