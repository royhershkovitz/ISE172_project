using System;

namespace AlgoTrading
{
    class Cancel_request 
    {
        public String type = "cancelBuySell";
        int id;
        public Cancel_request(int id)
        {
            this.id = id;
        }
    }
}
