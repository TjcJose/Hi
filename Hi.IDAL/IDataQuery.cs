using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace Hi.IDAL
{
    public interface IDataQuery
    {
        DataSet List(Dictionary<string, string> dict, int pageindex, int pagesize);
        int TotalCount(Dictionary<string, string> dict);

    }
}
