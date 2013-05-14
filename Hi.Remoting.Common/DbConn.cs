using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Hi.Remoting.Common
{
    [Serializable]
    public class DbConn : MarshalByRefObject
    {
        public void SetConn(bool istest)
        {
            string strDbType = "SqlServer";
            if (istest)
                strDbType = "Access";
            Hi.Common.Db.DbUtils.Dal = strDbType;
            Hi.Common.Db.DbUtils.ProviderName = DbProviderName(strDbType);
            Hi.Common.Db.DbUtils.ConnectionString = DbConnectionString(strDbType);
        }
        private string DbConnectionString(string dbtype)
        {
            return @"user id=sa;password=sa;initial catalog=PureData;data source=.\sqlexpress;";
        }
        private string DbProviderName(string dbtype)
        {
            return "System.Data.SqlClient";
        }
    }
}
