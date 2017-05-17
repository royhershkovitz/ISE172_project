using System;
using System.Collections.Generic;
using MarketClient;
using System.Threading;
using AlgoTrading.Data;
using System.IO;
using System.Text;

namespace AlgoTrading
{
    public class MarketClientOptions : IMarketClient
    {

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
        //Important: Declare an instance for log4net, define before use log
        //private static readonly log4net.ILog Log = LogHelper.getLogger();// just if you dont want to define one, by yourseld
        private double sec = 0.1;

        // gets price, commodity and amont (integer)
        // creates a 'BuyRequest' class, and send it to the server, returns the server's response
        public int SendBuyRequest(int price, int commodity, int amount)
        {
           log4net.ILog Log = LogHelper.getLogger();
           BuyRequest item = new BuyRequest(amount, price, commodity);
           string id = null;
           try
           {
                id = client.SendPostRequest(Url, User, token, item);
           }
           catch (Exception e)
           {      
                Log.Fatal("Program crushed, Exception: " + e + ", Message: " + e.Message);
                Thread.Sleep(TimeSpan.FromSeconds(sec)); // Sleep some secs after writing on HardDrive
                //Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
            }
           int num = -1;
           if (ServerResponseCheck(id))
           {
               num = int.Parse(id);
               addToHistory("BuyRequest:" + id + ":valid");//type:id:status
               Log.Info(String.Format("User add buy request, id: {0}, details: price {1}, {2}, {3}", num, price, commodity, amount));               
            }
           return num;
        }

        // gets price, commodity and amont (integer)
        // creates a 'SellRequest' class, and send it to the server, returns the server's response
        public int SendSellRequest(int price, int commodity, int amount)
        {
           log4net.ILog Log = LogHelper.getLogger();
           SellRequest item = new SellRequest(amount, price, commodity);
           string id = null;
           try
           {
               id = client.SendPostRequest(Url, User, token, item);
           }
           catch (Exception e)
           {
                Log.Fatal("Program crushed, Exception: " + e + ", Message: " + e.Message);
                Thread.Sleep(TimeSpan.FromSeconds(sec)); // Sleep some secs after writing on HardDrive
                //Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
            }
            int num = -1;
           if (ServerResponseCheck(id))
           {
               num = int.Parse(id);
               addToHistory("SellRequest:" + id + ":valid");//type:id:status
               Log.Info(String.Format("User add sell request, id: {0}, details: price {1}, {2}, {3}", num, price, commodity, amount));
            }
           return num;                   
       }

        // gets an id (integer)
        // creates a 'QueryRequest' class(Query sell/buy request), and send it to the server, returns the server's response
        public MarketClient.DataEntries.IMarketItemQuery SendQueryBuySellRequest(int id)
       {
            log4net.ILog Log = LogHelper.getLogger();
            QueryRequest item = new QueryRequest(id);
            MarketItemQuery response = null;
            try
            {
                response = client.SendPostRequest<QueryRequest, MarketItemQuery>(Url, User, token, item);
            }
            catch (Exception e)
            {
                Log.Fatal("Program crushed, Exception: " + e + ", Message: " + e.Message);
                Thread.Sleep(TimeSpan.FromSeconds(sec)); // Sleep some secs after writing on HardDrive
                //Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
            }
            return response;          
       }

        // doens't get anything
        // creates a 'QueryUser' class, and send it to the server, returns the server's response
        public MarketClient.DataEntries.IMarketUserData SendQueryUserRequest()
       {
            log4net.ILog Log = LogHelper.getLogger();
            QueryUser item = new QueryUser();
            MarketUserData response = null;
            try
            {
                response = client.SendPostRequest<QueryUser, MarketUserData>(Url, User, token, item);
            }
            catch (Exception e)
            {
                Log.Fatal("Program crushed, Exception: " + e + ", Message: " + e.Message);
                Thread.Sleep(TimeSpan.FromSeconds(sec)); // Sleep some secs after writing on HardDrive
                //Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
            }
            return response;           
       }

        // gets an id (integer)
        // creates a 'QueryMarket' class, and send it to the server, returns the server's response
        public MarketClient.DataEntries.IMarketCommodityOffer SendQueryMarketRequest(int commodity)
       {
           log4net.ILog Log = LogHelper.getLogger();
           QueryMarket item = new QueryMarket(commodity);
           MarketCommodityOffer response = null;
           try
           {
               response = client.SendPostRequest<QueryMarket, MarketCommodityOffer>(Url, User, token, item);
           }
           catch (Exception e)
           {
                Log.Fatal("Program crushed, Exception: " + e + ", Message: " + e.Message);
                Thread.Sleep(TimeSpan.FromSeconds(sec)); // Sleep some secs after writing on HardDrive
                //Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
            }
            return response;          
       }

