/*
------------------------------------------------------------------------------------------
 代码提供 ： 51编程-代码器
 作    者 ： 梁孙祥
       QQ ： 88130278
   EMail  ： LiangSunXiang@139.com
 官 方 网 ： www.51program.net
 个人博客 ： blog.csdn.net/liangsx
 温馨提示 ： 试用版本，附加版权内容。但不影响正常使用,请通过购买注册屏蔽此信息，谢谢！
 注册方法 ： 详情请访问官方网或来信咨询
-------------------------------------------------------------------------------------------

-------------------------------------------------------------------------------------------------
 项目名称 ： Vs2008+Winfrom+工厂模式架构
 功能描述 ：
 创建信息 ：[开发员][版本][备注][日期]
            [Administrator][V1.0][51编程-代码器自动生成][2011-7-11 9:46:25]
 修改信息 ：(1)[开发员][V1.1][备注][日期]
            (2)[开发员][V1.2][备注][日期]
--------------------------------------------------------------------------------------------------

*/
using System;
using System.Data;
using System.Collections.Generic;
using System.Collections;

using Hi.Common;
using Hi.DALFactory;
using Hi.IDAL;
using Hi.Model;

namespace Hi.BLL
{
    /// <summary>
    /// 业务逻辑类bas_user 的摘要说明。
    /// </summary>
    [Serializable]
    public class User : MarshalByRefObject
    {
        private readonly IUser dal = DataAccess.CreateUser();

        #region  成员方法
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        public bool Exists(string strwhere)
        {
            return dal.Exists(strwhere);
        }

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public bool Add(BasUser model)
        {
            return dal.Add(model);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BasUser model)
        {
            return dal.Update(model);
        }
        public bool UpdatePurview(string user_id, string strPurview)
        {
            return dal.UpdatePurview(user_id, strPurview);
        }
        public bool UpdatePurview(string user_id, string module_code, string strPurview)
        {
            return dal.UpdatePurview(user_id, module_code, strPurview);
        }
        /// <summary>
        /// 重设密码
        /// </summary>
        /// <param name="UserID">用户ID</param>
        /// <param name="newsPassword">新密码</param>
        /// <returns></returns>
        public bool ResetPassword(string UserID, string newsPassword)
        {
            if (string.IsNullOrEmpty(UserID) || string.IsNullOrEmpty(newsPassword))
                return false;
            return dal.ResetPassword(UserID, MD5.MD5Encrypt(newsPassword.Trim()));
        }
        /// <summary>
        /// 删除一条数据
        /// </summary>
        public bool Delete(string id)
        {
            return dal.Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public BasUser Detail(string id)
        {
            return dal.Detail(id);
        }

        public DataSet List(Dictionary<string, string> dict, int pageIndex, int pageSize, string sort)
        {
            return dal.List(dict, pageIndex, pageSize, sort);
        }
        /// <summary>
        /// 获得数据总记录数
        /// </summary>
        public int TotalCount(Dictionary<string, string> dict)
        {
            return dal.TotalCount(dict);
        }
        #endregion  成员方法
    }
}
