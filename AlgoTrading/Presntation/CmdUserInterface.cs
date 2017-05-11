using System;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]//Important: put it in the startup class, define before use log, should appear just once!!

namespace AlgoTrading
{
    public class CmdUserInterface
    {
        //visual part
        public static void Main(string[] args)
        {
            log4net.GlobalContext.Properties["Counter"] = new Data.LOG.Counter();//Optional: define counter in xaml - overall to count logs call, define before use log
            //visual part
            MarketClientOptions UserOptions = new MarketClientOptions();
            int choose = -1;
            while (choose != 0)
            {
                Console.WriteLine("1 - Sell request\n2 - Buy request\n3 - Cancel request\n4 - Query sell/buy request\n"+
                    "5 - Query user request\n6 - Query market request\n7 - Query all market request\n8 - Query user requests request\n0 - exit");
                choose = readIntString();
                Console.Clear();
                if (choose == 1)
                {
                    Console.WriteLine("/*Sell request*/");
                    Console.WriteLine("Insert price");
                    int price = readIntString();
                    Console.WriteLine("Insert commodity");
                    int commodity = readIntString();
                    Console.WriteLine("Insert amount");
                    int amount = readIntString();
                    int response = UserOptions.SendSellRequest(price, commodity, amount);
                    Console.WriteLine("Response: " + response);
                }
                if (choose == 2)
                {
                    Console.WriteLine("/*Buy request*/");
                    Console.WriteLine("Insert price");
                    int price = readIntString();
                    Console.WriteLine("Insert commodity");
                    int commodity = readIntString();
                    Console.WriteLine("Insert amount");
                    int amount = readIntString();
                    int response = UserOptions.SendBuyRequest(price, commodity, amount);
                    Console.WriteLine("Response: " + response);
                }
                if (choose == 3)
                {
                    Console.WriteLine("/*Cancel request*/");
                    Console.WriteLine("Insert id");
                    int id = readIntString();
                    bool response = UserOptions.SendCancelBuySellRequest(id);
                    Console.WriteLine("Response is: " + response);
                }
                if (choose == 4)
                {
                    Console.WriteLine("/*Query sell/buy request*/");
                    Console.WriteLine("Insert id");
                    int id = readIntString();
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
                    int commodity = readIntString();
                    MarketClient.DataEntries.IMarketCommodityOffer response = UserOptions.SendQueryMarketRequest(commodity);
                    Console.WriteLine("Response: " + response);
                }
                if (choose == 7)
                {
                    Console.WriteLine("/*Query all market active request*/");
                    String response = UserOptions.SendQueryUserRequests();
                    Console.WriteLine("Response: " + response);
                }
                if (choose == 8)
                {
                    Console.WriteLine("/*Query user requests request*/");
                    String response = UserOptions.SendQueryMarketRequest();
                    Console.WriteLine("Response: " + response);
                }
                Console.WriteLine("/*End task*/");
            }
        }

        //run until the user insert int-string (only numbers)
        private static int readIntString()
        {
            string input = tirmSpaces(Console.ReadLine());         
            while (!checkedIntInput(input))
            {
                Console.WriteLine("please insert just integer chars");
                input = tirmSpaces(Console.ReadLine());
            }
            try
            {
                return int.Parse(input);
            }
            catch
            {
                Console.WriteLine("please insert just integer chars, without pressing 'ENTER'");
                return readIntString();
            }
            
        }

        private static string tirmSpaces(string input)
        {
            int i = 0;
            while (i < input.Length)
            {
                if (input[i] == (int)' ')
                {
                    int j = i + 1;
                    while (j < input.Length && input[j] == (int)' ')                    
                        j++;                    
                    input = input.Substring(0, i) + input.Substring(j);
                }
                i++;
            }
            return input;
        }

        //scan the string to find out if it can be parse to int
        private static bool checkedIntInput(string input)
        {
            bool output = true;    
            int i = 0;
            while (i < input.Length & output)
            {
                if (input[i] < (int)'0' | input[i] > (int)'9')
                    output = false;
                i++;
            }

            return output;
        }

        //cmd main - questions and responses  
        // for gui uses only!!
        public void cmd()
        {
            //visual part
            MarketClientOptions UserOptions = new MarketClientOptions();
            int choose = -1;
            while (choose != 0)
            {
                Console.WriteLine("1 - Sell request\n2 - Buy request\n3 - Cancel request\n4 - Query sell/buy request\n5 - Query user request\n6 - Query market request\n0 - exit");
                choose = readIntString();
                Console.Clear();
                if (choose == 1)
                {
                    Console.WriteLine("/*Sell request*/");
                    Console.WriteLine("Insert price");
                    int price = readIntString();
                    Console.WriteLine("Insert commodity");
                    int commodity = readIntString();
                    Console.WriteLine("Insert amount");
                    int amount = readIntString();
                    int response = UserOptions.SendSellRequest(price, commodity, amount);
                    Console.WriteLine("Response: " + response);
                }
                if (choose == 2)
                {
                    Console.WriteLine("/*Buy request*/");
                    Console.WriteLine("Insert price");
                    int price = readIntString();
                    Console.WriteLine("Insert commodity");
                    int commodity = readIntString();
                    Console.WriteLine("Insert amount");
                    int amount = readIntString();
                    int response = UserOptions.SendBuyRequest(price, commodity, amount);
                    Console.WriteLine("Response: " + response);
                }
                if (choose == 3)
                {
                    Console.WriteLine("/*Cancel request*/");
                    Console.WriteLine("Insert id");                    
                    int id = readIntString();
                    bool response = UserOptions.SendCancelBuySellRequest(id);
                    Console.WriteLine("Response is: " + response);
                }
                if (choose == 4)
                {
                    Console.WriteLine("/*Query sell/buy request*/");
                    Console.WriteLine("Insert id");
                    int id = readIntString();
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
                    int commodity = readIntString();
                    MarketClient.DataEntries.IMarketCommodityOffer response = UserOptions.SendQueryMarketRequest(commodity);
                    Console.WriteLine("Response: " + response);
                }
                Console.WriteLine("/*End task*/");
            }
        }
    }
}
