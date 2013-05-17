using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hi.Model
{
    [Serializable]
    public class BasDataHand
    {
        public BasDataHand()
        {
            
        }

        public string MgMonth { get; set; }

        public string MgDay { get; set; }

        public string MgHour { get; set; }

        public string MgMinites { get; set; }

        public string MgDistance { get; set; }

        public string MgPower { get; set; }
    }
}
