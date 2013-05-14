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
    public class Log
    {

        private ILog dal = DataAccess.CreateLog();

        #region  ILog

        public int Add(BasLog model)
        {
            if (model == null)
            {
                return 0;
            }
            return dal.Add(model);
        }

        /// <summary>
        /// 删除两天以前的日志
        /// </summary>
        /// <returns></returns>
        public int DeleteLogBeforeTwoDays()
        {
            return dal.DeleteLogBeforeTwoDays();
        }

        public DataSet List(Hashtable hash, int pageIndex, int pageSize)
        {
            return dal.List(hash, pageIndex, pageSize);
        }
        /// <summary>
        /// 获得数据总记录数
        /// </summary>
        public int TotalCount(Hashtable hash)
        {
            return dal.TotalCount(hash);
        }
        #endregion

         #region 异常SQL日志
        public DataSet BasLogSqlList(Hashtable hash, int pageIndex, int pageSize)
        {
            return dal.BasLogSqlList(hash, pageIndex, pageSize);
        }
        /// <summary>
        /// 获得数据总记录数
        /// </summary>
        public int BasLogSqlTotalCount(Hashtable hash)
        {
            return dal.BasLogSqlTotalCount(hash);
        }
        public int DeleteBasLogSql(string id)
        {
            return dal.DeleteBasLogSql(id);
        }
        #endregion
    }
}
