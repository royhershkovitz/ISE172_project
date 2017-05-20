using System;

namespace AlgoTrading.Data
{
    public class MarketItemQuery : MarketClient.DataEntries.IMarketItemQuery
    {
        //A class that will be initiallized by the server as a respond for Query/Sell/Buy request.
        public int price { get; set; }
        public int amount { get; set; }
        public string type { get; set; }
        public string user { get; set; }
        public string commodity { get; set; }

        //Returns this class string which represent the class
        override
        public string ToString()
        {
            return String.Format("Amount: {0}, Price: {1}, Type: {2}, User: {3}, Commodity: {4}", amount, price, type, user, commodity);
        }
    }


}
