using System;

namespace AlgoTrading
{
    class QueryMarket
    {
        public String type = "queryMarket";
        public int commodity;
        public QueryMarket(int commodity)
        {
            this.commodity = commodity;
        }
    }
}
