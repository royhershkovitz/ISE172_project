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
            return String.Format("ask: {0}, id: {1}", ask, bid);
        }
    }
}
