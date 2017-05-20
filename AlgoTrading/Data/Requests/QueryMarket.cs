using System;

namespace AlgoTrading 
{
    // A class of the Query_market request
    public class QueryMarket
    {
        public string type { get; private set; }
        public int commodity { get; private set; }
        public QueryMarket(int my_id)
        {
            type = "queryMarket";
            commodity = my_id;
        }

        //Returns this class string which represent the class
        override
        public string ToString()
        {
            return String.Format("Type: {0}, Commodity: {1}", type, commodity);
        }
    }
}
