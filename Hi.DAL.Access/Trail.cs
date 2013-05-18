using System.Text;
using Hi.IDAL;
using Hi.Model;

namespace Hi.DAL.Access
{
    /// <summary>
    /// 测试用
    /// </summary>
    public class TrailDal : ITrail
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public TrailDal()
        { }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BasTrail model)
        {
            var strb = new StringBuilder();

            strb.Append(" Update bas_trail ");
            strb.Append(" Set ");
            //strb.Append("id         = " + model.Id + ",");
            strb.Append("org_name        = '" + model.OrgName + "' ");

            //strb.Append("title        = '" + model.Title + "',");
            //strb.Append("remark       = '" + model.Remark + "',");
            //strb.Append("sort         = '" + model.Sort + "',");

            strb.Append(" where  id = 1");

            return DataBase.ExecuteNonQuery(strb.ToString()) > 0;
        }
    }
}
