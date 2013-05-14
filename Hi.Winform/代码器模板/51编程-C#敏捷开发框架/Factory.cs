using System;
using System.Text;
using System.Reflection;
using Hi.IDAL;

namespace Hi.DALFactory
{
     /// <summary>
    /// 
    /// </summary>
    public class DataAccess
    {
        /// <summary>
        /// $TableRemark$
        /// </summary>
        /// <returns></returns>
        public static I$ClassName$ Create$ClassName$()
        {
            string className = path + ".$ClassName$DAL";
            return (I$ClassName$)Assembly.Load(path).CreateInstance(className);
        }

    }
}






