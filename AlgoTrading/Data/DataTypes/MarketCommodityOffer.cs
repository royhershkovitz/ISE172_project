using System;


namespace AlgoTrading
{
    public class MarketCommodityOffer : MarketClient.DataEntries.IMarketCommodityOffer
    {
        public int ask { get; set; }
        public int bid { get; set; }

        override
        public string ToString()
        {
            return String.Format("Ask: {0}, Bid: {1}", ask, bid);
        }
    }
}
