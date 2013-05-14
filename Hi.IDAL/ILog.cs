using System;
using System.Data;
using System.Collections;

using Hi.Model;
namespace Hi.IDAL
{
    public interface ILog
    {
        int Add(BasLog model);
        int DeleteLogBeforeTwoDays();
        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet List(Hashtable hash, int pageIndex, int pageSize);
        /// <summary>
        /// 获得数据总记录数
        /// </summary>
        int TotalCount(Hashtable hash);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet BasLogSqlList(Hashtable hash, int pageIndex, int pageSize);
        /// <summary>
        /// 获得数据总记录数
        /// </summary>
        int BasLogSqlTotalCount(Hashtable hash);
        int DeleteBasLogSql(string id);
    }
}
