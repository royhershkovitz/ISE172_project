using System;
using System.IO;
using System.Text;
using System.Threading;

namespace AlgoTrading.Data.History
{
    public class HistoryWriter
    {
        private static readonly double Sec = 0.1;
        private static string Path = "../Logs/UserActionsLog.csv";

        public static void setPath(string newPath)
        {
            Path = newPath;
        }

        // add the string 'information' to the file
        public static void AddSpecipicDataToHistory(string type, int id, bool isAMA, string details)
        {
            //Trace.WriteLine("Add to history "+id + "," + type + "," + details + "," + isAMA + ",valid");
            lock (Path)
            {
                AddToHistory(id + "," + type + "," + details + "," + isAMA + ",valid");
            }
        }

        // add the string 'information' to the file
        private static void AddToHistory(string information)
        {
            log4net.ILog Log = LogHelper.GetLogger();            
            try
            {
                // Delete the file if it exists.
                if (File.Exists(Path))
                {
                    using (StreamWriter sW = File.AppendText(Path))
                    {
                        // Add some information to the file.                        
                        sW.WriteLine(information);
                    }
                }
                else
                {
                    // Create the file.
                    using (FileStream fs = File.Create(Path))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes(information+"\n");
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                }
                Log.Info("edit UserActionsLog.csv");
                Thread.Sleep(TimeSpan.FromSeconds(Sec));

            }

            catch (Exception ex)
            {
                Log.Fatal("Failed to write history, program crushed, Exception: " + ex + ", Message: " + ex.Message);
                Thread.Sleep(TimeSpan.FromSeconds(Sec)); // Sleep some secs after writing on HardDrive
            }
        }

        // read the text from file
        public static string ReadMyHistory()
        {            
            log4net.ILog Log = LogHelper.GetLogger();
            string output = "";
            lock (Path)
            {
                try
                {
                    // Delete the file if it exists.
                    if (File.Exists(Path))
                    {
                        // Open the stream and read it back.
                        using (StreamReader sR = File.OpenText(Path))
                        {
                            string ourText = "";
                            while ((ourText = sR.ReadLine()) != null)
                                output = output + ourText + "\n";
                        }
                        Log.Info("read UserActionsLog.csv");
                        Thread.Sleep(TimeSpan.FromSeconds(Sec));
                    }
                }

                catch (Exception ex)
                {
                    Log.Fatal("Failed to read history, program crushed, Exception: " + ex + ", Message: " + ex.Message);
                    Thread.Sleep(TimeSpan.FromSeconds(Sec)); // Sleep some secs after writing on HardDrive
                }
            }
            return output;
        }

        // change the data with this id from valid to invalid
        public static bool CancelOldRequest(int id)
        {
            log4net.ILog Log = LogHelper.GetLogger();
            string history = ReadMyHistory();
            bool found = false;
            try
            {
                // Delete the file if it exists.
                if (!history.Equals(""))
                {
                    //System.Diagnostics.Trace.WriteLine("Making history\n"+history);
                    int i = 0;
                    string stID = "" + id;
                    while (!found & i < history.Length - stID.Length)
                    {
                        //System.Diagnostics.Trace.Write(history[i]+"-");
                        if (history[i] == stID[0])
                        {
                            //System.Diagnostics.Trace.Write("+"+history.Substring(i, stID.Length) +"*"+ i+"/"+ (i+ stID.Length) + "*");
                            if (history.Substring(i, stID.Length).Equals(stID))
                                found = true;
                        }
                        i++;
                    }

                    //System.Diagnostics.Trace.WriteLine("\n" + found);
                    //System.Diagnostics.Trace.WriteLine(i+"___"+ history.Substring(i));
                    found = false;
                    stID = "valid";
                    while (!found & i < history.Length - stID.Length && history[i] != '\n')
                    {
                        //System.Diagnostics.Trace.Write(history[i]+"-");
                        if (history[i] == stID[0])
                        {
                            if (history.Substring(i, stID.Length).Equals(stID))
                            {
                                found = true;
                                history = history.Substring(0, i) + "in" + history.Substring(i);
                            }
                        }
                        i++;
                    }
                    //System.Diagnostics.Trace.WriteLine("\n" + found);
                    //System.Diagnostics.Trace.WriteLine(i+" "+ history);
                    using (var sw = new StreamWriter(Path, false))
                    {
                        sw.Write(history);
                    }
                }
            }

            catch (Exception ex)
            {
                Log.Fatal("Failed to read history, program crushed, Exception: " + ex + ", Message: " + ex.Message);
                Thread.Sleep(TimeSpan.FromSeconds(Sec)); // Sleep some secs after writing on HardDrive
            }
            if(!found)
                Log.Error("Didn't find the id " + id);
            return found;
        }
    }
}
