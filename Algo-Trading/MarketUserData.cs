using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarketClient;
using MarketClient.Utils;

//@author Roy Hershkovitz, Omri Meshulami, Yakir Green
namespace Algo_Trading
{
    public class MarketUserData : IMarketClient
    {
       /* public static void Main(string[] args)
        {
            
        }*/
        private const string Url = "http://ise172.ise.bgu.ac.il"; // The project great server!1
        private const string User = "user30"; // Our user name
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
                                            -----END RSA PRIVATE KEY-----"; // The key to encription
        private Dictionary<String, int> invoice_buy = new Dictionary<String, int>();
        private Dictionary<String, int> invoice_sell = new Dictionary<String, int>();

        //visual part
         public static void Main(string[] args)
         {
             //to do - cmd visual main - questions and respones
         }
         
        /*static void Main(string[] args)
        {
            Console.WriteLine("start unit test");
            MarketClientTest.UnitTest1 test = new MarketClientTest.UnitTest1();
            Console.WriteLine("omg");
            test.TestObjectBasedHTTPPost();
            Console.WriteLine("1");
            test.TestSimpleHTTPPost();
            Console.WriteLine("2");
            Console.Read();
        }*/

        // get price, commodity and amont (integer)
        // create a 'Buy_request' class, and send it to the server, returns the server's respone
        public int SendBuyRequest(int price, int commodity, int amount)
       {
           Buy_request item = new Buy_request(amount, price, commodity);
           SimpleHTTPClient client = new SimpleHTTPClient();
           String id = client.SendPostRequest(Url, User, SimpleCtyptoLibrary.CreateToken(User, PrivateKey), item);
           Console.WriteLine("id" + id);
           invoice_buy.Add(id, commodity);
           return Int32.Parse(id);
       }

        // get price, commodity and amont (integer)
        // create a 'Sell_request' class, and send it to the server, returns the server's respone
        public int SendSellRequest(int price, int commodity, int amount)
       {
           Sell_request item = new Sell_request(amount, price, commodity);
           SimpleHTTPClient client = new SimpleHTTPClient();
           String id = client.SendPostRequest(Url, User, SimpleCtyptoLibrary.CreateToken(User, PrivateKey), item);
           Console.WriteLine("id" + id);
           invoice_sell.Add(id, commodity);
           return Int32.Parse(id);           
       }

        // get an id (integer)
        // create a 'Query_request' class, and send it to the server, returns the server's respone
        public MarketClient.DataEntries.IMarketItemQuery SendQueryBuySellRequest(int id)
       {
           Query_request item = new Query_request(id);
           SimpleHTTPClient client = new SimpleHTTPClient();
           MarketClient.DataEntries.IMarketItemQuery dictionary = client.SendPostRequest<Query_request, MarketClient.DataEntries.IMarketItemQuery>(Url, User, SimpleCtyptoLibrary.CreateToken(User, PrivateKey), item);
           Console.WriteLine("dic" + dictionary);
           return dictionary;          
       }

        // doens't get anything
        // create a 'Query_user' class, and send it to the server, returns the server's respone
        public MarketClient.DataEntries.IMarketUserData SendQueryUserRequest()
       {
           Query_user item = new Query_user();
           SimpleHTTPClient client = new SimpleHTTPClient();
           MarketClient.DataEntries.IMarketUserData dictionary = client.SendPostRequest<Query_user, MarketClient.DataEntries.IMarketUserData>(Url, User, SimpleCtyptoLibrary.CreateToken(User, PrivateKey), item);
           Console.WriteLine("dic" + dictionary);
           return dictionary;           
       }

        // get an id (integer)
        // create a 'Query_market' class, and send it to the server, returns the server's respone
        public MarketClient.DataEntries.IMarketCommodityOffer SendQueryMarketRequest(int commodity)
       {
           Query_market item = new Query_market(commodity);
           SimpleHTTPClient client = new SimpleHTTPClient();
           MarketClient.DataEntries.IMarketCommodityOffer dictionary = client.SendPostRequest<Query_market, MarketClient.DataEntries.IMarketCommodityOffer>(Url, User, SimpleCtyptoLibrary.CreateToken(User, PrivateKey), item);
           Console.WriteLine("dic" + dictionary);
           return dictionary;          
       }

        // get an id (integer)
        // create a 'Cancel_request' class, and send it to the server, returns the server's respone
        public bool SendCancelBuySellRequest(int id)
       {
           Cancel_request item = new Cancel_request(id);
           SimpleHTTPClient client = new SimpleHTTPClient();
           String respone = client.SendPostRequest(Url, User, SimpleCtyptoLibrary.CreateToken(User, PrivateKey), item);
           Console.WriteLine("respone" + respone);
           return respone.Equals("OK");           
       }
    }
}
