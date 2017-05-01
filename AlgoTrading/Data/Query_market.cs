using System;

namespace AlgoTrading 
{
    // A class of the Query_market request
    public class Query_market
    {
        public string type { get; private set; }
        public int commodity { get; private set; }
        public Query_market(int my_id)
        {
            type = "queryMarket";
            commodity = my_id;
        }

        override
        public string ToString()
        {
            return String.Format("type: {0}, commodity: {1}", type, commodity);
        }
    }
}
