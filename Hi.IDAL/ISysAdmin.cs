using System;
using System.Data;
using System.Collections.Generic;
using Hi.Model;
namespace Hi.IDAL
{
    public  interface ISysAdmin
    {
        #region 系统参数
        DataSet ParamList(Dictionary<string, string> dict, int pageindex, int pagesize, string sort);
        int ParamTotalCount(Dictionary<string, string> dict);
        DataSet ParamList(int parent_type);
        DataSet ParamListFromCode(string parent_code);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        bool ParamExists(string strwhere);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        bool ParamAdd(BasParam model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool ParamUpdate(BasParam model);

        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool ParamDelete(string id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        BasParam ParamDetail(string id);
        #endregion 

        #region 系统菜单维护
        bool BasModuleExists(string strWhere);
        bool BasModuleDelete(string id);
        bool BasModuleUpdate(BasModule model);
        bool BasModuleAdd(BasModule model);
        BasModule BasModuleDetail(string id);
        DataSet BasModuleList(int pageindex, int pagesize);
        int BasModuleTotalCount();
        bool ExistsChild(string module_father);
        #endregion 

        #region 系统角色维护
        DataSet RoleList(int pageindex, int pagesize);
        int RoleTotalCount();

        bool AddRole(BasRole model);
        bool UpdateRole(BasRole model);
        bool DeleteRole(string id);
        bool ExistsRole(string strvalue,int id);
        BasRole DetailRole(string id);
        #endregion


        #region 系统菜单角色维护
        DataSet BasModuleRole();
        DataSet ModuleInRole(int roleid);
        bool AddModuleRole(string ids, string roleid);
        #endregion

        #region 系统用户角色维护
        #endregion

        
        #region 生成系统菜单
        DataSet GetSysMenu(string parent_id);
        DataSet GetSysMenu(string parent_id, string role_id);
        #endregion 
    }
}
