using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Hi.IDAL;
using Hi.Model.Admin;

namespace Hi.DAL.Access
{
    class DataAuto : IDataAuto
    {
        public bool Exists(string strWhere)
        {
            throw new NotImplementedException();
        }

        public bool Add(BasDataAuto model)
        {
            throw new NotImplementedException();
        }

        public bool UpDate(BasDataAuto model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(BasDataAuto model)
        {
            throw new NotImplementedException();
        }

        public BasDataAuto Detail(string id)
        {
            throw new NotImplementedException();
        }

        public DataSet List(Dictionary<string, string> dict, int pageIndex, int pageSize, string sort)
        {
            throw new NotImplementedException();
        }

        public int TotalCount(Dictionary<string, string> dictionary)
        {
            throw new NotImplementedException();
        }
    }
}
