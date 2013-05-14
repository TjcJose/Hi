using Hi.DALFactory;
using Hi.IDAL;
using Hi.Model;

namespace Hi.BLL
{
    public class TrailBll
    {
        private ITrail dal = DataAccess.CreateTrail();

        #region 系统参数

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public bool TrailUpdate(BasTrail model)
        {
            return dal.Update(model);
        }
        #endregion
    }
}
