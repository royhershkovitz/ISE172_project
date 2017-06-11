using System;
using System.Collections.Generic;

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
                choose = ReadIntString();
                Console.Clear();
                if (choose == 1)
                {
                    Console.WriteLine("/*Sell request*/");
                    Console.WriteLine("Insert price");
                    int price = ReadIntString();
                    Console.WriteLine("Insert commodity");
                    int commodity = ReadIntString();
                    Console.WriteLine("Insert amount");
                    int amount = ReadIntString();
                    int response = UserOptions.SendSellRequest(price, commodity, amount);
                    Console.WriteLine("Response: " + response);
                }
                if (choose == 2)
                {
                    Console.WriteLine("/*Buy request*/");
                    Console.WriteLine("Insert price");
                    int price = ReadIntString();
                    Console.WriteLine("Insert commodity");
                    int commodity = ReadIntString();
                    Console.WriteLine("Insert amount");
                    int amount = ReadIntString();
                    int response = UserOptions.SendBuyRequest(price, commodity, amount);
                    Console.WriteLine("Response: " + response);
                }
                if (choose == 3)
                {
                    Console.WriteLine("/*Cancel request*/");
                    Console.WriteLine("Insert id");
                    int id = ReadIntString();
                    bool response = UserOptions.SendCancelBuySellRequest(id);
                    Console.WriteLine("Response is: " + response);
                }
                if (choose == 4)
                {
                    Console.WriteLine("/*Query sell/buy request*/");
                    Console.WriteLine("Insert id");
                    int id = ReadIntString();
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
                    int commodity = ReadIntString();
                    MarketClient.DataEntries.IMarketCommodityOffer response = UserOptions.SendQueryMarketRequest(commodity);
                    Console.WriteLine("Response: " + response);
                }
                if (choose == 7)
                {
                    Console.WriteLine("/*Query all market request*/");
                    Data.MarketAll response = ((Data.MarketAll) UserOptions.SendQueryMarketRequest());
                    Console.WriteLine("Response: " + response.ToString());
                }
                if (choose == 8)
                {
                    Console.WriteLine("/*Query market requests request*/");
                    List<Data.QueryUserUnit> response = ((List<Data.QueryUserUnit>)UserOptions.SendQueryUserRequests());
                    Console.WriteLine("Response: " + response.ToString());
                }
                Console.WriteLine("/*End task*/");
            }
        }

        //run until the user insert int-string (only numbers)
        private static int ReadIntString()
        {
            string input = TirmSpaces(Console.ReadLine());         
            while (!CheckedIntInput(input))
            {
                Console.WriteLine("please insert just integer chars");
                input = TirmSpaces(Console.ReadLine());
            }
            try
            {
                return int.Parse(input);
            }
            catch
            {
                Console.WriteLine("please insert just integer chars, without pressing 'ENTER'");
                return ReadIntString();
            }
            
        }

        //This function delete every appearance of space
        private static string TirmSpaces(string input)
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
        private static bool CheckedIntInput(string input)
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
    }
}
