using System;

namespace AlgoTrading
{
    class Cancel_request 
    {
        public String type = "cancelBuySell";
        public int id;
        public Cancel_request(int id)
        {
            this.id = id;
        }
    }
}
