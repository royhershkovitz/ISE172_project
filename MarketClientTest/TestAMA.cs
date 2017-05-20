using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoTrading;
using System;
using System.Timers;

namespace TestClientOptions
{
    [TestClass]
     public class TestAMA
        {
            private static AlgoTrading.Logic.myAIAlgorithem aI;
            private static MarketClientOptions UserOptions;

            [TestInitialize]
            public void Init()
            {
            //createUser
                aI = new AlgoTrading.Logic.myAIAlgorithem();
                UserOptions = new MarketClientOptions();                
            }

            [TestMethod]
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
