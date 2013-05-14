using System;
using System.Data;
using System.Collections.Generic;

using Hi.Model;

namespace Hi.IDAL
{
    public interface IUser
    {
        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool Exists(string strwhere);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool Add(BasUser model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(BasUser model);
        bool UpdateLogin(BasUser model);
        bool UpdatePurview(string user_id, string strPurview);
        bool UpdatePurview(string user_id, string module_code, string strPurview);
        bool ResetPassword(string UserID, string newsPassword);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(string id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        BasUser Detail(string id);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet List(Dictionary<string, string> dict, int pageIndex, int pageSize, string sort);
        /// <summary>
        /// 获得数据总记录数
        /// </summary>
        int TotalCount(Dictionary<string, string> dict);
        #endregion  成员方法
    }
}
