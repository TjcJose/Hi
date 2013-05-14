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
    public class SysAdmin : ISysAdmin
    {

        // Methods
        public SysAdmin()
        {

        }
        #region 系统参数
        /// <summary>
        /// 查询系统所有参数
        /// </summary>
        /// <returns></returns>
        public DataSet ParamList()
        {
            string strSql = @"select (select title from bas_param where id=a.parent_id) ptitle,(select code from bas_param where id=a.parent_id) pcode,a.* from bas_param a  ";
            strSql += " where 1=1 ";
            
            strSql += " order by id desc ";
            DataSet ds = new DataSet();
            try
            {
                ds = DataBase.ExecuteDataSet(strSql, 1, 1000);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        #region 分页列表
        public DataSet ParamList(Dictionary<string, string> dict,int pageindex,int pagesize,string sort)
        {
            string strSql = StringSql(dict);

            strSql += " order by id desc ";
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
        /// <summary>
        /// 获得数据总记录数
        /// </summary>
        public int ParamTotalCount(Dictionary<string, string> dict)
        {
            string strSql = "select count(*) from (" + StringSql(dict) + ") a";
            return int.Parse(DataBase.ExecuteScalarToStr(strSql));
        }
        private string StringSql(Dictionary<string, string> dict)
        {
            string strSql = @"select (select title from bas_param where id=a.parent_id) ptitle,(select code from bas_param where id=a.parent_id) pcode,a.* from bas_param a  ";
            strSql += " where 1=1 ";

            
            return strSql;
        }
        #endregion 

        /// <summary>
        /// 查询系统参数
        /// </summary>
        /// <param name="parent_type">0 一级参数 1 二级参数</param>
        /// <returns></returns>
        public DataSet ParamList(int parent_type)
        {
            string strSql = @"select (select title from bas_param where id=a.parent_id) ptitle,a.* from bas_param a  ";
            strSql += " where 1=1 ";
            if (parent_type > 0)
                strSql += " and parent_id =" + parent_type.ToString();
            else
                strSql += " and parent_id=0";
            strSql += " order by id desc ";
            DataSet ds = new DataSet();
            try
            {
                ds = DataBase.ExecuteDataSet(strSql,1,1000);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        public DataSet ParamListFromCode(string parent_code)
        {
            string strSql = @"select id,parent_id,grade,ltrim(rtrim(code)) code,title,
enumValue,remark,sort,enable_flag from bas_param where parent_id in(select id from bas_param where parent_id=0 and code ='" + parent_code.ToString() + "')";
           
            DataSet ds = new DataSet();
            try
            {
                ds = DataBase.ExecuteDataSet(strSql,1,100);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ds;
        }
        #region 新增、修改、删除
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ParamExists(string strWhere)
        {
            string strSql = " select count(*) from bas_param where 1=1 " + strWhere;
            return int.Parse(DataBase.ExecuteScalarToStr(strSql)) > 0 ? true : false;
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool ParamAdd(BasParam model)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append(" Insert Into bas_param ");
            strb.Append(" ( ");
            //strb.Append("id, ");
            strb.Append("parent_id, ");
            strb.Append("grade, ");
            strb.Append("code, ");
            strb.Append("title, ");
            //strb.Append("enumvalue, ");
            strb.Append("remark, ");
            strb.Append("sort, ");
            strb.Append("enable_flag ");
            strb.Append(" )");
            strb.Append(" Values( ");
            //strb.Append("" + model.Id + ", ");
            strb.Append("" + model.ParentId + ", ");
            strb.Append("'" + model.Grade + "', ");
            strb.Append("'" + model.Code + "', ");
            strb.Append("'" + model.Title + "', ");
           
            strb.Append("'" + model.Remark + "', ");
            strb.Append("'" + model.Sort + "', ");
            strb.Append("'" + model.EnableFlag + "' ");
            strb.Append(" )");


            return DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool ParamUpdate(BasParam model)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append(" Update bas_param ");
            strb.Append(" Set ");
            //strb.Append("id         = " + model.Id + ",");
            strb.Append("parent_id       = " + model.ParentId + ",");
            strb.Append("grade        = '" + model.Grade + "',");
            strb.Append("code         = '" + model.Code + "',");
            strb.Append("title        = '" + model.Title + "',");
            
            strb.Append("remark       = '" + model.Remark + "',");
            strb.Append("sort         = '" + model.Sort + "',");
            strb.Append("enable_flag  = '" + model.EnableFlag + "'");
            strb.Append(" where  id = " + model.Id);
            
            return DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool ParamDelete(string id)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append(" delete from bas_param where id="+id+" and enable_flag<>'2'");
            return DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;
        }
        /// <summary>
        /// 得到一个实体内容
        /// </summary>
        public BasParam ParamDetail(string id)
        {

            string strSql = "select * from bas_param where id = " + id;
            BasParam model = new BasParam();
            DataRow dr = DataBase.ExecuteDataRow(strSql);
            
                model.Id = dr["id"].ToString().Trim();
                model.ParentId = dr["parent_id"].ToString().Trim();
                model.Grade = dr["grade"].ToString().Trim();
                model.Code = dr["code"].ToString().Trim();
                model.Title = dr["title"].ToString().Trim();
               
                model.Remark = dr["remark"].ToString().Trim();
                model.Sort = dr["sort"].ToString().Trim();
                model.EnableFlag = dr["enable_flag"].ToString().Trim();

           
            return model;
        }
        #endregion

        #endregion

        #region 系统菜单维护
        #region 新增、修改、删除、重复性

        public bool BasModuleExists(string strWhere)
        {
            string strSql = " select count(*) from Bas_Module where 1=1 " + strWhere;
            string strValue = DataBase.ExecuteScalarToStr(strSql);
            return int.Parse(strValue) > 0 ? true : false;

        }

        /// <summary>
        /// 增加一条数据

        /// </summary>
        public bool BasModuleAdd(BasModule model)
        {

            StringBuilder strb = new StringBuilder();
            strb.Append(" Insert Into Bas_Module ");
            strb.Append(" ( ");
            //strb.Append("module_id, ");
            strb.Append("module_father, ");
            strb.Append("module_code, ");
            strb.Append("module_name, ");
            strb.Append("module_icon, ");
            strb.Append("module_width, ");
            strb.Append("module_height, ");
            strb.Append("module_url, ");
            strb.Append("module_sort, ");
            strb.Append("enable_flag, ");
            strb.Append("toolbar_flag, ");
            strb.Append("module_purview ");
            strb.Append(" )");
            strb.Append(" Values( ");
            //strb.Append("" + model.ModuleId + ", ");
            strb.Append("" + model.ModuleFather + ", ");
            strb.Append("'" + model.ModuleCode + "', ");
            strb.Append("'" + model.ModuleName + "', ");
            strb.Append("'" + model.ModuleIcon + "', ");
            strb.Append("" + model.ModuleWidth + ", ");
            strb.Append("" + model.ModuleHeight + ", ");
            strb.Append("'" + model.ModuleUrl + "', ");
            strb.Append("'" + model.ModuleSort + "', ");
            strb.Append("'" + model.EnableFlag + "', ");
            strb.Append("'" + model.ToolbarFlag + "', ");
            strb.Append("'" + model.ModulePurview + "' ");
            strb.Append(" )");


            return DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;
        }

        /// <summary>
        /// 更新一条数据

        /// </summary>
        public bool BasModuleUpdate(BasModule model)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append(" Update Bas_Module ");
            strb.Append(" Set ");
            //strb.Append("module_id       = " + model.ModuleId + ",");
            strb.Append("module_father   = " + model.ModuleFather + ",");
            strb.Append("module_code     = '" + model.ModuleCode + "',");
            strb.Append("module_name     = '" + model.ModuleName + "',");
            strb.Append("module_icon     = '" + model.ModuleIcon + "',");
            strb.Append("module_width    = " + model.ModuleWidth + ",");
            strb.Append("module_height   = " + model.ModuleHeight + ",");
            strb.Append("module_url      = '" + model.ModuleUrl + "',");
            strb.Append("module_sort     = '" + model.ModuleSort + "',");
            strb.Append("enable_flag     = '" + model.EnableFlag + "',");
            strb.Append("toolbar_flag    = '" + model.ToolbarFlag + "',");
            strb.Append("module_purview  = '" + model.ModulePurview + "'");
            strb.Append(" where module_id = " + model.ModuleId);

            return DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;
        }

        /// <summary>
        /// 一级菜单是否有子菜单

        /// </summary>
        public bool ExistsChild(string module_father)
        {
            int num = -1;
            bool blFlag = false;
            string strSql = "select count(*) from Bas_Module where module_father=" + module_father;
            try
            {
                num = int.Parse(DataBase.ExecuteScalarToStr(strSql));
            }
            catch (Exception e)
            {
                throw e;
            }
            blFlag = (num > 0 ? true : false);
            return blFlag;
        }
        /// <summary>
        /// 删除一条数据

        /// </summary>
        public bool BasModuleDelete(string id)
        {
            string strSql = "delete from Bas_Module where module_id =" + id + " and module_id not in (select module_id from bas_module_role ) ";

            return DataBase.ExecuteNonQuery(strSql) > 0 ? true : false;
        }
        #endregion

        /// <summary>
        /// 获得数据详细信息
        /// </summary>
        #region 获得数据详细信息
        public BasModule BasModuleDetail(string id)
        {
            BasModule model = new BasModule();
            string strSql = " select * from Bas_Module where module_id=" + id;
            DataRow dr = DataBase.ExecuteDataRow(strSql);

            
                model.ModuleId = dr["module_id"].ToString().Trim();
                model.ModuleFather = dr["module_father"].ToString().Trim();
                model.ModuleCode = dr["module_code"].ToString().Trim();
                model.ModuleName = dr["module_name"].ToString().Trim();
                model.ModuleIcon = dr["module_icon"].ToString().Trim();
                model.ModuleWidth = dr["module_width"].ToString().Trim();
                model.ModuleHeight = dr["module_height"].ToString().Trim();
                model.ModuleUrl = dr["module_url"].ToString().Trim();
                model.ModuleSort = dr["module_sort"].ToString().Trim();
                model.EnableFlag = dr["enable_flag"].ToString().Trim();
                model.ToolbarFlag = dr["toolbar_flag"].ToString().Trim();
                model.ModulePurview = dr["module_purview"].ToString().Trim();

            

            return model;
        }
        #endregion

        /// <summary>
        /// 获得数据列表
        /// </summary>
        #region 模块分页列表
        public DataSet BasModuleList(int pageindex, int pagesize)
        {

            string strSql = Hi.Common.Db.DbUtils.WebPageSql(BasModuleSql(), pageindex, pagesize);
            DataSet set = new DataSet();
            try
            {
                set = DataBase.ExecuteDataSet(strSql,pageindex,pagesize);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }
        public int BasModuleTotalCount()
        {
            try
            {
                string strSql = " select count(*) from (" + BasModuleSql() + ") a ";
                return int.Parse(DataBase.ExecuteScalarToStr(strSql).ToString());
            }
            catch
            {
                return 0;
            }

        }
        private string BasModuleSql()
        {
            return "select t.*," + Hi.Common.Db.DbUtils.GetPageRowNum("module_sort") + " from bas_module t ";
        }
        #endregion

        #endregion

        #region 系统角色维护
        public DataSet RoleList(int pageindex, int pagesize)
        {
            string strSql = Hi.Common.Db.DbUtils.WebPageSql(RoleSql(), pageindex, pagesize);
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
        public int RoleTotalCount()
        {
            try
            {
                string strSql = " select count(*) from (" + RoleSql() + ") a ";
                return int.Parse(DataBase.ExecuteScalarToStr(strSql).ToString());
            }
            catch
            {
                return 0;
            }
        }
        private string RoleSql()
        {
            return "select t.*," + Hi.Common.Db.DbUtils.GetPageRowNum("role_name") + " from bas_role t";
        }
        public bool AddRole(BasRole model)
        {
           
           
            try
            {
                int count = DataBase.ExecuteNonQuery("");
                return count > -1 ? true : false;
            }
            catch
            {
                return false;
            }

        }
        public bool UpdateRole(BasRole model)
        {
            bool blFlag = false;
            int num;
            
            try
            {
                num = DataBase.ExecuteNonQuery("");
            }
            catch (Exception exception)
            {
                throw exception;
            }
            blFlag = (num > 0 ? true : false);
            return blFlag;
        }
        public bool DeleteRole(string id)
        {
            bool blFlag = false;
            int num = -1;
            string sql = "delete from bas_role where id=" + id +" and id not in (select role_id from bas_module_role )";

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
        public bool ExistsRole(string strvalue, int id)
        {
            bool blFlag = false;
            int num = -1;
            string strSql = "select count(*) from bas_role where role_name='{0}' {1} or role_code='{0}' {1}";
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
        /// <summary>
        /// 得到一个实体内容
        /// </summary>
        public BasRole DetailRole(string id)
        {

            string strSql = "select * from bas_role where  id = " + id;
            BasRole model = new BasRole();
            DataRow dr = DataBase.ExecuteDataRow(strSql);
           
            return model;
        }
        #endregion


        #region 系统菜单角色维护
        public DataSet BasModuleRole()
        {
            string strSql = "select (select module_name from bas_module b where b.module_id=a.module_father) father_name,a.* from bas_module a where module_father>0 ";
            DataSet ds = new DataSet();
            try
            {
                ds = DataBase.ExecuteDataSet(strSql);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return ds;
        }
        public DataSet ModuleInRole(int roleid)
        {
            string strSql = " select * from bas_module_role where role_id=" + roleid;
            DataSet ds = new DataSet();
            try
            {
                ds = DataBase.ExecuteDataSet(strSql);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return ds;
        }
        /// <summary>
        /// 模块角色维护，先删除本角色所有模块后批量新增
        /// </summary>
        /// <param name="roleid"></param>
        /// <returns></returns>
        public bool AddModuleRole(string ids,string roleid)
        {
            bool blFlag = false;
            try
            {
                string[] strSql = new string[3];
                //先删除
                strSql[0] = " delete from bas_module_role where role_id="+ roleid;
                //插入子菜单
                strSql[1] = " insert into bas_module_role(module_id,role_id) select distinct module_id," + roleid + " from bas_module where module_id in (" + ids + ")";
                //插入主菜单
                strSql[2] = " insert into bas_module_role(module_id,role_id) select distinct module_id," + roleid + " from bas_module where module_id in (select distinct module_father from bas_module where module_id in (" + ids + ") )";
                blFlag = DataBase.Transaction(strSql);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return blFlag;
        }
        #endregion

        #region 系统用户角色维护
        #endregion


        #region 生成系统菜单
        public DataSet GetSysMenu(string parent_id)
        {
            string sql = "select * from bas_module where module_father=" + parent_id + " order by module_sort  ";
            DataSet set = new DataSet();
            try
            {
                set = DataBase.ExecuteDataSet(sql);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }
        public DataSet GetSysMenu(string parent_id, string role_id)
        {
            string sql = "select * from bas_module where module_father=" + parent_id;
            sql += " and module_id in (select module_id from bas_module_role where role_id=" + role_id + ") order by module_sort  ";
            DataSet set = new DataSet();
            try
            {
                set = DataBase.ExecuteDataSet(sql);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return set;
        }
        #endregion
    }

}
