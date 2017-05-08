using System;
using System.Collections.Generic;

//This request returns information about the market state of a all commodities
namespace AlgoTrading.Data
{
    class QueryMarketRequest
    {
        public string type { get; private set; }

        public QueryMarketRequest()
        {
            type = "queryAllMarket";
        }

        override
       public string ToString()
        {
            return "type: "+ type;
        }
    }
}
