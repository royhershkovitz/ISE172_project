using AlgoTrading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MarketClientTest
{
    [TestClass]
    class TestClientOptions
    {
        private static MarketClientOptions UserOptions;        
        public static void Main(string[] args)
        {
            //createUser
            UserOptions = new MarketClientOptions();
            TestClientOptions test = new TestClientOptions();
            Console.WriteLine("1");
            test.SendSellRequest();
            Console.WriteLine("2");
            test.sendBuyRequest();
            Console.WriteLine("3");
            test.SendCancelBuySellRequest();
            Console.WriteLine("4");
            test.SendQueryBuySellRequest();
            Console.WriteLine("5");
            test.SendQueryUserRequest();
            Console.WriteLine("6");
            test.SendQueryUserRequests();
            Console.WriteLine("7");
            test.SendQueryMarketRequest();
            Console.WriteLine("8");
            test.delleteEveryActiveRequest();
            Console.WriteLine("end test");            
            Console.Read();
        }

        //how to work with Nunit -> //https://piazza.com/class_profile/get_resource/iztt8b0ie121hg/j169adn32ky6n0
        [TestMethod]
        public void SendSellRequest()//1
        {
            //check is working
            Assert.AreNotSame(UserOptions.SendSellRequest(1, 1, 1), -1);

            //anti crasher
            Assert.AreSame(UserOptions.SendSellRequest(1, 1, 999), -1);
            Assert.AreSame(UserOptions.SendSellRequest(1, 999, 1), -1);
            Assert.AreSame(UserOptions.SendSellRequest(999, 1, 1), -1);
            Assert.AreSame(UserOptions.SendSellRequest(-1, -1, -1), -1);
        }

        [TestMethod]
        public void sendBuyRequest()//2
        {
            //check is working
            Assert.AreNotSame(UserOptions.SendBuyRequest(1, 1, 1), -1);

            //anti crasher
            Assert.AreSame(UserOptions.SendBuyRequest(1, 1, 999), -1);
            Assert.AreSame(UserOptions.SendBuyRequest(1, 999, 1), -1);
            Assert.AreSame(UserOptions.SendBuyRequest(999, 1, 1), -1);
            Assert.AreSame(UserOptions.SendBuyRequest(-1, -1, -1), -1);
        }

        [TestMethod]
        public void SendCancelBuySellRequest()//3
        {
            //check is working
            int id = UserOptions.SendSellRequest(1, 1, 1);
            Assert.AreSame(UserOptions.SendCancelBuySellRequest(id), true);

            //anti crasher
            Assert.AreSame(UserOptions.SendCancelBuySellRequest(-1), false);
        }

        [TestMethod]
        public void SendQueryBuySellRequest()//4
        {
            //check is working
            int id = UserOptions.SendSellRequest(1, 1, 1);
            Assert.AreNotSame(UserOptions.SendQueryBuySellRequest(id), "1, 1, 1");//???????

            //anti crasher
            Assert.AreSame(UserOptions.SendQueryBuySellRequest(-1), null);
        }

        [TestMethod]
        public void SendQueryUserRequest()//5
        {
            //check is working
            Assert.AreNotSame(UserOptions.SendQueryUserRequest(), null);
        }

        [TestMethod]
        public void SendQueryMarketRequest()//6
        {
            //check is working
            Assert.AreNotSame(UserOptions.SendQueryMarketRequest(1), null);

            //anti crasher
            Assert.AreSame(UserOptions.SendQueryMarketRequest(-1), null);
        }

        [TestMethod]
        public void SendQueryUserRequests()//7
        {
            //check is working
            Assert.AreNotSame(UserOptions.SendQueryUserRequests(), null);
        }

        [TestMethod]
        public void delleteEveryActiveRequest()//8
        {
            //check is working
            int id = UserOptions.SendSellRequest(1, 1, 1);
            Assert.AreNotSame(UserOptions.SendQueryMarketRequest(id), null);//id is exsist
            Assert.AreNotSame(UserOptions.delleteEveryActiveRequest(1, 1, 1), -1);//delete id
            Assert.AreSame(UserOptions.SendQueryMarketRequest(id), null);//id should not exsist

            //anti crasher
            //TO-DO some inputs and outputs
            //how to work with Nunit -> //https://piazza.com/class_profile/get_resource/iztt8b0ie121hg/j169adn32ky6n0
        }
        /*
         * need to fix test
         * add ama user requests
         * update history when canceling
         */
    }
}
