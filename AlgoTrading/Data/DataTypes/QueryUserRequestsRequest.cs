using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTrading
{
    public class QueryUserRequestsRequest : MarketClient.DataEntries.IQueryUserRequestsRequest
    {
        public List<QueryUserUnit> list;

        public void setList(List<QueryUserUnit> list)
        {
            this.list = list;
        }

        public string toString()
        {
            string listToString = "";
            for (int i = 0; i < list.Count; i++)
            { 
                listToString += "ID: " + ((QueryUserUnit)(list[i])).getID() + ((QueryUserUnit)(list[i])).toString() + "\n";                
            }
            return listToString;

        }



    }
    
}
