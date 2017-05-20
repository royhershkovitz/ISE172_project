using System;

namespace AlgoTrading 
{
    // A class of the Query_request request
    public class QueryRequest
    {
        public string type { get; private set; }
        public int id { get; private set; }

        public QueryRequest(int my_id)
        {
            type = "queryBuySell";
            id = my_id;
        }

        //Returns this class string which represent the class
        override
        public string ToString()
        {
            return String.Format("Type: {0}, ID: {1}", type, id);
        }
    }
}