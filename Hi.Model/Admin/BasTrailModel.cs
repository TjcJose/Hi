using System;

namespace Hi.Model
{
    /// <summary>
    /// Trail 实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    public class BasTrail
    {
        //构造函数
        public BasTrail() { }
        /// <summary>
        /// 
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string OrgName { get; set; }
        /// <summary>
        /// 级别或层次
        /// </summary>
        public string Grade { get; set; }
        /// <summary>
        /// 父级ID
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 负责人
        /// </summary>
        public string LinkName { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LinkTel { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string LinkMobile { get; set; }

    }
}

