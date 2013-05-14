using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;

using Hi.Model;
namespace Hi.IDAL
{
    /// <summary>
    /// 接口层I$ClassName$ 的摘要说明。
    /// </summary>
    public interface I$ClassName$
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string strwhere);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add($ClassName$ model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update($ClassName$ model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        $ClassName$ Detail(string id);
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet List(Dictionary<string, string> dict,int pageIndex, int pageSize,string sort);
         /// <summary>
		/// 获得数据总记录数
		/// </summary>
		int TotalCount(Dictionary<string, string> dict);
        #endregion  成员方法
    }
}











