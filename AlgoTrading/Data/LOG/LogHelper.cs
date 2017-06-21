using System.Runtime.CompilerServices;
using log4net;

namespace AlgoTrading
{
    public class LogHelper
    {
        //Add logger with specifhic file name so we can know where the log loadded from
        public static log4net.ILog GetLogger([CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename);
        }

        //Add logger with a specifhic String 'data'
        public static ILog GetMethodLogger(string data)
        {
            return log4net.LogManager.GetLogger(data);
        }

        //Add information to the logger creation
        public static log4net.ILog GetInformativeLogger(string data, [CallerFilePath]string filename = "")
        {
            return log4net.LogManager.GetLogger(filename + "." + data);
        }
    }
}