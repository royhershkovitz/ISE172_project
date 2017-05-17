using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AlgoTrading;
using System.Diagnostics;
using System;

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
                Thread newThread = new Thread(new ThreadStart(stopRun));
                newThread.Start();
                aI.runAlgorithemAI();
                float fundsAfter = UserOptions.getFunds();
                Assert.IsTrue(funds > fundsAfter);
                Console.WriteLine(funds + " " + fundsAfter);               
            }
        
            //how to work with Nunit -> //https://piazza.com/class_profile/get_resource/iztt8b0ie121hg/j169adn32ky6n0
            private void stopRun(){
                Thread.Sleep(6000);
                aI.stopAlgorithemAI();//need to define
            }
        }
}
