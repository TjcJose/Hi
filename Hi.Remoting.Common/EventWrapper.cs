using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Hi.Remoting.Common
{
    /// <summary>
    /// EventClass 的摘要说明。
    /// </summary>
    public class EventWrapper : MarshalByRefObject
    {
        public event IServer2ClientEventHandler Server2ClientEvent;

        //[OneWay]
        public void OnServer2ClientEvent(string message)
        {
            Server2ClientEvent(message);
        }


        public override object InitializeLifetimeService()
        {
            return null;
        }

    }
   
  
}
