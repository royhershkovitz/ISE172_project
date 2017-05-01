using System;

namespace AlgoTrading 
{
    // A class of the user cancel request
    public class CancelRequest
    {
        public string type { get; private set; }
        public int id { get; private set; }

        public CancelRequest(int my_id)
        {
            type = "cancelBuySell"; 
            id = my_id;
        }

        override
        public string ToString()
        {
            return String.Format("type: {0}, id: {1}", type, id);
        }
    }
}
