using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Threading;

namespace AlgoTrading.Logic
{
    //This class can run on thread multiple times
    public class myAIAlgorithem
    {
        //We will use it to Abort the while loop, and to know if we finish the loop
        private bool running = true;
        private MarketClientOptions UserOptions = new MarketClientOptions(true);
        private static readonly int topActions = 18;
        private static int actions;
        // our tracked commodity
        private static readonly int[] commudities = new int[] { 4, 5, 6 };
        // The tracked commodities AVG
        private static double[] commuditiesAVGvalues = new double[commudities.Length];
        // The budget for each commodity
        private double[] partialBudget = new double[commudities.Length];
        private static readonly int _maxAmount = 15;

        //This function is for the use of other classes to stop the algorithm
        public void StopAlgorithemAI()
        {
            running = false;
        }

        //The algorithem
        public void RunAlgorithemAI()
        {
            actions = topActions;
            while (running)
            {
                getCurrAVG();
                for (int index = 0; index < commuditiesAVGvalues.Length; index++)
                {
                    int avg = (int)Math.Floor(commuditiesAVGvalues[index]);
                    int maxSell = (int)Math.Floor(partialBudget[index] / avg);
                    if (maxSell >= _maxAmount)
                        maxSell = _maxAmount;
                    Trace.WriteLine(index+" "+maxSell + " "+ avg);
                    if (maxSell > 0)
                    {
                        UserOptions.SendBuyRequest(avg - 2, commudities[index], maxSell);
                        partialBudget[index] = partialBudget[index] - maxSell * (avg - 2);
                        reduceAction();
                        UserOptions.SendSellRequest(avg + 2, commudities[index], maxSell);
                        reduceAction();
                    }
                }
                pause();
            }
            running = true;
        }

        // pause the program for 8.2 action
        private void pause()
        {
            if (running)
            {
                Trace.WriteLine("sleep");
                Thread.Sleep(TimeSpan.FromSeconds(10 - 0.1 * actions));//10-0.1*18 = 8.2
                actions = topActions;
            }
            Trace.WriteLine("keep Running: " + running);
        }

        // pause the program for 8.2 action if passed actions rate
        private void reduceAction()
        {
            if (actions > 0)
            {
                actions--;
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
            }
            else
                pause();
        }

        //init the pockets
        public void fundsPocket(double budget)
        {
            for (int index = 0; index < commudities.Length; index++)
                partialBudget[index] = budget / commudities.Length;
        }

        //add budget to the pockets
        public void addFundsToPockets(double budget)
        {
            for (int index = 0; index < commudities.Length; index++)
                partialBudget[index] = partialBudget[index] + budget / commudities.Length;
        }

        //Ask the server for current AVG of the tracked commodity
        public void getCurrAVG()
        {
            String connectionString = @"Data Source=ise172.ise.bgu.ac.il;Initial Catalog=history;User ID=labuser;Password=wonsawheightfly";
            SqlConnection myConnection = new SqlConnection(connectionString);
            Trace.WriteLine("open connection AVG");
            try
            {
                for (int index = 0; index < commudities.Length; index++)
                {
                    myConnection.Open();
                    String sql = @"SELECT Avg(price) FROM dbo.items where commodity=" + commudities[index];
                    SqlCommand myCommand = new SqlCommand(sql, myConnection);
                    SqlDataReader reader = myCommand.ExecuteReader();
                    reduceAction();
                    while (reader.Read())
                        commuditiesAVGvalues[index] = Double.Parse(reader[0].ToString());
                    myConnection.Close();
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.ToString());
            }
            Trace.WriteLine("close connection AVG");
        }
    }//if the price raise up - raise selling prices
}