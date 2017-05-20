using System;

namespace AlgoTrading
{
    // A class of the user buy request
    public class BuyRequest
    {
        //An item that will be send to the server in order to preform a buy.
        public string type { get; private set; }
        public int price { get; private set; }
        public int amount { get; private set; }
        public int commodity { get; private set; }        
        public BuyRequest(int my_amount, int my_price, int my_commodity)
        { 
            type = "buy";
            amount = my_amount;
            price = my_price;
            commodity = my_commodity;
        }

        //Returns this class string which represent the class
        override
        public string ToString()
        {
            return String.Format("Type: {0}, Price: {1}, Amount {2}, Commodity: {3}", type, price, amount, commodity);
        }
    }
}
    /*Sell request
    {"price": 5, "amount": 10, "type": "sell", "commodity": 2, "auth": {"token": privateKey.sign("user99"), "user": "user99"}}
    Buy request
    {"price": 5, "amount": 10, "type": "buy", "commodity": 1, "auth": {"token": privateKey.sign("user99"), "user": "user99"}}
    Cancel request
    {"type": "cancelBuySell", "id": 2, "auth": {"token": privateKey.sign("user99"), "user": "user99"}}
    Query sell/buy request
    {"type": "queryBuySell", "id": 1, "auth": {"token": privateKey.sign("user99"), "user": "user99"}}
    Query user request
    {"type": "queryUser", "auth": {"token": privateKey.sign("user99"), "user": "user99"}}
    Query market request
    {"type": "queryMarket", "commodity": 1, "auth": {"token": privateKey.sign("user99"), "user": "user99"}}
    */
