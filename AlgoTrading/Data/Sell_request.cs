using System;

namespace AlgoTrading 
{
    // A class of the sell request
    public class Sell_request
    {
        public string type { get; private set; }
        public int price { get; private set; }
        public int amount { get; private set; }
        public int commodity { get; private set; }
        public Sell_request(int my_amount, int my_price, int my_commodity)
        {
            type = "sell";
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