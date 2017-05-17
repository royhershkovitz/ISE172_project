using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTrading
{
    public class MarketUnit : MarketClient.DataEntries.IMarketUnit
    {
        public Dictionary<string, int> info { get; set; }
        public int id;

        public string toString()
        {
            string dicToString="";
            foreach (KeyValuePair<string, int> kvp in info)
            {
                dicToString = dicToString + string.Format(", {0}: {1}", kvp.Key, kvp.Value); //string.Format("Key = {0}, Value = {1}, ", kvp.Key, kvp.Value);                 
            }
            return dicToString;
        }

        public int getID()
        {
            return this.id;
        }
    }
}
