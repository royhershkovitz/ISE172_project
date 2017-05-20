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
        private MarketClientOptions UserOptions = new MarketClientOptions(true);
        public myAIAlgorithem()
        {
        }

        //This function is for the use of other classes to stop the algorithm
        public void StopAlgorithemAI()
        {
            running = false;
        }

        //This function check if it possible to stop the AI.
        public bool CanAbortThread()
        {
            return midRun;
        }
        public void RunAlgorithemAI()
        {
            while (running)
            {
                Trace.WriteLine("\n\nbuy");
                //Buying all possible commodities for a cheap price
                for (int i = 0; i < 9; i++)//missing commodity 9
                {
                    int price = 1;
                    int commodity = i;
                    int amount = 1;
                    UserOptions.SendBuyRequest(price, commodity, amount);
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                }

                Trace.WriteLine("sell");
                //Selling them for more.
                for (int i = 0; i < 9; i++)
                {
                    int price = 15;
                    int commodity = i;
                    int amount = 1;
                    UserOptions.SendSellRequest(price, commodity, amount);
                    Thread.Sleep(TimeSpan.FromSeconds(0.1));
                    Trace.WriteLine(i);
                }
                if (running)
                {
                    Trace.WriteLine("sleep");
                    Thread.Sleep(TimeSpan.FromSeconds(8.2));//10-0.1*18 = 8.2
                }
                Trace.WriteLine("keeprunning: " + running);               
            }
            midRun = true;
        }
    }
}
