using System;
using System.Data;
using System.Collections.Generic;
using Hi.Model;

namespace Hi.IDAL
{
    public interface ITrail
    {
       // DataSet TrailList(Dictionary<string, string> dict, int pageindex, int pagesize, string sort);
        //int TrailTotalCount(Dictionary<string, string> dict);
       // DataSet TrailList(int parent_type);
        //DataSet TrailListFromCode(string parent_code);
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        //bool TrailExists(string strwhere);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        //bool TrailAdd(TrailModel model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool Update(BasTrail model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        //bool TrailDelete(string id);
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        //TrailModel TrailDetail(string id);
    }
}
