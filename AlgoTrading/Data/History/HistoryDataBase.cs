using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Windows;

namespace AlgoTrading.Data.History
{
    public class HistoryDataBase
    {
        //This method read all the system history
        public static List<HistoryUnit> GetAllHistory()
        {
            log4net.ILog Log = LogHelper.GetLogger();
            List<HistoryUnit> result;
            try
            {
                string[] lines = File.ReadAllLines("../Logs/UserActionsLog.csv");
                result = new List<HistoryUnit>();
                foreach (var line in lines)
                {
                    string[] HitoryLine = line.Split(',');
                    //Trace.WriteLine("xxxmomxxx: "+ line);
                    result.Add(HistoryUnitFromCsv(HitoryLine));
                }
                Log.Info("History.csv had been read");
            }
            catch(Exception ex)
            {                
                MessageBox.Show("No history has been recorded yet");
                Log.Fatal("Failed to read history " + ex);
                //Trace.WriteLine("Fail, GetAllHistory: " + ex);
                Thread.Sleep(TimeSpan.FromSeconds(0.01));
                result = null;
            }
            return result;
        }

        //This method gets an array and returns a history unit
        private static HistoryUnit HistoryUnitFromCsv(string[] values)
        {

            //Trace.Write(values[0]);
            //int i = 1;
            //while(i < values.Length)
            //{
            //    Trace.Write(", "+values[i]);
            //    i++;
            //}
            HistoryUnit HU = new HistoryUnit()
            {
                ID = int.Parse(values[0]),
                Type = values[1],                
                Price = int.Parse(values[2]),
                Commodity = int.Parse(values[3]),
                Amount = int.Parse(values[4]),
                IsAma = bool.Parse(values[5]),
                Validation = values[6]
            };
            //Trace.WriteLine("HU: "+ HU.ToString());
            return HU;
        }
    }
}
