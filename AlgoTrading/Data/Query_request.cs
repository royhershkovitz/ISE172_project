using System;

namespace AlgoTrading 
{
    // A class of the Query_request request
    public class Query_request
    {
        public string type { get; private set; }
        public int id { get; private set; }

        public Query_request(int my_id)
        {
            type = "queryBuySell";
            id = my_id;
        }

        override
        public string ToString()
        {
            return String.Format("type: {0}, id: {1}", type, id);
        }
    }
}