        // gets an id (integer)
        // creates a 'CancelRequest' class, and send it to the server, returns the server's response
        public bool SendCancelBuySellRequest(int id)
        {
             log4net.ILog Log = LogHelper.getLogger();
             CancelRequest item = new CancelRequest(id);
             string response = null;            
             try
             {
                 response = client.SendPostRequest(Url, User, token, item);
             }
             catch (Exception e)
             {
                Log.Fatal("Program crushed, Exception: " + e + ", Message: " + e.Message);
                Thread.Sleep(TimeSpan.FromSeconds(sec)); // Sleep some secs after writing on HardDrive
                //Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
            }
            bool check = false;
             if (ServerResponseCheck(response))
             {
                check = response == "Ok";
                Log.Info("Action " + id + ", been canceled = " + check);
                //if(check)
                    //invoice_buy.Remove(id.ToString());        
             }
             return check;     
        }

        // creates a 'QueryUserRequests' class, and send it to the server, returns the server's response
        public MarketClient.DataEntries.IQueryUserRequestsRequest SendQueryUserRequests()
        {
            log4net.ILog Log = LogHelper.getLogger();
            QueryUserRequests item = new QueryUserRequests();
            QueryUserRequestsRequest response = new QueryUserRequestsRequest();
            List<QueryUserUnit> list;

            try
            {
                list = client.SendPostRequest<QueryUserRequests, List<QueryUserUnit>>(Url, User, token, item);
                response.setList(list);
                return response;
            }
            catch (Exception e)
            {
                Log.Fatal("Program crushed, Exception: " + e + ", Message: " + e.Message);
                Thread.Sleep(TimeSpan.FromSeconds(sec)); // Sleep some secs after writing on HardDrive
                //Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
                return null;
            }            

        }

        // creates a 'QueryMarketRequest' class, and send it to the server, returns the server's response
        public MarketClient.DataEntries.IMarketAll SendQueryMarketRequest()
        {
            log4net.ILog Log = LogHelper.getLogger();
            QueryMarketRequest item = new QueryMarketRequest();
            MarketAll response = new MarketAll();
            List<MarketUnit> list;
            try
            {
                list = client.SendPostRequest<QueryMarketRequest, List<MarketUnit>>(Url, User, token, item);
                response.setList(list);
                return response;
            }
            catch (Exception e)
            {
                Log.Fatal("Program crushed, Exception: " + e + ", Message: " + e.Message);
                Thread.Sleep(TimeSpan.FromSeconds(sec)); // Sleep some secs after writing on HardDrive
                //Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
                return null;
            }
          
        }

        // Gets a String response from the server
        // Checks the meaning of the server 'response' returns true if the 'response' is not an error massage, else print the massage and returns false
        private bool ServerResponseCheck(string response)
        {
            log4net.ILog Log = LogHelper.getLogger();
            bool output = true;
            if (response == "No price or commodity type/amount" | response == "Bad commodity" | response == "Bad amount" | response == "No query id" | response == "No commodity" |
                response == "No auth key" | response == "No user or auth token" | response == "Verification failure" | response == "No type key" | response == "Bad request type" |
                response == "Id not found" | response == "User does not match" | response == "Insufficient funds" | response == "Insufficient commodity" | response == null)
            {
                output = false;
                //Console.WriteLine(response);
                Log.Error("Program server error: " + response);
            }
            return output;
        }

        // add the string 'information' to the file
        public void addToHistory(String information)
        {
            string path = @"C:\Logs\UserActionsLog.txt";
            try
            {
                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    using (StreamWriter sW = File.AppendText(path))
                    {
                        // Add some information to the file.
                        sW.WriteLine("");
                        sW.WriteLine(""+information);
                    }
                }
                else
                {
                    // Create the file.
                    using (FileStream fs = File.Create(path))
                    {
                        Byte[] info = new UTF8Encoding(true).GetBytes("" + information);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Console.Read();
        }

        // read the text from file
        public string readMyHistory()
        {
            //string path = @"..\logs\UserActionsLog.txt";
            string path = @"C:\Logs\UserActionsLog.txt";
            string output = "";
            try
            {
                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    // Open the stream and read it back.
                    using (StreamReader sR = File.OpenText(path))
                    {
                        string ourText = "";
                        while ((ourText = sR.ReadLine()) != null)
                            output = output + "\n" + ourText;
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            return output;
        }

        //returns the user funds
        public float getFunds()
        {
            log4net.ILog Log = LogHelper.getMethodLogger("getFunds");
            QueryUser item = new QueryUser();
            MarketUserData response = null;
            try
            {
                response = client.SendPostRequest<QueryUser, MarketUserData>(Url, User, token, item);
            }
            catch (Exception e)
            {
                Log.Fatal("Program crushed, Exception: " + e + ", Message: " + e.Message);
                Thread.Sleep(TimeSpan.FromSeconds(sec)); // Sleep some secs after writing on HardDrive
                //Console.WriteLine("Exception: " + e + ", Message: " + e.Message);
            }
            return response.funds;
        }

    }
}
