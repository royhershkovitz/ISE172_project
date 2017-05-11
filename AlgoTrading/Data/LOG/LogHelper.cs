using System.Runtime.CompilerServices;
using log4net;

namespace AlgoTrading
{
    internal class LogHelper
    {
        public static log4net.ILog getLogger([CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }

        internal static ILog getMethodLogger(string data)
        {
            return log4net.LogManager.GetLogger(data);
        }

        //add information to the logger creation
        public static log4net.ILog getInformativeLogger(string data, [CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename + "." + data);
        }
    }
}