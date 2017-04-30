using System;

namespace AlgoTrading 
{
    // A class of the Query_market request
    public class Query_market
    {
        public string type { get; private set; }
        public int id { get; private set; }
        public Query_market(int my_id)
        {
            type = "queryMarket";
            id = my_id;
        }

        override
        public string ToString()
        {
            return String.Format("type: {0}, id: {1}", type, id);
        }
    }
}
