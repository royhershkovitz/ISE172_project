using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTrading
{
    public class MarketAll : MarketClient.DataEntries.IMarketAll
    {
        public List<MarketUnit> list;

        public void setList(List<MarketUnit> list)
        {
            this.list = list;
        }

        public string toString()
        {
            string listToString = "";
            for (int i = 0; i < list.Count; i++)
                listToString += "ID: " + ((MarketUnit)(list[i])).getID() + ((MarketUnit)(list[i])).toString() + "\n";
            if (listToString != null && listToString.Length > 0)
                listToString.Substring(0, listToString.Length - 1);
            return listToString;
        }

    }
}
