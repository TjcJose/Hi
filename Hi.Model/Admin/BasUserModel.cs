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
            [Administrator][V1.0][51编程-代码器自动生成][2011-4-25 15:36:47]
 修改信息 ：(1)[开发员][V1.1][备注][日期]
            (2)[开发员][V1.2][备注][日期]
--------------------------------------------------------------------------------------------------

*/
using System;

namespace Hi.Model
{
    /// <summary>
    /// bas_user 实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public class BasUser
    {
        //构造函数
        public BasUser() { }
        /// <summary>
        /// UserID
        /// </summary>
        public string UserId { get; set; }
        
        /// <summary>
        /// UserCode
        /// </summary>
        public string UserCode { get; set; }
        /// <summary>
        /// UserPassword
        /// </summary>
        public string UserPassword { get; set; }
        /// <summary>
        /// Realname
        /// </summary>
        public string RealName { get; set; }
        /// <summary>
        /// roleid
        /// </summary>
        public string RoleId { get; set; }
        /// <summary>
        /// sex
        /// </summary>
        public string Sex { get; set; }
        /// <summary>
        /// userTelephone
        /// </summary>
        public string UserTelephone { get; set; }
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }
        /// <summary>
        /// Qq
        /// </summary>
        public string Qq { get; set; }
        /// <summary>
        /// RegTime
        /// </summary>
        public string Regtime { get; set; }
        /// <summary>
        /// Address
        /// </summary>
        public string Address { get; set; }
        /// <summary>
        /// Islocked
        /// </summary>
        public string IsLocked { get; set; }
        /// <summary>
        /// LastLoginIP
        /// </summary>
        public string LastLoginIp { get; set; }
        /// <summary>
        /// LoginTimes
        /// </summary>
        public string LoginTimes { get; set; }
        /// <summary>
        /// LastLoginTime
        /// </summary>
        public string LastLoginTime { get; set; }
        /// <summary>
        /// remark
        /// </summary>
        public string Remark { get; set; }
        /// <summary>
        /// 部门或机构ID
        /// </summary>
        public string OrgId { get; set; }
        /// <summary>
        /// 部门或机构名称
        /// </summary>
        public string OrgName { get; set; }
        /// <summary>
        /// 操作权限
        /// </summary>
        public string Purview { get; set; }
        /// <summary>
        /// 操作单一模块具体内容（与参数相关）
        /// 格式(大类编码|小类编码$小类编码)：P01|1$2$10$11
        /// </summary>
        public string PurviewDetail { get; set; }
    }
}

