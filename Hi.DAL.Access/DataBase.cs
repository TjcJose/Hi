using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Configuration;
using System.Data.Common;

//using System.Windows.Forms;

using Hi.Common;
namespace Hi.DAL.Access
{
     [Serializable]
    public class DataBase
    {
        private static DbHelper GetDbHelper
        {
            get
            {
                ////if (!string.IsNullOrEmpty(Hi.Common.Db.DbUtils.ConnectionString) && !string.IsNullOrEmpty(Hi.Common.Db.DbUtils.ProviderName))
                ////{
                //    string connStr = string.Format(ConfigurationManager.AppSettings["AccessConnectionString"], Application.StartupPath);
                //    Hi.Common.Db.DbUtils.ConnectionString = connStr;
                //    Hi.Common.Db.DbUtils.ProviderName = ConfigurationManager.AppSettings["AccessProvider"];
                ////}
               // SetDbConfig();
                DbHelper dbheler = new DbHelper(Hi.Common.Db.DbUtils.ConnectionString, Hi.Common.Db.DbUtils.ProviderName);
                return dbheler;
            }
        }
        private static void SetDbConfig()
        {
            //Hi.Common.DbConfig tmpDbConfig;
            //string dbFile = Application.StartupPath + "\\Config\\Config.dat";
            //tmpDbConfig = Hi.Common.Db.DbUtils.LoadFromBinaryFile(dbFile);
            
            //if (tmpDbConfig != null)
            //{
            //    Hi.Common.Db.DbUtils.ConnectionString = tmpDbConfig.ConnectionString;
            //    Hi.Common.Db.DbUtils.ProviderName = tmpDbConfig.DbProviderName;
                
            //}
            //else
            //{
            //    MsgBox.ShowInformation("连接数据库失败!请联系技术员协助");
                
            //}
        }
        /// <summary>
        /// 获取单表记录最大值
        /// 主键为ID
        /// </summary>
        /// <param name="table_name"></param>
        /// <param name="mincode"></param>
        /// <returns></returns>
        public static string GetMaxCode(string table_name,string mincode)
        {
            int intResult = Hi.Common.Utils.StrToInt(ExecuteScalarToStr("select max(id) from "+table_name))+1;
            string temp = mincode;

            return temp.Substring(0, mincode.Length - intResult.ToString().Length) + intResult.ToString(); 
        }
        public static string GetMaxCode(string table_name, string key_column_name,string mincode)
        {
            int intResult = Hi.Common.Utils.StrToInt(ExecuteScalarToStr("select max(" + key_column_name + ") from " + table_name)) + 1;
            string temp = mincode;

            return temp.Substring(0, mincode.Length - intResult.ToString().Length) + intResult.ToString();
        }
        /// <summary>
        /// 执行Sql 返回DataTable
        /// </summary>
        /// <param name="inSQL">Sql语句</param>
        /// <returns>DataTable</returns>
        public static DataTable ExecuteDataTable(string strSql, int pageIndex, int pageSize)
        {
            return GetDbHelper.ExecuteDataTable(strSql, pageIndex, pageSize);
        }
        public static DataSet ExecuteDataSet(string strSql, int pageIndex, int pageSize)
        {
            return GetDbHelper.ExecuteDataSet(strSql, pageIndex, pageSize);
        }
        public static DataSet ExecuteDataSet(string strSql)
        {
            return GetDbHelper.ExecuteDataSet(strSql);
        }
        public static bool Transaction(string[] strSql)
        {
            return GetDbHelper.TransSql(strSql);
        }
        /// <summary>
        /// 获取第一行第一列 方法
        /// </summary>
        /// <param name="inSQL">Sql语句</param>
        /// <returns>第一行第一列值</returns>
        public static string ExecuteScalarToStr(string strSql)
        {
            return GetDbHelper.GetScalar(strSql);
        }
        public static int ExecuteNonQuery(string StrSql)
        {
            return GetDbHelper.ExecuteNonQuery(StrSql);
        }
        public static DbCommand GetDbCommand()
        {
            return GetDbHelper.GetDbCommand();
        }
        public static int ExecuteNonQuery(string StrSql,DbParameter param)
        {
            return GetDbHelper.ExecuteNonQuery(StrSql, param);
        }
        public static int ExecuteStoredProcedure(string pro_name)
        {
            return GetDbHelper.ExecuteStoredProcedure(pro_name);
        }

        public static DataRow ExecuteDataRow(string strSql)
        {
            DataSet ds = GetDbHelper.ExecuteDataSet(strSql);
            if(ds==null || ds.Tables.Count==0 || ds.Tables[0].Rows.Count==0)
                return null;
            else
                return ds.Tables[0].Rows[0];
        }

        public static string GetDictionaryValue(Dictionary<string,string> dict,string keyName)
        {
            string strValue=string.Empty;
            if (dict.ContainsKey(keyName))
                strValue = dict[keyName];
            return strValue;
               
        }
       
    }
}
