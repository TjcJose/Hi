using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

using Hi.Common;
using Hi.IDAL;
namespace Hi.DAL.Access
{
    public class DataQuery
    {
        private string Sql(Dictionary<string, string> dict)
        {
            StringBuilder strb = new StringBuilder();
            string table_name = DataBase.GetDictionaryValue(dict,"table_name");
            strb.Append("select * from " + table_name + " t");
            strb.Append(" where 1=1 ");

            return strb.ToString();
        }

        public DataSet List(Dictionary<string, string> dict, int pageindex, int pagesize)
        {
            string strSql = Hi.Common.Db.DbUtils.WebPageSql(Sql(dict), pageindex, pagesize);
            DataSet ds = new DataSet();
            try
            {
                ds = DataBase.ExecuteDataSet(strSql);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int TotalCount(Dictionary<string, string> dict)
        {
            try
            {
                string strSql = " select count(*) from (" + Sql(dict) + ") a ";
                return int.Parse(DataBase.ExecuteScalarToStr(strSql).ToString());
            }
            catch
            {
                return 0;
            }
        }
    }
}
