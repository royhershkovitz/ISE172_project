using System;

namespace AlgoTrading
{
    class BuyRequest
    {
        public int price;
        public int amount;
        public int commodity;
        public String type="buy";
        public BuyRequest(int price,int amount,int commodity)
        {
            this.price = price;
            this.amount = amount;
            this.commodity = commodity;                  
        }

    }
}
