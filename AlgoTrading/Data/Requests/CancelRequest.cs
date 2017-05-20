using System;

namespace AlgoTrading 
{
    // A class of the user cancel request
    public class CancelRequest
    {
        //An item that will be send to the server in order to preform a cancel of an order.
        public string type { get; private set; }
        public int id { get; private set; }

        public CancelRequest(int my_id)
        {
            type = "cancelBuySell"; 
            id = my_id;
        }

        //Returns this class string which represent the class
        override
        public string ToString()
        {
            return String.Format("Type: {0}, ID: {1}", type, id);
        }
    }
}
