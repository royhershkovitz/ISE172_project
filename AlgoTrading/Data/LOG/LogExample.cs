using System;
using System.Threading;


namespace AlgoTrading.Data.LOG
{
    class LogExample
    {
        //Important: Declare an instance for log4net, define before use log
        private static readonly log4net.ILog Log = LogHelper.GetMethodLogger("main");
        //log4net.LogManager.GetLogger("Program.cs");//System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        //static void Main(string[] args)
        //{
        //    ImplementLoggingFuntion();
        //}

        private static void ImplementLoggingFuntion()
        {
            /* We have 5 levels of log message. Let's test all.
             *  FATAL
                ERROR
                WARN
                INFO
                DEBUG
             */
            log4net.GlobalContext.Properties["Counter"] = new Counter();//Optional: define counter in xaml - overall to count logs call, define before use log
            var secs = 0.1;

            Log.Fatal("Start log FATAL...");
            Console.WriteLine("Start log FATAL...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Error("Start log ERROR...");
            Console.WriteLine("Start log ERROR...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Warn("Start log WARN...");
            Console.WriteLine("Start log WARN...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Info("Start log INFO...");
            Console.WriteLine("Start log INFO...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Log.Debug("Start log DEBUG...");
            Console.WriteLine("Start log DEBUG...");
            Thread.Sleep(TimeSpan.FromSeconds(secs)); // Sleep some secs

            Console.WriteLine("Press any key to close the application");
            Console.ReadKey();
        }
    }
}
