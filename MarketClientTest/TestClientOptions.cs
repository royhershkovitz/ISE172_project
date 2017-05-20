using AlgoTrading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketClientTest
{
    [TestClass]
    public class TestClientOptions
    {
        private static MarketClientOptions UserOptions;

        [TestInitialize]
        public void Init()
         {
             //createUser
             UserOptions = new MarketClientOptions();
             TestClientOptions test = new TestClientOptions();
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
        public void SendBuyRequest()//2
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
        public void DeleteEveryActiveRequest()//8
        {
            //check is working
            int id = UserOptions.SendSellRequest(500, 1, 1);            
            Assert.AreNotEqual(UserOptions.SendQueryMarketRequest(id), null);//id is exsist
            Assert.AreEqual(UserOptions.DeleteEveryActiveRequest(), true);//delete id
            Assert.AreEqual(UserOptions.SendQueryMarketRequest(id), null);//id should not exsist
        }

        [TestMethod]
        public void DeleteEveryAMAActiveRequest()//8
        {
            //check is working
            int id = UserOptions.SendSellRequest(500, 1, 1);
            MarketClientOptions UserOptions2 = new MarketClientOptions(true);
            int id2 = UserOptions2.SendSellRequest(500, 1, 1);
            Assert.AreNotEqual(UserOptions.SendQueryMarketRequest(id), null);//id is exsist
            Assert.AreNotEqual(UserOptions.SendQueryMarketRequest(id2), null);//id2 is exsist
            Assert.AreEqual(UserOptions.DeleteEveryUnAMAActiveRequest(), true);//delete id
            Assert.AreEqual(UserOptions.SendQueryMarketRequest(id), null);//id should not exsist
            Assert.AreNotEqual(UserOptions.SendQueryMarketRequest(id2), null);//id2 is exsist

            id = UserOptions.SendSellRequest(500, 1, 1);//add id1 again
            Assert.AreNotEqual(UserOptions.SendQueryMarketRequest(id), null);//id is exsist
            Assert.AreNotEqual(UserOptions.SendQueryMarketRequest(id2), null);//id2 is exsist
            Assert.AreEqual(UserOptions.DeleteEveryAMAActiveRequest(), true);//delete id2
            Assert.AreEqual(UserOptions.SendQueryMarketRequest(id2), null);//id2 should not exsist
            Assert.AreNotEqual(UserOptions.SendQueryMarketRequest(id), null);//id is exsist
        }

        //anti crasher
        //TO-DO some inputs and outputs
        //how to work with Nunit -> //https://piazza.com/class_profile/get_resource/iztt8b0ie121hg/j169adn32ky6n0
        /*
         * need to fix test
         * add ama user requests
         * make gui butiful with ouput log and good parsing
         */
    }
}
