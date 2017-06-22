using System.Collections.Generic;

namespace AlgoTrading.Data
{
    public class MarketUnit : MarketClient.DataEntries.IMarketUnit
    {
        //A class represnting a unit that will be initialized by the server, this unit will be a part of a list in the MarketAll class.
        public Dictionary<string, int> Info { get; set; }
        public int id;

        public int GetID()
        {
            return id;
        }

        //Returns this class string which represent the class
        override
        public string ToString()
        {
            string dicToString="";
            foreach (KeyValuePair<string, int> kvp in Info)
            {
                dicToString = dicToString + string.Format("{0}: {1}", kvp.Key, kvp.Value);
            }
            return dicToString;
        }
    }
}
