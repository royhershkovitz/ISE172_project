using System;

namespace AlgoTrading 
{
    // A class of the sell request
    public class SellRequest
    {
        public string type { get; private set; }
        public int price { get; private set; }
        public int amount { get; private set; }
        public int commodity { get; private set; }
        public SellRequest(int my_amount, int my_price, int my_commodity)
        {
            type = "sell";
            amount = my_amount;
            price = my_price;
            commodity = my_commodity;
        }

        override
        public string ToString()
        {
            return String.Format("Type: {0}, Price: {1}, Amount {2}, Commodity: {3}", type, price, amount, commodity);
        }
    }
}