using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Collections;

using Hi.IDAL;
using Hi.Model;


namespace Hi.DAL.Oracle
{
    [Serializable]
    public class Log : ILog
    {
       
        private string tableName = "bas_Log";

        // Methods
        public Log()
        {
            
        }

        public int Add(BasLog model)
        {
           
            try
            {
                return DataBase.ExecuteNonQuery("");
            }
            catch
            {
                return -1;
            }
        }

        
        public int DeleteLogBeforeTwoDays()
        {
            return this.Delete("  datediff(d,logtime,getdate()) > 2 ");
        }

        public int Delete(string filter)
        {
            int num = -1;
            string sql = "delete from " + this.tableName;
            if (!string.IsNullOrEmpty(filter.Trim()))
            {
                sql = sql + "  where  " + filter;
            }
            try
            {
                num = DataBase.ExecuteNonQuery(sql);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        #region 用户日记
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet List(Hashtable hash, int pageIndex, int pageSize)
        {

            string strSql = Hi.Common.Db.DbUtils.WebPageSql(GetSql(hash), pageIndex, pageSize);
            return DataBase.ExecuteDataSet(strSql,pageIndex,pageSize);
        }

        /// <summary>
        /// 获得数据总记录数
        /// </summary>
        public int TotalCount(Hashtable hash)
        {
            string strSql = "select count(*) from ("+GetSql( hash )+") a ";
            return int.Parse(DataBase.ExecuteScalarToStr(strSql));
        }
        private string GetSql(Hashtable hash)
        {

            StringBuilder strb = new StringBuilder();
            strb.Append("select LogID,LogType,convert(varchar, LogTime, 120 ) as LogTime,UserName,UserIP,");
            strb.Append("LogContent,ScriptName,PostString,");
            strb.Append(Hi.Common.Db.DbUtils.GetPageRowNum("logid"));
            strb.Append(" from bas_log t   ");
            return strb.ToString();
        }
        #endregion 

        #region 异常SQL日志
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet BasLogSqlList(Hashtable hash, int pageIndex, int pageSize)
        {

            string strSql = Hi.Common.Db.DbUtils.WebPageSql(GetBasLogSql(hash), pageIndex, pageSize);
            strSql += " order by id desc ";
            return DataBase.ExecuteDataSet(strSql,pageIndex,pageSize);
        }

        /// <summary>
        /// 获得数据总记录数
        /// </summary>
        public int BasLogSqlTotalCount(Hashtable hash)
        {
            string strSql = "select count(*) from (" + GetBasLogSql(hash) + ") t ";
            return int.Parse(DataBase.ExecuteScalarToStr(strSql));
        }
        private string GetBasLogSql(Hashtable hash)
        {

            StringBuilder strb = new StringBuilder();
            strb.Append("select id,remark,convert(varchar,create_date,120) as create_date,");
            strb.Append(Hi.Common.Db.DbUtils.GetPageRowNum("id"));
            strb.Append(" from bas_log_sql t  ");
            return strb.ToString();
        }

        public int DeleteBasLogSql(string id)
        {
            int num = -1;
            string sql = "delete from bas_log_sql where id="+id ;
           
            try
            {
                num = DataBase.ExecuteNonQuery(sql);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return num;
        }

        #endregion 
    }
}
