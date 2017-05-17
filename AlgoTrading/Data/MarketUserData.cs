using System;
using System.Collections.Generic;

namespace AlgoTrading
{

    public class MarketUserData : MarketClient.DataEntries.IMarketUserData
    {
        public Dictionary<string, int> commodities { get; set; }
        public List<int> requests { get; set; }
        public float funds { get; set; }

        override
        public string ToString()
        {
            string listToString = "";
            string dicToString = "";
            for (int i = 0; i < requests.Count; i++)
                listToString += requests[i] + ", ";
            if(listToString != null && listToString.Length > 0)
                listToString.Substring(0, listToString.Length - 1);
            foreach (KeyValuePair<string, int> kvp in commodities) 
                dicToString += string.Format("Commodity [{0}] : {1}, ", kvp.Key, kvp.Value); //string.Format("Key = {0}, Value = {1}, ", kvp.Key, kvp.Value); 
            if (dicToString != null && dicToString.Length > 0)
                dicToString.Substring(0, dicToString.Length-1);
            return String.Format("Founds: {0} {3} Requests: {1}, {4} Commodities: {2}", funds, listToString, dicToString,Environment.NewLine,Environment.NewLine);
        }
    }
}
