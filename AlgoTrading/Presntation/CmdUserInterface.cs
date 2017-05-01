using System;

namespace AlgoTrading
{
    public class CmdUserInterface
    {
        //visual part
        public static void Main(string [] arga)
        {
            //visual part            
            MarketClientOptions UserOptions = new MarketClientOptions();
            int choose = 0;
            while (choose != -1)
            {
                Console.WriteLine("1 - Sell request\n2 - Buy request\n3 - Cancel request\n4 - Query sell/buy request\n5 - Query user request\n6 - Query market request\n-1 - exit");
                choose = int.Parse(Console.ReadLine());
                Console.Clear();
                if (choose == 1)
                {
                    Console.WriteLine("/*Sell request*/");
                    Console.WriteLine("Insert price");
                    int price = int.Parse(Console.ReadLine());
                    Console.WriteLine("Insert commodity");
                    int commodity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Insert amount");
                    int amount = int.Parse(Console.ReadLine());
                    int response = UserOptions.SendSellRequest(price, commodity, amount);
                    Console.WriteLine("Response: " + response);
                }
                if (choose == 2)
                {
                    Console.WriteLine("/*Buy request*/");
                    Console.WriteLine("Insert price");
                    int price = int.Parse(Console.ReadLine());
                    Console.WriteLine("Insert commodity");
                    int commodity = int.Parse(Console.ReadLine());
                    Console.WriteLine("Insert amount");
                    int amount = int.Parse(Console.ReadLine());
                    int response = UserOptions.SendBuyRequest(price, commodity, amount);
                    Console.WriteLine("Response: " + response);
                }
                if (choose == 3)
                {
                    Console.WriteLine("/*Cancel request*/");
                    Console.WriteLine("Insert id");
                    int id = int.Parse(Console.ReadLine());
                    bool response = UserOptions.SendCancelBuySellRequest(id);
                    Console.WriteLine("Response is: " + response);
                }
                if (choose == 4)
                {
                    Console.WriteLine("/*Query sell/buy request*/");
                    Console.WriteLine("Insert id");
                    int id = int.Parse(Console.ReadLine());
                    MarketClient.DataEntries.IMarketItemQuery response = UserOptions.SendQueryBuySellRequest(id);
                    Console.WriteLine("Response: " + response);
                }
                if (choose == 5)
                {
                    Console.WriteLine("/*Query user request*/");
                    MarketClient.DataEntries.IMarketUserData response = UserOptions.SendQueryUserRequest();
                    Console.WriteLine("Response: " + response);
                }
                if (choose == 6)
                {
                    Console.WriteLine("/*Query market request*/");
                    Console.WriteLine("Insert commodity");
                    int commodity = int.Parse(Console.ReadLine());
                    MarketClient.DataEntries.IMarketCommodityOffer response = UserOptions.SendQueryMarketRequest(commodity);
                    Console.WriteLine("Response: " + response);
                }
                Console.WriteLine("/*End task*/");
            }
        }
        //cmd main - questions and responses  
    
        // for gui uses only!!
        public void cmd()
            {
                //visual part            
                MarketClientOptions UserOptions = new MarketClientOptions();
                int choose = 0;            
                while (choose != -1)
                {
                    Console.WriteLine("1 - Sell request\n2 - Buy request\n3 - Cancel request\n4 - Query sell/buy request\n5 - Query user request\n6 - Query market request\n-1 - exit");
                    choose = int.Parse(Console.ReadLine());
                    Console.Clear();
                    if (choose == 1)
                     {
                        Console.WriteLine("/*Sell request*/");
                        Console.WriteLine("Insert price");
                        int price = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insert commodity");
                        int commodity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insert amount");
                        int amount = int.Parse(Console.ReadLine());
                        int response = UserOptions.SendSellRequest(price, commodity, amount);
                        Console.WriteLine("Response: " + response);
                    }
                     if (choose == 2)
                     {
                        Console.WriteLine("/*Buy request*/");
                        Console.WriteLine("Insert price");
                        int price = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insert commodity");
                        int commodity = int.Parse(Console.ReadLine());
                        Console.WriteLine("Insert amount");
                        int amount = int.Parse(Console.ReadLine());
                        int response = UserOptions.SendBuyRequest(price, commodity, amount);
                        Console.WriteLine("Response: " + response);
                    }
                     if (choose == 3)
                     {
                        Console.WriteLine("/*Cancel request*/");
                        Console.WriteLine("Insert id");
                        int id = int.Parse(Console.ReadLine());
                        bool response = UserOptions.SendCancelBuySellRequest(id);
                        Console.WriteLine("Response is: " + response);
                     }
                     if (choose == 4)
                     {
                        Console.WriteLine("/*Query sell/buy request*/");
                        Console.WriteLine("Insert id");
                        int id = int.Parse(Console.ReadLine());
                        MarketClient.DataEntries.IMarketItemQuery response = UserOptions.SendQueryBuySellRequest(id);
                        Console.WriteLine("Response: " + response);
                    }
                     if (choose == 5)
                     {
                        Console.WriteLine("/*Query user request*/");
                        MarketClient.DataEntries.IMarketUserData response = UserOptions.SendQueryUserRequest();
                        Console.WriteLine("Response: " + response);
                    }
                     if (choose == 6)
                     {
                        Console.WriteLine("/*Query market request*/");
                        Console.WriteLine("Insert commodity");
                        int commodity = int.Parse(Console.ReadLine());
                        MarketClient.DataEntries.IMarketCommodityOffer response = UserOptions.SendQueryMarketRequest(commodity);
                        Console.WriteLine("Response: " + response);
                    }
                     Console.WriteLine("/*End task*/");                 
                }
            }
            //cmd main - questions and responses        
    }
}
