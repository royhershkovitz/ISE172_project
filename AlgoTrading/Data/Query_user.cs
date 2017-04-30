using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTrading 
{
    // A class of the Query_user request
    public class Query_user
    {
        public string type { get; private set; }
        public Query_user()
        {
            type = "queryUser";
        }

        override
        public string ToString()
        {
            return String.Format("type: {0}", type);
        }
    }
}