using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTrading
{
    public class QueryUserUnit : MarketClient.DataEntries.IQueryUserUnit
    {
        public Dictionary<string, Object> request { get; set; }
        public int id;

        public string toString()
        {
            string dicToString = "";
            foreach (KeyValuePair<string, Object> kvp in request)
                dicToString = dicToString + string.Format("{0}: {1}", kvp.Key, kvp.Value.ToString()) + " | "; //string.Format("Key = {0}, Value = {1}, ", kvp.Key, kvp.Value); 
            if (dicToString != null && dicToString.Length > 0)
                dicToString.Substring(0, dicToString.Length - 1);
            return dicToString;
        }

        public int getID()
        {
            return this.id;
        }
    }

}
