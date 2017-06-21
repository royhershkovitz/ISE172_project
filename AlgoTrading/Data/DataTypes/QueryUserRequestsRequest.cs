using System.Collections.Generic;

namespace AlgoTrading.Data
{
    //This request returns a list of all of the active requests a user has in the server.
    public class QueryUserRequestsRequest : MarketClient.DataEntries.IQueryUserRequestsRequest
    {
        public List<QueryUserUnit> _list;

        public void SetList(List<QueryUserUnit> list)
        {
            _list = list;
        }

        //Returns this class string which represent the class
        override
        public string ToString()
        {
            string listToString = "";
            for (int i = 0; i < _list.Count; i++)
                listToString += "ID: " + ((QueryUserUnit)(_list[i])).GetID() + ((QueryUserUnit)(_list[i])).ToString() + "\n";                
            
            return listToString;
        }
    }    
}
