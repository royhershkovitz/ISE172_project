using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoTrading;
using System.Diagnostics;
using System;
using System.Timers;

namespace TestClientOptions
    {
    [TestClass]
        class TestAMA
        {
            private static AlgoTrading.Logic.myAIAlgorithem aI;
            private static MarketClientOptions UserOptions;       
        
            public static void Main(string[] args)
            {
            //createUser
                aI = new AlgoTrading.Logic.myAIAlgorithem();
                UserOptions = new MarketClientOptions();
                TestAMA test = new TestAMA();
                Console.WriteLine("1");
                test.testAlgorithem();
                Console.WriteLine("2");
                Console.Read();
            }

            [TestMethod]
            public void testAlgorithem()
            {
                float funds = UserOptions.getFunds();
                System.Timers.Timer myTimer = new System.Timers.Timer(2000);
                // Hook up the Elapsed event for the timer. 
                myTimer.Elapsed += OnTimedEvent;
                myTimer.Enabled = true;
                aI.runAlgorithemAI();
                float fundsAfter = UserOptions.getFunds();
                Assert.IsTrue(funds > fundsAfter);
                Console.WriteLine(funds + " " + fundsAfter);               
            }
        
            //how to work with Nunit -> //https://piazza.com/class_profile/get_resource/iztt8b0ie121hg/j169adn32ky6n0
            private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
                Console.WriteLine("wait");
                Console.WriteLine("aborting");
                aI.stopAlgorithemAI();//need to define
                Console.WriteLine("stopped");
            }
        }
}
