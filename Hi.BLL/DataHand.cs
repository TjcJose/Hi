using System;
using Hi.DALFactory;
using Hi.IDAL;
using Hi.Model;

namespace Hi.BLL
{
    [Serializable]
    public class DataHand : MarshalByRefObject
    {
        private readonly IDataHand _dal = DataAccess.CreateDataHand();

        #region 成员方法

        public bool Exists(string strWhere)
        {
            return _dal.Exists(strWhere);
        }

        public bool Add(BasDataHand model)
        {
            return _dal.Add(model);
        }

        #endregion
    }
}
