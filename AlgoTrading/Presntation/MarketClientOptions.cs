using System;
using System.Collections.Generic;
using MarketClient;

namespace AlgoTrading
{
    public class MarketClientOptions : IMarketClient    {

        private SimpleHTTPClient client = new SimpleHTTPClient();
        //private string token = "OSZUIiYeNQHAbfPULVVVqTEXCO9Bc6hLH/EtXzmcqf2OIyiQP2Y2vu1gjvAqvPhN/FoFbLV0vcdYpS8nRzfrHL3JvDPFIAIufmZSD42WDlw9lbeZ7QrUYYDNsILCALIRxCpc8FxsbAYqzRi/wWcvBC971Zel2+MXb5r+8c3F5Uk=";
        private string token = MarketClient.Utils.SimpleCtyptoLibrary.CreateToken(User, PrivateKey);
        private const string Url = "http://ise172.ise.bgu.ac.il";//:8008";
        public const string User = "user30";
        public const string PrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
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

        protected static Dictionary<String, int> invoice_buy = new Dictionary<String, int>();
        protected static Dictionary<String, int> invoice_sell = new Dictionary<String, int>();
        // gets price, commodity and amont (integer)
        // creates a 'Buy_request' class, and send it to the server, returns the server's response
        public int SendBuyRequest(int price, int commodity, int amount)
        {
           Buy_request item = new Buy_request(amount, price, commodity);
           string id = null;
           try
           {
                id = client.SendPostRequest(Url, User, token, item);
           }
           catch (Exception e)
           {
               Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
           }
           int num = -1;
           if (Server_response_check(id))
           {
               invoice_buy.Add(id, commodity);
               num = int.Parse(id);
           }
           return num;
        }

        // gets price, commodity and amont (integer)
        // creates a 'Sell_request' class, and send it to the server, returns the server's response
        public int SendSellRequest(int price, int commodity, int amount)
        {
           Sell_request item = new Sell_request(amount, price, commodity);
           string id = null;
           try
           {
               id = client.SendPostRequest(Url, User, token, item);
           }
           catch (Exception e)
           {
               Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
           }
           int num = -1;
           if (Server_response_check(id))
           {
               invoice_sell.Add(id, commodity);
               num = int.Parse(id);
           }
           return num;                   
       }

        // gets an id (integer)
        // creates a 'Query_request' class(Query sell/buy request), and send it to the server, returns the server's response
          public MarketClient.DataEntries.IMarketItemQuery SendQueryBuySellRequest(int id)
       {
           Query_request item = new Query_request(id);
           MarketItemQuery response = null;
            try
            {
                response = client.SendPostRequest<Query_request, MarketItemQuery>(Url, User, token, item);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
            }
           return response;          
       }

        // doens't get anything
        // creates a 'Query_user' class, and send it to the server, returns the server's response
       public MarketClient.DataEntries.IMarketUserData SendQueryUserRequest()
       {
            Query_user item = new Query_user();
            MarketUserData response = null;
            try
            {
                response = client.SendPostRequest<Query_user, MarketUserData>(Url, User, token, item);
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
            }      
           return response;           
       }

        // gets an id (integer)
        // creates a 'Query_market' class, and send it to the server, returns the server's response
       public MarketClient.DataEntries.IMarketCommodityOffer SendQueryMarketRequest(int commodity)
       {
           Query_market item = new Query_market(commodity);
           MarketCommodityOffer response = null;
           try
           {
               response = client.SendPostRequest<Query_market, MarketCommodityOffer>(Url, User, token, item);
           }
           catch (Exception e)
           {
               Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
           }
           return response;          
       }

        // gets an id (integer)
        // creates a 'Cancel_request' class, and send it to the server, returns the server's response
        public bool SendCancelBuySellRequest(int id)
        {
             Cancel_request item = new Cancel_request(id);
             string response = null;            
             try
             {
                 response = client.SendPostRequest(Url, User, token, item);
             }
             catch (Exception e)
             {
                 Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
             }
             bool check = false;
             if (Server_response_check(response))
             {
                 check = response == "Ok";
                 invoice_buy.Remove(id.ToString());              
             }
             return check;     
        }

        // Gets a String response from the server
        // Checks the meaning of the server 'response' returns true if the 'response' is not an error massage, else print the massage and returns false
        private bool Server_response_check(string response)
        {
            bool output = true;
            if (response == "No price or commodity type/amount" | response == "Bad commodity" | response == "Bad amount" | response == "No query id" | response == "No commodity" |
                response == "No auth key" | response == "No user or auth token" | response == "Verification failure" | response == "No type key" | response == "Bad request type" |
                response == "Id not found" | response == "User does not match" | response == "Insufficient funds" | response == "Insufficient commodity" | response == null)
            {
                output = false;
                Console.WriteLine(response);
            }
            return output;
        }
    }
}
