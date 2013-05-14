using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using Hi.IDAL;
using Hi.Model;


namespace Hi.DAL.Access
{
    /// <summary>
    /// author:dhc
    /// date:2010-12-9
    /// description:部门信息维护接口实现
    /// </summary>
    [Serializable]
    public class OrgDAL : IOrg
    {
        //methods
        public OrgDAL() { }

        private string DepartmentSql(Dictionary<string, string> dict)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append("select t.* from bas_org t");
            strb.Append(" where 1=1 ");


            //名称
            string dep_name = DataBase.GetDictionaryValue(dict, "org_name");
            if (!string.IsNullOrEmpty(dep_name))
            {
                strb.Append(" and org_name like '%" + dep_name + "%'");
            }


            return strb.ToString();
        }

        public DataSet List(Dictionary<string, string> dict, int pageindex, int pagesize)
        {
            string strSql = DepartmentSql(dict);
            DataSet ds = new DataSet();
            try
            {
                ds = DataBase.ExecuteDataSet(strSql, pageindex, pagesize);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }

        public int TotalCount(Dictionary<string, string> hash)
        {
            try
            {
                string strSql = " select count(*) from (" + DepartmentSql(hash) + ") a ";
                return int.Parse(DataBase.ExecuteScalarToStr(strSql).ToString());
            }
            catch
            {
                return 0;
            }
        }

        public bool Add(Org model)
        {
            if (model == null)
                return false;
            StringBuilder strb = new StringBuilder();
            strb.Append(" Insert Into bas_org ");
            strb.Append(" ( ");
            //strb.Append("id, ");
            strb.Append("org_name, ");
            strb.Append("link_name, ");
            strb.Append("link_tel, ");
            strb.Append("link_mobile ");
            strb.Append(" )");
            strb.Append(" Values( ");
            //strb.Append("" + model.Id + ", ");
            strb.Append("'" + model.OrgName + "', ");
            strb.Append("'" + model.LinkName + "', ");
            strb.Append("'" + model.LinkTel + "', ");
            strb.Append("'" + model.LinkMobile + "' ");
            strb.Append(" )");

            return DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;

        }
        public bool Update(Org model)
        {

            StringBuilder strb = new StringBuilder();
            strb.Append(" Update bas_org ");
            strb.Append(" Set ");
            //strb.Append("id               = " + model.Id + ",");
            strb.Append("org_name  = '" + model.OrgName + "',");
            strb.Append("link_name        = '" + model.LinkName + "',");
            strb.Append("link_tel         = '" + model.LinkTel + "',");
            strb.Append("link_mobile      = '" + model.LinkMobile + "'");
            strb.Append(" where id = " + model.Id);

            return DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;

        }
        public bool Delete(string id)
        {
            bool blFlag = false;
            int num = -1;
            string sql = "delete from bas_org where id=" + id;
            string count = DataBase.ExecuteScalarToStr("select count(*) from bas_user where orgid=" + id);
            if (Hi.Common.Utils.StrToInt(count) > 0)
                return false;

            try
            {
                num = DataBase.ExecuteNonQuery(sql);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            blFlag = (num > 0 ? true : false);
            return blFlag;

        }
        public bool Exists(string strvalue, int id)
        {
            bool blFlag = false;
            int num = -1;
            string strSql = "select count(*) from bas_org where org_name='{0}' {1} ";
            if (id < 1)
                strSql = string.Format(strSql, strvalue, "");
            else
                strSql = string.Format(strSql, strvalue, " and id <>" + id.ToString());
            try
            {
                num = int.Parse(DataBase.ExecuteScalarToStr(strSql).ToString());
            }
            catch (Exception exception)
            {
                throw exception;
            }
            blFlag = (num > 0 ? true : false);
            return blFlag;
        }
        //部门详细信息 Added Liangsx 2010-12-15
        public Org Detail(int id)
        {
            string strSql = "select * from bas_org where  id = " + id.ToString();
            Org model = new Org();
            DataRow dr = DataBase.ExecuteDataRow(strSql);
            model.Id = int.Parse(dr["id"].ToString());
            model.OrgName = dr["org_name"].ToString().Trim();
            model.LinkName = dr["link_name"].ToString().Trim();
            model.LinkTel = dr["link_tel"].ToString().Trim();
            model.LinkMobile = dr["link_mobile"].ToString().Trim();


            return model;
        }

        //ID是否被引用
        public bool IsUsing(string id)
        {
            string strValue = "";
            string strSql = "";
            strSql = "select count(*) from bas_user where orgid=" + id;
            strValue = DataBase.ExecuteScalarToStr(strSql);
            if (int.Parse(strValue) > 0)
                return true;
            else
                return false;
        }
    }
}
