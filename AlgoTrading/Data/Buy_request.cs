using System;

namespace AlgoTrading 
{
    // A class of the user buy request
    public class Buy_request
    {
        public string type { get; private set; }
        public int price { get; private set; }
        public int amount { get; private set; }
        public int commodity { get; private set; }        
        public Buy_request(int my_amount, int my_price, int my_commodity)
        { 
            type = "buy";
            amount = my_amount;
            price = my_price;
            commodity = my_commodity;
        }

        override
        public string ToString()
        {
            return String.Format("type: {0}, price: {1}, amount {2}, commodity: {3}", type, price, amount, commodity);
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
