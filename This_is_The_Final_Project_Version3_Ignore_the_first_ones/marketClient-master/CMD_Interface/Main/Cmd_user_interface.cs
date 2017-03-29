using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTrading
{
    class Cmd_user_interface
    {
        // Shows the user menu
        // Picks up the user choices through the cmd, call the functions according to the user needs
        // Writes on the cmd massages with the answers to the user choises
        static void Main(string[] args)
        {
            ServerCommunication communicate = new ServerCommunication();
            int choose = 0, count = 1;
            while (choose != -1)
            {               
                Console.WriteLine("----------------------------------------Action Number {0}--------------------------------------------",count);
                Console.WriteLine();
                Console.WriteLine("1 - Sell request\n2 - Buy request\n3 - Cancel request\n4 - Query sell/buy request\n5 - Query user request\n6 - Query market request\n-1 - exit");
                try { choose = int.Parse(Console.ReadLine()); }
                catch { }
                Console.Clear();
                switch (choose)
                {
                    //choose Sell request
                    case 1:
                        {
                            Console.WriteLine("\nSell request");
                            int price_buy, amount_buy, commodity_buy;
                            Console.WriteLine("Enter Price");
                            price_buy = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Amount");
                            amount_buy = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Commodity");
                            commodity_buy = int.Parse(Console.ReadLine());
                            Console.WriteLine("Your ID Number is: " + communicate.SendSellRequest(price_buy, commodity_buy, amount_buy));
                            break;
                        }
                    //choose Buy request
                    case 2:
                        {
                            Console.WriteLine("\nBuy request");
                            int price_sell, amount_sell, commodity_sell;
                            Console.WriteLine("Enter Price:");
                            price_sell = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Amount:");
                            amount_sell = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Commodity:");
                            commodity_sell = int.Parse(Console.ReadLine());
                            Console.WriteLine("Your ID Number is: " + communicate.SendBuyRequest(price_sell, commodity_sell, amount_sell));
                            break;
                        }
                    //choose Cancel request
                    case 3:
                        {
                            Console.WriteLine("\nCancel request");
                            int id_cancel;
                            Console.WriteLine("Please Enter the id of the transcation:");
                            id_cancel = int.Parse(Console.ReadLine());
                            bool check = communicate.SendCancelBuySellRequest(id_cancel);
                            if (check == true)
                                Console.WriteLine("The Transcation was cancelled sucssefully");
                            break;
                        }
                    //choose Query sell/buy request
                    case 4:
                        {
                            Console.WriteLine("\nQuery sell/buy request");
                            int id_QuerySell;
                            Console.WriteLine("Please Enter the id of the transcation:");
                            id_QuerySell = int.Parse(Console.ReadLine());
                            MarketItemQuery respond =(MarketItemQuery)communicate.SendQueryBuySellRequest(id_QuerySell);
                            if (respond.RespondOkCheck()) Console.WriteLine("Price:{0} , Amount:{1}, Type:{2}, User:{3}, commodity:{4}", respond.price, respond.amount, respond.type, respond.user, respond.commodity);
                            break;
                        }
                    //choose Query user request
                    case 5:
                        {
                            Console.WriteLine("\nQuery user request");
                            MarketUserData item = (MarketUserData)communicate.SendQueryUserRequest();
                            Dictionary<string, int> d = item.commodities;
                            int j = 1;
                            foreach (var value in d.Values)
                            {
                                Console.Write("Commodity number:{0} is: {1}", j, value);
                                Console.WriteLine();
                                j++;
                            }
                            Console.WriteLine("Your founds is: " + item.funds);
                            Console.Write("Requests list is: ");
                            for (int i = 0; i < item.requests.Count; i++)
                            {
                                if (i < (item.requests.Count - 1))
                                    Console.Write(item.requests[i] + ",");
                                else
                                    Console.Write(item.requests[i]);
                            }
                            break;
                        }
                    //choose Query market request
                    case 6:
                        {
                            Console.WriteLine("\nQuery market request");
                            Console.WriteLine("Please Enter Commodity:");
                            int commodity = int.Parse(Console.ReadLine());
                            MarketCommodityoffer item = (MarketCommodityoffer)communicate.SendQueryMarketRequest(commodity); 
                            if(item.RespondOkCheck()) Console.WriteLine("Best ask price: {0},Best Bid price: {1}", item.ask, item.bid);
                            break;
                        }
                    //choose illegal option or exit
                    default:
                        {
                            if (choose == -1)
                                Console.WriteLine("\nHave a nice day!");
                            else
                                Console.WriteLine("\nPlease insert one of the numbers below!");
                            break;
                        }
                }
                count++;                
                Console.WriteLine("\n---------------------------------------------------------------------------------------------------");               
            }
            Console.Read();
        }
    }
}
