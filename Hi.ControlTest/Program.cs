using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Configuration;
using System.Diagnostics;
using System.Threading;


using Hi.Common;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            
          //  Hi.LingToSql.SqlServer.LinqSql.CreateDatabase();
          //  Hi.LingToSql.SqlServer.LinqSql.Insert();
            //Hi.LingToSql.SqlServer.LinqSql.Select();
            //IEnumerable<System.Data.Linq.Student> q = Hi.LingToSql.SqlServer.LinqSql.Select(1);
            //foreach (var item in q)
            //{
            //    System.Console.WriteLine(item);
                
            //} 
            //IORM orm = new ORM(); 

            //orm.Create =Factory.Create<Create>();
            
            //orm.Test();
            WaitHandlerExample.ThreadPoolMain();
            System.Console.ReadLine();
        }
    }
    public class WaitHandlerExample
    {
        public static AutoResetEvent waitHandler;
        public static ManualResetEvent manualWaitHandler;

        public static void ThreadPoolMain()
        {
            waitHandler = new AutoResetEvent(false);
            manualWaitHandler = new ManualResetEvent(false);

            // Queue the task. 
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc));
            ThreadPool.QueueUserWorkItem(new WaitCallback(ThreadProc2));

            Console.WriteLine("Main thread does some work, then waiting....");
            manualWaitHandler.WaitOne();
            //waitHandler.Reset(); 
            manualWaitHandler.WaitOne();
            //waitHandler.Reset(); 
            Console.WriteLine("Main thread exits.");
        }

        // This thread procedure performs the task. 
        public static void ThreadProc(Object stateInfo)
        {
            Thread.Sleep(1000);
            Console.WriteLine("Hello from the thread pool.");
            //waitHandler.Set();        // 
            manualWaitHandler.Set();//过去了，但是没关，也就是说 信号还是开着的。 
            //manualWaitHandler.Reset(); 
        }
        public static void ThreadProc2(object stateInfo)
        {
            Thread.Sleep(100);
            Console.WriteLine("Hello from the thread Pool2");
            //waitHandler.Set(); 
            manualWaitHandler.Set();//过去了，但是没有关 

        }
    }
    public class Create : ICreate
    {
        public bool Create2(object o)
        {
            return true;
        }
    }

    public interface ICreate
    {
        bool Create2(object o);
    }
    public interface IORM
    {

        ICreate Create
        {
            get;
            set;
        }


        void Test();
    }

    public class ORM : IORM 
    {

        public ICreate Create
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        public void Test()
        {
            ///测试缓存对象！ 
          
            System.Console.WriteLine("Hi ");
        }
    }



    public class Factory
    {
        public static T Create<T>() where T : class,new()
        {
            T target = new T();

            return target;
        }
    }

}
