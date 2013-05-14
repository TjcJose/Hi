using System;
using System.Collections.Generic;

using System.Data;


using Hi.DALFactory;
using Hi.IDAL;
using Hi.Model;

namespace Hi.BLL
{
    [Serializable]
    public class SysAdmin
    {
        private ISysAdmin dal = DataAccess.CreateSysAdmin();

        #region 系统参数
        public DataSet ParamList(Dictionary<string, string> dict, int pageindex, int pagesize, string sort)
        {
            return dal.ParamList(dict,pageindex,pagesize,sort);
        }
        public int ParamTotalCount(Dictionary<string, string> dict)
        {
            return dal.ParamTotalCount(dict);
        }
        public DataSet ParamList(int parent_type)
        {
            return dal.ParamList(parent_type);
        }
        public DataSet ParamListFromCode(string parent_code)
        {
            return dal.ParamListFromCode(parent_code);
        }
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool ParamExists(string strwhere)
        {
            return dal.ParamExists(strwhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool ParamAdd(BasParam model)
        {
            return dal.ParamAdd(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool ParamUpdate(BasParam model)
        {
            return dal.ParamUpdate(model);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool ParamDelete(string id)
        {
            return dal.ParamDelete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BasParam ParamDetail(string id)
        {
            return dal.ParamDetail(id);
        }
        #endregion 

        #region 系统菜单维护
        public bool BasModuleExists(string strWhere)
        {
            return dal.BasModuleExists(strWhere);
        }
        public bool BasModuleDelete(string id)
        {
            return dal.BasModuleDelete(id);
        }
        public bool BasModuleUpdate(BasModule model)
        {
            return dal.BasModuleUpdate(model);
        }
        public bool BasModuleAdd(BasModule model)
        {
            return dal.BasModuleAdd(model);
        }
        public BasModule BasModuleDetail(string id)
        {
            return dal.BasModuleDetail(id);
        }
        public DataSet BasModuleList(int pageindex, int pagesize)
        {
            return dal.BasModuleList(pageindex,pagesize);
        }
        public int BasModuleTotalCount()
        {
            return dal.BasModuleTotalCount();
        }
        public bool ExistsChild(string module_father)
        {
            return dal.ExistsChild(module_father);
        }
        #endregion

        #region 系统角色维护
        public DataSet RoleList(int pageindex,int pagesize)
        {
            return dal.RoleList(pageindex,pagesize);
        }
        public int RoleTotalCount()
        {
            return dal.RoleTotalCount();
        }
        public bool AddRole(BasRole model)
        {
            return dal.AddRole(model);
        }
        public bool UpdateRole(BasRole model)
        {
            return dal.UpdateRole(model);
        }
        public bool DeleteRole(string id)
        {
            return dal.DeleteRole(id);
        }
        public bool ExistsRole(string strValue,int id)
        {
            return dal.ExistsRole(strValue, id);
        }
        public BasRole DetailRole(string id)
        {
            return dal.DetailRole(id);
        }
        #endregion


        #region 系统菜单角色维护
        public DataSet BasModuleRole()
        {
            return dal.BasModuleRole();
        }
        public DataSet ModuleInRole(int roleid)
        {
            return dal.ModuleInRole(roleid);
        }
        public bool AddModuleRole(string ids,string roleid)
        {
            return dal.AddModuleRole(ids,roleid);
        }
        #endregion

        #region 系统用户角色维护
        #endregion


        #region 生成系统菜单

        public DataSet GetSysMenu(string parent_id)
        {
            return dal.GetSysMenu(parent_id);
        }
        public DataSet GetSysMenu(string parent_id, string role_id)
        {
            return dal.GetSysMenu(parent_id, role_id);
        }
        #endregion

    }
}
