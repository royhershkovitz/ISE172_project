using System;
using NUnit.Framework;
using System.Timers;
//[assembly: log4net.Config.XmlConfigurator(Watch = true)]//Important: put it in the startup class, define before use log, should appear just once!!

namespace AlgoTrading.Tests
{
    [TestFixture]
    public class TestAMA
    {
        private static AlgoTrading.Logic.myAIAlgorithem aI;
        private static MarketClientOptions UserOptions;
        [SetUp]
        public void CreateUser()
        {
            log4net.GlobalContext.Properties["Counter"] = new Data.LOG.Counter();//Optional: define counter in xaml - overall to count logs call, define before use log
            aI = new Logic.myAIAlgorithem();
            UserOptions = new MarketClientOptions();
        }

        [Test]
        public void TestAlgorithem()
        {
            float funds = UserOptions.GetFunds();
            System.Timers.Timer myTimer = new System.Timers.Timer(2000);
            // Hook up the Elapsed event for the timer. 
            myTimer.Elapsed += OnTimedEvent;
            myTimer.Enabled = true;
            aI.RunAlgorithemAI();
            float fundsAfter = UserOptions.GetFunds();
            Assert.IsTrue(funds > fundsAfter);
            Console.WriteLine(funds + " " + fundsAfter);
        }

        //how to work with Nunit -> //https://piazza.com/class_profile/get_resource/iztt8b0ie121hg/j169adn32ky6n0
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            Console.WriteLine("wait");
            Console.WriteLine("aborting");
            aI.StopAlgorithemAI();//need to define
            Console.WriteLine("stopped");
        }
    }
}
