using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AlgoTrading.Logic
{
    public class myAIAlgorithem
    {
        private bool running = true;
        private bool midRun = false;
        private MarketClientOptions UserOptions = new MarketClientOptions();
        public myAIAlgorithem()
        {
        }
        public void stopAlgorithemAI()
        {
            running = false;
        }
        public bool canAbortThread()
        {
            return midRun;
        }
        public void runAlgorithemAI()
        {
            while (running)
            {
                Trace.WriteLine("\n\nbuy");
                for (int i = 0; i < 9; i++)//missing commodity 9
                {
                    int price = 1;
                    int commodity = i;
                    int amount = 1;
                    UserOptions.SendBuyRequest(price, commodity, amount);
                    Thread.Sleep(TimeSpan.FromSeconds(0.01));
                }

                Trace.WriteLine("sell");
                for (int i = 0; i < 9; i++)
                {
                    int price = 15;
                    int commodity = i;
                    int amount = 1;
                    UserOptions.SendSellRequest(price, commodity, amount);
                    Thread.Sleep(TimeSpan.FromSeconds(0.01));
                    Trace.WriteLine(i);
                }
                Trace.WriteLine("sleep");
                Thread.Sleep(TimeSpan.FromSeconds(10));
                Trace.WriteLine("keeprunning: " + running);               
            }
            midRun = true;
        }
    }
}
