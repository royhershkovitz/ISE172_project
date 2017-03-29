using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient;
using MarketClient.DataEntries;

namespace AlgoTrading
{
    class ServerCommunication : IMarketClient

    {
        private SimpleHTTPClient client = new SimpleHTTPClient();
        private string token = MarketClient.Utils.SimpleCtyptoLibrary.CreateToken(User, PrivateKey);
        private const string Url = "http://ise172.ise.bgu.ac.il";
        private const string User = "user30";
        private const string PrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
                                            MIICXgIBAAKBgQCWtmbOG8Vr+tkQEzRnpWykuDw/CU69uPJS5Nw1Gi9eXom6a9D4
                                            KIWQvrhArC7aTg1q1A+XgEfKTsz0otqkYtzYgAneHZv4NDThUJerxppWQX+JeQYV
                                            YroimM4wgBd7hV4pAsXE45A6EM5pjW7rSSoAUYyJH8larjUymm4iqSBQSwIDAQAB
                                            AoGBAI66ZPfSQw/0uvZHSbzSY+ZG9/82oFR6PzsTtBuyFaQIYeSjUH6DWaJvi+zr
                                            Y1+oxXojJDT07ogAQod3ZxqA6eXGp301olM1529q/CkqVwwlFr8QTfxbdUL9+Tge
                                            FNlWeoTkXtzFxfZT+p6XybnZ9R7bLaG6UM6btxY46Q/TS/qBAkEAwyyE3tdSev4C
                                            ZGJHbEjPEK6o6rWClhfElhn4xW/3ncxxYUQXLpk8MXuZv03qn5g6LmZ59SwgsPH2
                                            KAPMMXmtiwJBAMWuowkj/7YX6M7RUEeoTC2MswGtsbl+OHZeQAoGuFQIen6y/BYK
                                            eOZ3usnCcOavcqkEp1PAdch1mmqB1D2ZwEECQDXKOTxpP5QiGWqtI14WmurQGEHH
                                            kJvpJQbxVXykpSvaQo06BOGU3eANXow43ybo/2/2Ujpd1QyvQtY4Zbhk/o0CQQC1
                                            /PZfPeL2EsDjVdOghJHNBVDu5KdPa6IzZsVx9YnQ4xVSexiUegOfuO4fPICP/0mB
                                            zKT296H3cD0+fFOWemuBAkEApKUOEddKJFp51eTuxoIRTGyqFnBIuVhzsa17GiQ8
                                            0cIu7c2z1VplPld/GQOD1R+7RwQwVsG6TmXWID2C5j/4yA==
                                            -----END RSA PRIVATE KEY-----";

        // Gets a price, commodity and amount for sell request
        // Returns an int respone from the server
        public int SendSellRequest(int price, int commodity, int amount)
        {
            SellRequest item = new SellRequest(price, commodity, amount);
            String response = client.SendPostRequest(Url, User, token, item);
            int num = -1;
            if (Server_respone_check(response))
                num = Int32.Parse(response);
            return num;
        }

        // Gets a price, commodity and amount for buy request
        // Returns an int respone from the server
        public int SendBuyRequest(int price, int commodity, int amount)
        {
            BuyRequest item = new BuyRequest(price, commodity, amount);
            String response = client.SendPostRequest(Url, User, token, item);
            int num = -1;
            if (Server_respone_check(response))
               num = Int32.Parse(response);
            return num;
        }

        // Gets an id, for cancel request
        // Returns an boolean respone from the server
        public bool SendCancelBuySellRequest(int id)
        {
            Cancel_request item = new Cancel_request(id);
            String response = client.SendPostRequest(Url, User, token, item);
            bool check = false;
            if(Server_respone_check(response))
                check = response == "Ok";
            return check;
        }
        
        // Returns an IMarketUserData item - respone from the server
        public IMarketUserData SendQueryUserRequest()
        {            
            MarketUserData item = new MarketUserData();
            item.Builder();
            return item;
        }

        // Gets an id for Query Buy/Sell request
        // Returns an IMarketItemQuery item - respone from the server
        public IMarketItemQuery SendQueryBuySellRequest(int id)
        {
            QueryBuySell item = new QueryBuySell(id);
            MarketItemQuery response = new MarketItemQuery();
            response.Builder(item);
            return response;
        }

        // Gets a commodity for Query Market request
        // Returns an IMarketCommodityOffer item - respone from the server
        public IMarketCommodityOffer SendQueryMarketRequest(int commodity)
        {
            QueryMarket item = new QueryMarket(commodity);
            MarketCommodityoffer response = new MarketCommodityoffer();
            response.Builder(item);
            return response;
        }
                
        // Gets a String respone from the server
        // Check the meaning of the server 'respone' returns true if the 'respone' is not an error massage, else print the massage and returns false
        public bool Server_respone_check(String response)
        {
            bool output = true;
            if (response == "No price or commodity type/amount" | response == "Bad commodity" | response == "Bad amount" | response == "No query id" | response == "No commodity" |
                response == "No auth key"   | response == "No type key" | response == "Bad request type" |
                response == "Id not found" || response == "User does not match" || response == "Insufficient funds" || response == "Insufficient commodity")
            {
                output = false;
                Console.WriteLine(response);
            }
            return output;               
        }
    }
}

