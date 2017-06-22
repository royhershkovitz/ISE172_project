using System;
using System.Collections.Generic;

namespace AlgoTrading.Data
{
    //A class represting a unit with information about a crtain request. this usually be a part of many in the list of the "QueryUserRequestsRequest" class.
    public class QueryUserUnit : MarketClient.DataEntries.IQueryUserUnit
    {
        public Dictionary<string, Object> Request { get; set; }
        public int id;

        public int GetID()
        {
            return id;
        }

        //Returns this class string which represent the class
        override
        public string ToString()
        {
            string dicToString = "";
            foreach (KeyValuePair<string, Object> kvp in Request)
                dicToString = dicToString + string.Format("{0}: {1}", kvp.Key, kvp.Value.ToString());
            return dicToString;
        }
    }
}
