using System;
using Hi.DALFactory;
using Hi.IDAL;
using Hi.Model;
using Hi.Model;

namespace Hi.BLL
{
    [Serializable]
    public class DataAuto : MarshalByRefObject
    {
        private readonly IDataAuto dal = DataAccess.CreateDataAuto();

        #region 成员方法

        public bool Exists(string strWhere)
        {
            return dal.Exists(strWhere);
        }

        public bool Add(BasDataAuto model)
        {
            return dal.Add(model);
        }

        #endregion
    }
}
