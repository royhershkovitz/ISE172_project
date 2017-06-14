using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketClientTest
{
    public class TestHistory
    {

        [TestMethod]
        public void TestHisory()
        {
            AlgoTrading.Data.History.HistoryWriter.setPath(@"C:\Users\user\Documents\Visual Studio 2015\Projects\ISE172_project\PresentationLayer\bin\logs\UserActionsLog.csv");
            bool found = false;
            string history = AlgoTrading.Data.History.HistoryWriter.ReadMyHistory();
            //Console.WriteLine("1 "+history);
            string stID = "-1";
            int i = 0;
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
            Assert.IsFalse(found);
            //check add
            AlgoTrading.Data.History.HistoryWriter.AddSpecipicDataToHistory("take", -1, false, "toys");
            System.Threading.Thread.Sleep(100);
            found = false;
            history = AlgoTrading.Data.History.HistoryWriter.ReadMyHistory(); 
            stID = "-1";
            //Console.WriteLine("2 " + history);
            i = 0;
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
            while (i < history.Length && history[i]!='\n')
            {
                Console.Write(history[i]);
                i++;
            }
            Console.WriteLine(">\n<"+history.Substring(begin, i- begin)+">");
            Console.WriteLine("-1,take,toys,False,valid");
            Assert.IsTrue(String.Equals("-1,take,toys,False,valid", history.Substring(begin, i- begin)));

            //Cancel test
            AlgoTrading.Data.History.HistoryWriter.CancelOldRequest(-1);

            history = AlgoTrading.Data.History.HistoryWriter.ReadMyHistory();
            stID = "-1";
            i = 0;
            found = false;
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
            begin = i;
            Console.Write("<");
            while (i < history.Length && history[i] != '\n')
            {
                Console.Write(history[i]);
                i++;
            }
            Console.WriteLine(">\n<" + history.Substring(begin, i - begin) + ">");
            Console.WriteLine("-1,take,toys,False,invalid");
            Assert.IsTrue(String.Equals("-1,take,toys,False,invalid", history.Substring(begin, i - begin)));
        }
    }
}
