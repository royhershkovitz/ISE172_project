using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_Trading
{
    class cmd_input
    {
        //visual part
        public static void Main(string[] args)
        {
        //visual part
            Console.WriteLine("1 - Sell request\n2 - Buy request\n3 - Cancel request\n4 - Query sell/buy request\n5 - Query user request\n6 - Query market request\n-1 - exit");
            MarketUserData client = new MarketUserData();
            int choose = int.Parse(Console.ReadLine());
            while (choose != -1)
            {
                 if (choose == 1)
                 {
                     Console.WriteLine("/*Sell request*/");
                     Console.WriteLine("Insert price");
                     int price = int.Parse(Console.ReadLine());
                     Console.WriteLine("Insert commodity");
                     int commodity = int.Parse(Console.ReadLine());
                     Console.WriteLine("Insert amount");
                     int amount = int.Parse(Console.ReadLine());
                     int respone = client.SendSellRequest(price, commodity, amount);
                     Console.WriteLine("respone: " + respone);
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
                     int respone = client.SendBuyRequest(price, commodity, amount);
                     Console.WriteLine("respone: " + respone);
                 }
                 if (choose == 3)
                 {
                     Console.WriteLine("/*Cancel request*/");
                     Console.WriteLine("Insert id");
                     int id = int.Parse(Console.ReadLine());
                     MarketClient.DataEntries.IMarketItemQuery respone = client.SendQueryBuySellRequest(id);
                     Console.WriteLine("respone: " + respone);
                 }
                 if (choose == 4)
                 {
                     Console.WriteLine("/*Query sell/buy request*/");
                     Console.WriteLine("Insert id");
                     int id = int.Parse(Console.ReadLine());
                     MarketClient.DataEntries.IMarketItemQuery respone = client.SendQueryBuySellRequest(id);
                     Console.WriteLine("respone: " + respone);
                 }
                 if (choose == 5)
                 {
                     Console.WriteLine("/*Query user request*/");
                     MarketClient.DataEntries.IMarketUserData respone = client.SendQueryUserRequest();
                     Console.WriteLine("respone: " + respone);
                 }
                 if (choose == 6)
                 {
                     Console.WriteLine("/*Query market request*/");
                     Console.WriteLine("Insert commodity");
                     int commodity = int.Parse(Console.ReadLine());
                     MarketClient.DataEntries.IMarketCommodityOffer respone = client.SendQueryMarketRequest(commodity);
                     Console.WriteLine("respone: " + respone);
                 }
                 Console.WriteLine("/*End task*/");
                 Console.WriteLine("1 - Sell request\n2 - Buy request\n3 - Cancel request\n4 - Query sell/buy request\n5 - Query user request\n6 - Query market request\n-1 - exit");
                 choose = int.Parse(Console.ReadLine());
                }
            }
            //cmd main - questions and respones        
    }
}
