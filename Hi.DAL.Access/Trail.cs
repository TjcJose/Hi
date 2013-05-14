using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using System.Data.Common;
using Hi.IDAL;
using Hi.Model;
namespace Hi.DAL.Access
{
    public class TrailDal : ITrail
    {
        public TrailDal()
        { }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool Update(BasTrail model)
        {
            StringBuilder strb = new StringBuilder();
            strb.Append(" Update bas_trail ");
            strb.Append(" Set ");
            //strb.Append("id         = " + model.Id + ",");
            strb.Append("org_name        = '" + model.OrgName + "' ");

            //strb.Append("title        = '" + model.Title + "',");

            //strb.Append("remark       = '" + model.Remark + "',");
            //strb.Append("sort         = '" + model.Sort + "',");
            strb.Append(" where  id = 1");

            return DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;
        }

        //TrailModel TrailDetail(string id)
        //{
        //    return new TrailModel();
        //}
    }
}
