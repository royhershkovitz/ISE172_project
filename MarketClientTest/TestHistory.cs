using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoTrading.Data.History;
using System.IO;

namespace MarketClientTest
{
    public class TestHistory
    {
        private string path = @"../Logs/UserActionsLog.csv";
        [TestMethod]
        //Test adding to history
        public void TestAdding(string type, int id, bool isAMA, string details)
        {
            //check add first object
            HistoryWriter.AddSpecipicDataToHistory(type, id, isAMA, details);//For example "take", -1, false, "toys"
            System.Threading.Thread.Sleep(100);
            bool found = false;
            string history = HistoryWriter.ReadMyHistory();
            string stID = id.ToString();
            //Console.WriteLine("2 " + history);
            int i = 0;
            while (!found & i < history.Length - stID.Length)
            {
                if (history[i] == stID[0])
                    if (history.Substring(i, stID.Length).Equals(stID))
                        found = true;
                i++;
            }
            Assert.IsTrue(found);

            //format checking
            i--;//indexing
            int begin = i;
            Console.Write("<");
            while (i < history.Length && history[i] != '\n')
            {
                Console.Write(history[i]);
                i++;
            }
            Console.WriteLine(">\n<" + history.Substring(begin, i - begin) + ">");
            Console.WriteLine(id + "," + type + "," + details + "," + isAMA + ",valid");
            Assert.IsTrue(String.Equals(id + "," + type + "," + details + "," + isAMA + ",valid", history.Substring(begin, i - begin)));
        }

        [TestMethod]
        //Test turning item to invalid
        public void TestCancel(string type, int id, bool isAMA, string details)
        {
            //Cancel test
            HistoryWriter.CancelOldRequest(id);

            string history = HistoryWriter.ReadMyHistory();
            int i = 0;
            bool found = false;
            string stID = id.ToString();
            while (!found & i < history.Length - stID.Length)
            {
                if (history[i] == stID[0])
                    if (history.Substring(i, stID.Length).Equals(stID))
                        found = true;
                i++;
            }
            Assert.IsTrue(found);

            //format checking
            i--;
            int begin = i;
            Console.Write("<");
            while (i < history.Length && history[i] != '\n')
            {
                Console.Write(history[i]);
                i++;
            }
            Console.WriteLine(">\n<" + history.Substring(begin, i - begin) + ">");
            Console.WriteLine(id + "," + type + "," + details + "," + isAMA + ",invalid");
            Assert.IsTrue(String.Equals(id + "," + type + "," + details + "," + isAMA + ",invalid", history.Substring(begin, i - begin)));
        }

        //Delete the file we use in the test
        public void deleteHistory()
        {
            File.Delete(path);
        }
    }
}