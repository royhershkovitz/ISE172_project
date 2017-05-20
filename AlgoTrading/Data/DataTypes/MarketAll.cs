using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTrading.Data
{
    //A class that will be initiallized by the server as a respond for MarketAll request.
    public class MarketAll : MarketClient.DataEntries.IMarketAll
    {
        public List<MarketUnit> list;

        public void SetList(List<MarketUnit> list)
        {
            this.list = list;
        }

        //Returns this class string which represent the class
        override
        public string ToString()
        {
            string listToString = "";
            for (int i = 0; i < list.Count; i++)
                listToString += "ID: " + ((MarketUnit)(list[i])).GetID() + ((MarketUnit)(list[i])).ToString() + "\n";
            if (listToString != null && listToString.Length > 0)
                listToString.Substring(0, listToString.Length - 1);
            return listToString;
        }

    }
}
