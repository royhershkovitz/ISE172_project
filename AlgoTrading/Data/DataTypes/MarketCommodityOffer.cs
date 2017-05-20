using System;


namespace AlgoTrading.Data
{
    //A class that will be initiallized by the server as a respond for Market request.
    public class MarketCommodityOffer : MarketClient.DataEntries.IMarketCommodityOffer
    {
        public int ask { get; set; }
        public int bid { get; set; }

        //Returns this class string which represent the class
        override
        public string ToString()
        {
            return String.Format("Ask: {0}, Bid: {1}", ask, bid);
        }
    }
}
