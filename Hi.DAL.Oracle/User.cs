using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using System.Collections;
//using System.Data.OracleClient;
using Hi.IDAL;
using Hi.Model;

namespace Hi.DAL.Oracle
{
    [Serializable]
    public class User : IUser
    {

        // Methods
        public User()
        {

        }
        public bool Exists(string strWhere)
        {
            string strSql = " select count(*) from bas_user where 1=1 " + strWhere;
            string strValue = DataBase.ExecuteScalarToStr(strSql);
            return int.Parse(strValue) > 0 ? true : false;

        }
        public bool Add(BasUser model)
        {
            if (model == null)
            {
                return false;
            }
            StringBuilder strb = new StringBuilder();
            strb.Append(" Insert Into bas_user ");
            strb.Append(" ( ");
            //strb.Append("userid, ");//主键是自动增长列，请屏蔽赋值
            strb.Append("orgid, ");
            strb.Append("orgname,");
            strb.Append("usercode, ");
            strb.Append("userpassword, ");
            strb.Append("realname, ");

            strb.Append("sex, ");
            strb.Append("usertelephone, ");
            strb.Append("email, ");
            strb.Append("qq, ");
            strb.Append("regtime, ");
            strb.Append("address, ");
            strb.Append("islocked, ");
            // strb.Append("lastloginip, ");
            // strb.Append("logintimes, ");
            // strb.Append("lastlogintime, ");
            strb.Append("remark ");
            strb.Append(" )");
            strb.Append(" Values( ");
            //strb.Append("'" + model.Userid + "', ");
            strb.Append("" + Hi.Common.Utils.IsNull(model.OrgId, "0") + ", ");
            strb.Append("'" + model.OrgName + "', ");
            strb.Append("'" + model.UserCode + "', ");
            strb.Append("'" + model.UserPassword + "', ");
            strb.Append("'" + model.RealName + "', ");

            strb.Append("'" + model.Sex + "', ");
            strb.Append("'" + model.UserTelephone + "', ");
            strb.Append("'" + model.Email + "', ");
            strb.Append("'" + model.Qq + "', ");
            strb.Append("'" + model.Regtime + "', ");
            strb.Append("'" + model.Address + "', ");
            strb.Append("" + model.IsLocked + ", ");
            //strb.Append("'" + model.Lastloginip + "', ");
            // strb.Append("" + model.Logintimes + ", ");
            // strb.Append("'" + model.Lastlogintime + "', ");
            strb.Append("'" + model.Remark + "' ");
            strb.Append(" )");
            try
            {
                return DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 更新用户操作权限
        /// </summary>
        /// <param name="user_id"></param>
        /// <param name="strPurview"></param>
        /// <returns></returns>
        public bool UpdatePurview(string user_id, string strPurview)
        {
            string strSql = "update bas_user set purview='" + strPurview + "' where userid=" + user_id;
            return DataBase.ExecuteNonQuery(strSql) > 0 ? true : false;
        }
        public bool UpdatePurview(string user_id, string module_code, string strPurview)
        {
            string strSql = "update bas_user set " + module_code + "='" + strPurview + "' where userid=" + user_id;
            return DataBase.ExecuteNonQuery(strSql) > 0 ? true : false;
        }

        //屏蔽注册、登录时间 Edited By Liangsx 2011-01-24
        public bool Update(BasUser model)
        {
            bool blFlag;
            try
            {
                StringBuilder strb = new StringBuilder();
                strb.Append(" Update bas_user ");
                strb.Append(" Set ");
                strb.Append("orgid   = " + Hi.Common.Utils.IsNull(model.OrgId, "0") + ",");
                strb.Append("orgname = '" + model.OrgName + "',");
                strb.Append("usercode       = '" + model.UserCode + "',");
                //strb.Append("userpassword   = '" + model.UserPassword + "',");
                strb.Append("realname       = '" + model.RealName + "',");

                strb.Append("sex            = '" + model.Sex + "',");
                strb.Append("usertelephone  = '" + model.UserTelephone + "',");
                strb.Append("email          = '" + model.Email + "',");
                strb.Append("qq             = '" + model.Qq + "',");
                //strb.Append("regtime        = '" + model.Regtime + "',");
                strb.Append("address        = '" + model.Address + "',");
                strb.Append("IsLocked       = " + model.IsLocked + ",");
                //strb.Append("lastloginip    = '" + model.Lastloginip + "',");
                //strb.Append("logintimes     = " + model.Logintimes + ",");
                //strb.Append("lastlogintime  = '" + model.Lastlogintime + "',");
                strb.Append("remark         = '" + model.Remark + "'");
                strb.Append(" where userid = " + model.UserId.ToString());
                blFlag = DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return blFlag;
        }
        public bool UpdateLogin(BasUser model)
        {

            try
            {
                StringBuilder strb = new StringBuilder();
                strb.Append(" Update bas_user ");
                strb.Append(" Set ");
                strb.Append("lastloginip    = '" + model.LastLoginIp + "',");
                strb.Append("logintimes     = " + model.LoginTimes + ",");
                strb.Append("lastlogintime  = '" + model.LastLoginTime + "'");

                strb.Append(" where userid = " + model.UserId.ToString());
                DataBase.ExecuteNonQuery(strb.ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// 重设密码
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="newPassword">新密码</param>
        /// <returns></returns>
        public bool ResetPassword(string UserID, string newPassword)
        {

            try
            {
                StringBuilder strb = new StringBuilder();
                strb.Append(" Update bas_user ");
                strb.Append(" Set ");

                strb.Append("userpassword   = '" + newPassword + "'");

                strb.Append(" where userid = " + UserID);
                DataBase.ExecuteNonQuery(strb.ToString());
            }
            catch
            {
                return false;
            }
            return true;
        }

        public bool Delete(string user_id)
        {
            return DataBase.ExecuteNonQuery("select from bas_user where userid=" + user_id) > 0 ? true : false;
        }
        #region 详细
        private DataRow DetailFromCode(string user_code)
        {
            string strSql = "select * from bas_user where  user_code = '" + user_code + "'";
            DataRow dr = DataBase.ExecuteDataRow(strSql);
            return dr;
        }
        private DataRow DetailFromId(string id)
        {
            string strSql = "select * from bas_user where  user_id = " + id + "";
            DataRow dr = DataBase.ExecuteDataRow(strSql);
            return dr;
        }
        public BasUser Detail(string id)
        {
            DataRow dr = null;
            if (Hi.Common.Utils.StrToInt(id) > 0)
                dr = DetailFromId(id);
            else
                dr = DetailFromCode(id);
            if (dr == null)
                return null;
            BasUser model = new BasUser();

            model.UserId = dr["user_id"].ToString().Trim();
            model.OrgId = dr["user_orgid"].ToString().Trim();
            model.OrgName = "";//dr["orgname"].ToString().Trim();
            model.UserCode = dr["user_code"].ToString().Trim();
            model.UserPassword = dr["user_password"].ToString().Trim();
            model.RealName = dr["user_name"].ToString().Trim();
            model.RoleId = dr["user_role"].ToString().Trim();
            //model.Sex = dr["sex"].ToString().Trim();
            //model.UserTelephone = dr["usertelephone"].ToString().Trim();
            //model.Email = dr["email"].ToString().Trim();
            //model.Qq = dr["qq"].ToString().Trim();
            //model.Regtime = dr["regtime"].ToString().Trim();
            //model.Address = dr["address"].ToString().Trim();
            //model.IsLocked = dr["islocked"].ToString().Trim();
            //model.LastLoginIp = dr["lastloginip"].ToString().Trim();
            //model.LoginTimes = dr["logintimes"].ToString().Trim();
            //model.LastLoginTime = dr["lastlogintime"].ToString().Trim();
            //model.Remark = dr["remark"].ToString().Trim();
            //model.Purview = dr["purview"].ToString().Trim();
            //model.PurviewDetail = dr["purview_detail"].ToString().Trim();

            return model;
        }
        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public DataSet List(Dictionary<string, string> dict, int pageIndex, int pageSize, string sort)
        {

            string strSql = GetSql(dict);
            return DataBase.ExecuteDataSet(strSql, pageIndex, pageSize);
        }

        /// <summary>
        /// 获得数据总记录数
        /// </summary>
        public int TotalCount(Dictionary<string, string> dict)
        {
            string strSql = "select count(*) from (" + GetSql(dict) + ") t ";
            return int.Parse(DataBase.ExecuteScalarToStr(strSql));
        }

        /// <summary>
        /// 获得列表SQL
        /// </summary>
        private string GetSql(Dictionary<string, string> dict)
        {

            StringBuilder strb = new StringBuilder();

            strb.Append(" select t.* ");

            strb.Append(" from bas_user t where 1=1");

            //单位名称
            string dep_name = DataBase.GetDictionaryValue(dict, "orgname");

            if (!string.IsNullOrEmpty(dep_name))
            {
                strb.Append(" and org_name like '%" + dep_name + "%'");
            }

            //姓名
            string user_name = DataBase.GetDictionaryValue(dict, "orgname");
            if (!string.IsNullOrEmpty(user_name))
            {
                strb.Append(" and Realname like '%" + user_name + "%'");
            }
            return strb.ToString();
        }
    }
}
