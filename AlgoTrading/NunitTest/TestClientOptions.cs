using NUnit.Framework;
//[assembly: log4net.Config.XmlConfigurator(Watch = true)]//Important: put it in the startup class, define before use log, should appear just once!!

namespace AlgoTrading.Tests
{
    [TestFixture]
    public class TestClientOptions
    {
        private MarketClientOptions UserOptions;
        [SetUp]
        public void CreateUser()
        {
            log4net.GlobalContext.Properties["Counter"] = new Data.LOG.Counter();//Optional: define counter in xaml - overall to count logs call, define before use log
            UserOptions = new MarketClientOptions();
        }

        //how to work with Nunit -> //https://piazza.com/class_profile/get_resource/iztt8b0ie121hg/j169adn32ky6n0
        [Test]
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

        [Test]
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

        [Test]
        public void SendCancelBuySellRequest()//3
        {
            //check is working
            int id = UserOptions.SendSellRequest(1, 1, 1);
            Assert.AreEqual(UserOptions.SendCancelBuySellRequest(id), true);

            //anti crasher
            Assert.AreEqual(UserOptions.SendCancelBuySellRequest(-1), false);
        }

        [Test]
        public void SendQueryBuySellRequest()//4
        {
            //check is working
            int id = UserOptions.SendSellRequest(1, 1, 1);
            // Assert.AreNotEqual(UserOptions.SendQueryBuySellRequest(id), "1, 1, 1");//???????

            //anti crasher
            Assert.AreEqual(UserOptions.SendQueryBuySellRequest(-1), null);
        }

        [Test]
        public void SendQueryUserRequest()//5
        {
            //check is working
            Assert.AreNotEqual(UserOptions.SendQueryUserRequest(), null);
        }

        [Test]
        public void SendQueryMarketRequest()//6
        {
            //check is working
            Assert.AreNotEqual(UserOptions.SendQueryMarketRequest(1), null);

            //anti crasher
            Assert.AreEqual(UserOptions.SendQueryMarketRequest(-1), null);
        }

        [Test]
        public void SendQueryUserRequests()//7
        {
            //check is working
            Assert.AreNotEqual(UserOptions.SendQueryUserRequests(), null);
        }

        [Test]
        public void DelleteEveryActiveRequest()//8
        {
            //check is working
            int id = UserOptions.SendSellRequest(1, 1, 1);
            Assert.AreNotEqual(UserOptions.SendQueryMarketRequest(id), null);//id is exsist
            Assert.AreEqual(UserOptions.DeleteEveryActiveRequest(), true);//delete id
            Assert.AreEqual(UserOptions.SendQueryMarketRequest(id), null);//id should not exsist

            //anti crasher
            //TO-DO some inputs and outputs
            //how to work with Nunit -> //https://piazza.com/class_profile/get_resource/iztt8b0ie121hg/j169adn32ky6n0
        }

    }
}
