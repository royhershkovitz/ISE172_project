using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoTrading.Data.DataTypes
{
    class HistoryWriter
    {
        private static readonly double sec = 0.1;
        private static readonly string path = @"C:\Logs\UserActionsLog.txt";
        //string path = @"..\logs\UserActionsLog.txt";


        // add the string 'information' to the file
        public static void addSpecipicDataToHistory(string type, int id, bool isAMA, string details)
        {
            addToHistory(id+":"+type+":"+ details+":"+isAMA+":valid");
        }

        // add the string 'information' to the file
        public static void addToHistory(string information)
        {
            log4net.ILog Log = LogHelper.getLogger();            
            try
            {
                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    using (StreamWriter sW = File.AppendText(path))
                    {
                        // Add some information to the file.                        
                        sW.WriteLine("" + information);
                    }
                }
                else
                {
                    // Create the file.
                    using (FileStream fs = File.Create(path))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes("" + information);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                }
                Log.Info("edit history.txt");
                Thread.Sleep(TimeSpan.FromSeconds(sec));

            }

            catch (Exception ex)
            {
                Log.Fatal("Failed to write history, program crushed, Exception: " + ex + ", Message: " + ex.Message);
                Thread.Sleep(TimeSpan.FromSeconds(sec)); // Sleep some secs after writing on HardDrive
            }
            Console.Read();
        }

        // read the text from file
        public static string readMyHistory()
        {
            log4net.ILog Log = LogHelper.getLogger();
            string output = "";
            try
            {
                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    // Open the stream and read it back.
                    using (StreamReader sR = File.OpenText(path))
                    {
                        string ourText = "";
                        while ((ourText = sR.ReadLine()) != null)
                            output = output + ourText + "\n";
                    }
                    Log.Info("read history.txt");
                    Thread.Sleep(TimeSpan.FromSeconds(sec));
                }
            }

            catch (Exception ex)
            {
                Log.Fatal("Failed to read history, program crushed, Exception: " + ex + ", Message: " + ex.Message);
                Thread.Sleep(TimeSpan.FromSeconds(sec)); // Sleep some secs after writing on HardDrive
            }
            return output;
        }

        // change the data with this id from valid to invalid
        public static void cancelOldRequest(int id)
        {
            log4net.ILog Log = LogHelper.getLogger();
            string history = readMyHistory();
            bool found = false;
            try
            {//FileStream fcreate = File.Open("C:\\test.txt", FileMode.Create); // will create the file or overwrite it if it already exists
                /*using(var sw = new StreamWriter(@"c:\test.txt", true))
{
    for(int x = 0; x < 5; x++)
    {
        sw.WriteLine(x);    
    }
}*/
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
                    while (!found & i < history.Length - stID.Length)
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
                    using (var sw = new StreamWriter(path, false))
                    {
                        sw.Write(history);
                    }
                }
            }

            catch (Exception ex)
            {
                Log.Fatal("Failed to read history, program crushed, Exception: " + ex + ", Message: " + ex.Message);
                Thread.Sleep(TimeSpan.FromSeconds(sec)); // Sleep some secs after writing on HardDrive
            }
            if(!found)
                Log.Error("Didn't find the id " + id);
        }
    }
}
