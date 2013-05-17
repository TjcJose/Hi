using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Hi.IDAL;
using Hi.Model;

namespace Hi.DAL.Access
{
    class DataAuto : IDataAuto
    {
        public bool Exists(string strWhere)
        {
            string strSql = " select count(*) from bas_Data_Auto where 1=1 " + strWhere;
            string strValue = DataBase.ExecuteScalarToStr(strSql);
            return int.Parse(strValue) > 0 ? true : false;
        }

        public bool Add(BasDataAuto model)
        {
            if (model == null)
            {
                return false;
            }

            var strb = new StringBuilder();
            strb.Append(" Insert Into bas_Data_Auto ");
            strb.Append(" ( ");
            strb.Append("MG_Month, ");
            strb.Append("MG_Day, ");
            strb.Append("MG_Hour, ");
            strb.Append("MG_Minites, ");
            strb.Append("MG_Distance, ");
            strb.Append("MG_Power ");
            strb.Append(" )");
            strb.Append(" Values( ");
            strb.Append("" + model.MgMonth + ", ");
            strb.Append("'" + model.MgDay + "', ");
            strb.Append("'" + model.MgHour + "', ");
            strb.Append("'" + model.MgMinites + "', ");
            strb.Append("'" + model.MgDistance + "', ");
            strb.Append("'" + model.MgPower + "' ");
            strb.Append(" )");

            try
            {
                return DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpDate(BasDataAuto model)
        {
            bool blFlag;
            try
            {
                var strb = new StringBuilder();
                strb.Append(" Update bas_user ");
                strb.Append(" Set ");
                strb.Append("MG_Month = " + Hi.Common.Utils.IsNull(model.MgMonth, "0") + ",");
                strb.Append("MG_Day = " + model.MgDay + ",");
                strb.Append("MG_Hour = " + model.MgHour + ",");
                strb.Append("MG_Minite = " + model.MgMinites + ",");
                strb.Append("MG_Distance = " + model.MgDistance + ",");
                strb.Append("MG_Power = " + model.MgPower + ",");
                strb.Append(" where ID = " + model.Id.ToString());
                blFlag = DataBase.ExecuteNonQuery(strb.ToString()) > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return blFlag;
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
