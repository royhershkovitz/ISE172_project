using AlgoTrading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;

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
            //Assert.AreNotEqual(UserOptions.SendSellRequest(1, 1, 1), -1);

            //anti crasher
            //Trace.WriteLine(UserOptions.SendSellRequest(1, 1, -1));
            Assert.AreEqual(UserOptions.SendSellRequest(1, 1, -1), -1);
            Assert.AreEqual(UserOptions.SendSellRequest(1, 10, 1), -1);
            Assert.AreEqual(UserOptions.SendSellRequest(10000, 1, 1), -1);
            Assert.AreEqual(UserOptions.SendSellRequest(-1, -1, -1), -1);
        }

        [TestMethod]
        public void sendBuyRequest()//2
        {
            //check is working
            Assert.AreNotEqual(UserOptions.SendBuyRequest(1, 1, 1), -1);

            //anti crasher
            Assert.AreEqual(UserOptions.SendBuyRequest(1, 1, -1), -1);
            Assert.AreEqual(UserOptions.SendBuyRequest(1, 10, 1), -1);
            Assert.AreEqual(UserOptions.SendBuyRequest(10000, 1, 1), -1);
            Assert.AreEqual(UserOptions.SendBuyRequest(-1, -1, -1), -1);
        }

        [TestMethod]
        public void SendCancelBuySellRequest()//3
        {
            //check is working
            int id = UserOptions.SendSellRequest(1, 1, 1);
            Assert.AreEqual(UserOptions.SendCancelBuySellRequest(id), true);

            //anti crasher
            Assert.AreEqual(UserOptions.SendCancelBuySellRequest(-1), false);
        }

        [TestMethod]
        public void SendQueryBuySellRequest()//4
        {
            //check is working
            int id = UserOptions.SendSellRequest(1, 1, 1);
           // Assert.AreNotEqual(UserOptions.SendQueryBuySellRequest(id), "1, 1, 1");//???????

            //anti crasher
            Assert.AreEqual(UserOptions.SendQueryBuySellRequest(-1), null);
        }

        [TestMethod]
        public void SendQueryUserRequest()//5
        {
            //check is working
            Assert.AreNotEqual(UserOptions.SendQueryUserRequest(), null);
        }

        [TestMethod]
        public void SendQueryMarketRequest()//6
        {
            //check is working
            Assert.AreNotEqual(UserOptions.SendQueryMarketRequest(1), null);

            //anti crasher
            Assert.AreEqual(UserOptions.SendQueryMarketRequest(-1), null);
        }

        [TestMethod]
        public void SendQueryUserRequests()//7
        {
            //check is working
            Assert.AreNotEqual(UserOptions.SendQueryUserRequests(), null);
        }

        [TestMethod]
        public void delleteEveryActiveRequest()//8
        {
            //check is working
            int id = UserOptions.SendSellRequest(1, 1, 1);
            Assert.AreNotEqual(UserOptions.SendQueryMarketRequest(id), null);//id is exsist
            Assert.AreEqual(UserOptions.deleteEveryActiveRequest(), true);//delete id
            Assert.AreEqual(UserOptions.SendQueryMarketRequest(id), null);//id should not exsist

            //anti crasher
            //TO-DO some inputs and outputs
            //how to work with Nunit -> //https://piazza.com/class_profile/get_resource/iztt8b0ie121hg/j169adn32ky6n0
        }
        /*
         * need to fix test
         * add ama user requests
         * make gui butiful with ouput log and good parsing
         * update history when canceling
         */
    }
}
