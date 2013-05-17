using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hi.Model
{
    [Serializable]
    public class BasDataAuto
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BasDataAuto()
        {
            
        }

        public string Id { get; set; }

        public string MgMonth { get; set; }

        public string MgDay { get; set; }

        public string MgHour { get; set; }

        public string MgMinites { get; set; }

        public string MgDistance { get; set; }

        public string MgPower { get; set; }
    }
}
