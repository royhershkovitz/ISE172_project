using System;

namespace AlgoTrading
{
    class SellRequest
    {
        public int price;
        public int amount;
        public int commodity;
        public String type = "sell";
        public SellRequest(int price, int amount, int commodity)
        {
            this.price = price;
            this.amount = amount;
            this.commodity = commodity;
        }
    }

}
