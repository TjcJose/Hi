using System.Collections.Generic;
using System.Data;
using Hi.Model.Admin;

namespace Hi.IDAL
{
    public interface IDataAuto
    {
        /// <summary>
        /// 是否存在该记录
        /// </summary>
        /// <param name="strWhere"></param>
        /// <returns></returns>
        bool Exists(string strWhere);

        /// <summary>
        /// 添加一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Add(BasDataAuto model);

        /// <summary>
        /// 更新一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool UpDate(BasDataAuto model);

        /// <summary>
        ///  删除一条数据
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool Delete(BasDataAuto model);

        /// <summary>
        /// 得到一个实体对象
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        BasDataAuto Detail(string id);

        /// <summary>
        /// 获得数据列表
        /// </summary>
        DataSet List(Dictionary<string, string> dict, int pageIndex, int pageSize, string sort);

        /// <summary>
        /// 获取数据总记录数
        /// </summary>
        /// <param name="dictionary"></param>
        /// <returns></returns>
        int TotalCount(Dictionary<string, string> dictionary);
    }
}
