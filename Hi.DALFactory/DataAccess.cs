/*

-------------------------------------------------------------------------------------------------
 项目名称 ： 客户端开发
 功能描述 ：
 创建信息 ：[开发员][版本][备注][日期]
            [liangsx][V1.0][51编程-代码器自动生成][2011-03-05 0:50:35]
 修改信息 ：(1)[开发员][V1.1][备注][日期]
            (2)[开发员][V1.2][备注][日期]
--------------------------------------------------------------------------------------------------

*/
using System;
using System.Text;
using System.Reflection;
using System.Configuration;

using Hi.IDAL;
using Hi.Model;
namespace Hi.DALFactory
{
    /// <summary>
    /// 
    /// </summary>
    public class DataAccess
    {
        protected static string path = ConfigurationManager .AppSettings["DAL"];    //Hi.Common.Db.DbUtils.Dal;

        #region 查询
        public static IDataQuery CreateDataQuery()
        {
            string className = path + ".DataQuery";
            return (IDataQuery)Assembly.Load(path).CreateInstance(className);
        }
        #endregion

        #region 系统基本类
        public static IUser CreateUser()
        {
            string className = path + ".User";
            return (IUser)Assembly.Load(path).CreateInstance(className);
        }


        public static ILog CreateLog()
        {
            string className = path + ".Log";
            return (ILog)Assembly.Load(path).CreateInstance(className);
        }


        /// <summary>
        /// 系统模块、角色、菜单管理
        /// </summary>
        /// <returns></returns>
        public static ISysAdmin CreateSysAdmin()
        {
            string className = path + ".SysAdmin";
            return (ISysAdmin)Assembly.Load(path).CreateInstance(className);
        }

        /// <summary>
        /// Trail
        /// </summary>
        /// <returns></returns>
        public static ITrail CreateTrail()
        {
            string className = path + ".TrailDal";
            return (ITrail)Assembly.Load(path).CreateInstance(className);
        }


        /// <summary>
        /// 部门信息管理
        /// </summary>
        /// <returns></returns>
        public static IOrg CreateOrg()
        {
            string className = path + ".OrgDAL";
            return (IOrg)Assembly.Load(path).CreateInstance(className);
        }

        #endregion

        #region 手动数据、自动数据管理类

        public static IDataAuto CreateDataAuto()
        {
            var className = path + ".DataAuto";
            return (IDataAuto)Assembly.Load(path).CreateInstance(className);
        }

        #endregion
    }
}