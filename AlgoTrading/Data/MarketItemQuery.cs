using System;

namespace AlgoTrading
{
    public class MarketItemQuery : MarketClient.DataEntries.IMarketItemQuery
    {        
        public int price { get; set; }
        public int amount { get; set; }
        public string type { get; set; }
        public string user { get; set; }
        public string commodity { get; set; }        

        override
        public string ToString()
        {
            return String.Format("Amount: {0}, Price: {1}, Type: {2}, User: {3}, Commodity: {4}", amount,price,type, user, commodity);
        }
    }


}
