using System;
using System.Collections.Generic;


//This request returns a list of all of the active requests a user has in the server.
namespace AlgoTrading.Data
{
    public class QueryUserRequests
    {

        public string type { get; private set; }

        public QueryUserRequests()
        {
            type = "queryUserRequests";
        }

        override
        public string ToString()
        {
            return "type: "+type;
        }
    }

}
