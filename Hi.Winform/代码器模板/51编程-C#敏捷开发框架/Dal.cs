using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Hi.IDAL;
using Hi.Model;

namespace Hi.DAL.MsSql
{
    /// <summary>
    /// 数据访问类$ClassName$。
    /// </summary>
    public class $ClassName$DAL : I$ClassName$
    {
        public $ClassName$DAL()
        { }
        #region 成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strWhere)
        {
            string strSql = " select count(*) from $TableName$ where 1=1 " + strWhere;
            string strValue=DataBase.ExecuteScalarToStr(strSql);
            return int.Parse(strValue)>0?true:false;

        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add($ClassName$ model)
        { 
            $Add$
            return DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update($ClassName$ model)
        {
            $Update$
            return DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {
            string strSql = "delete from $TableName$ where $KeyName$ =" + id;
            
            return DataBase.ExecuteNonQuery(strSql) > 0 ? true : false;
        }

		 /// <summary>
		/// 得到一个对象实体
		/// </summary>
		public  $ClassName$ Detail(string id)
		{
		   Hi.Model.$ClassName$ model = new Hi.Model.$ClassName$();
		   string strSql=" select * from $TableName$ where $KeyName$="+id;
		   DataRow dr = DataBase.ExecuteDataRow(strSql);
           if (dr == null)
                return null;
            $Detail$
           
            dr.Close();
		   
		   return model;
		}
		 /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet List(Dictionary<string ,string> dict,int pageIndex, int pageSize,string sort)
        {
            string strSql = StringSql(dict);
            if(!string.IsNullOrEmpty(sort))
            	strSql+=" order by "+sort;
            return DataBase.ExecuteDataSet(strSql,pageIndex, pageSize);
        }
        
        /// <summary>
		/// 获得数据总记录数
		/// </summary>
		public  int TotalCount(Dictionary<string ,string> dict)
		{
		   string strSql= "select count(*) from ("+StringSql(dict)+") a" ; 
		   return   int.Parse(DataBase.ExecuteScalarToStr(strSql ) );
		}
		
		private string StringSql(Dictionary<string,string> dict)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append(" select * from $TableName$ where 1=1 ");
            return strb.ToString();
        }
		#endregion 
    }
}




















