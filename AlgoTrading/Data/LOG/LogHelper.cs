using System.Runtime.CompilerServices;
using log4net;

namespace AlgoTrading
{
    public class LogHelper
    {
        public static log4net.ILog GetLogger([CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }

        public static ILog GetMethodLogger(string data)
        {
            return log4net.LogManager.GetLogger(data);
        }

        //add information to the logger creation
        public static log4net.ILog GetInformativeLogger(string data, [CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename + "." + data);
        }
    }
}