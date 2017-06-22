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
        private int actions;
        // our tracked commodity
        private static readonly int[] commudities = new int[] { 4, 5, 6 };
        // The tracked commodities AVG
        private static double[] commuditiesAVGvalues = new double[commudities.Length];
        // The budget for each commodity
        private float[] partialBudget = new float[commudities.Length];
        private static readonly int _sellingFactor = 3;//sellRequest(avg + _sellingFactor)
        private static readonly int _buyingFactor = 2;//sellRequest(avg - _buyingFactor)
        private static readonly int _maxAmount = 15;
        private static readonly double Secs = 0.1;

        //This function is for the use of other classes to stop the algorithm
        public void StopAlgorithemAI()
        {
            running = false;
        }

        //This function is for calculating the current investment
        public float remainMoneyInPockets()
        {
            float output = 0;
            foreach (float pocket in partialBudget)
                output = output + pocket;
            return output;
        }

        //The algorithem
        public void RunAlgorithemAI()
        {
            actions = topActions;
            while (running)
            {
                getCurrAVG();
                for (int index = 0; index < commuditiesAVGvalues.Length & running; index++)// If AVG cause problems or user request to stops the AI
                {
                    int avg = (int)Math.Floor(commuditiesAVGvalues[index]);
                    int maxSell = (int)Math.Floor(partialBudget[index] / avg);
                    if (maxSell >= _maxAmount)
                        maxSell = _maxAmount;
                    if (maxSell > 0)
                    {
                        UserOptions.SendBuyRequest(avg - _buyingFactor, commudities[index], maxSell);
                        partialBudget[index] = partialBudget[index] - maxSell * (avg - _buyingFactor);
                        reduceAction();
                        UserOptions.SendSellRequest(avg + _sellingFactor, commudities[index], maxSell);
                        reduceAction();
                    }
                }
                pause();
            }
            running = true;
        }

        // pause the program for 8.2 secs for 18 actions
        private void pause()
        {
            if (running)
            {
                Trace.WriteLine("sleep");
                Thread.Sleep(TimeSpan.FromSeconds(10 - Secs * actions));//maxActions = 18, 10 - 0.1*18 = 8.2
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
                Thread.Sleep(TimeSpan.FromSeconds(Secs));
            }
            else
                pause();
        }

        //init the pockets
        public void fundsPocket(float budget)
        {
            Trace.WriteLine(budget);
            float pocket = budget / commudities.Length;
            Trace.WriteLine(pocket);
            for (int index = 0; index < commudities.Length; index++)
                partialBudget[index] = pocket;
        }

        //add budget to the pockets
        public void addFundsToPockets(float budget)
        {
            Trace.WriteLine("added to puckets : " + budget);
            float pocket = budget / commudities.Length;
            Trace.WriteLine("added per puckets : " + pocket);
            for (int index = 0; index < commudities.Length; index++)
                partialBudget[index] = partialBudget[index] + pocket;
        }

        //Ask the server for current AVG of the tracked commodity
        private void getCurrAVG()
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
                        if (reader[0] != null)
                            commuditiesAVGvalues[index] = Double.Parse(reader[0].ToString());
                        else//if the server reset the data
                            commuditiesAVGvalues[index] = 10;//initial serevr prices
                    myConnection.Close();
                }
            }
            catch (Exception e)
            {
                try
                {
                    myConnection.Close();
                    Trace.WriteLine("close connection");
                }
                catch { Trace.WriteLine("Fail close connection"); }
                Trace.WriteLine("Catched SQL exception " + e.Message);
                running = false;
            }
            Trace.WriteLine("End AVG");
        }
    }//if the price raise up - raise selling prices
}