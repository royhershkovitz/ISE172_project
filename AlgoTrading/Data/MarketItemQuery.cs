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
            return String.Format("amount {0}, price: {1}, type: {2}, user: {3}, commodity: {4}", type, amount, price, user, commodity);
        }
    }


}
