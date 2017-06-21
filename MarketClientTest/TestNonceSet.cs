using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketClientTest
{
    [TestClass]
    class TestNonceSet
    {
        [TestMethod]
        //Test set adding functions. The set should save the last 60 number
        public void TestSet()
        {
            myNonceSet nonceSet = new myNonceSet();
            //Check blocking-multiple inserting
            for (int i = 0; i < 180; i++)
                Assert.IsTrue(nonceSet.Add(i));
            for (int i = 0; i < 180; i++)
                Assert.IsFalse(nonceSet.Add(i));
            //check auto deleting
            //for (int i = 181; i < 190; i++)
            Assert.IsTrue(nonceSet.Add(180));
            for (int i = 0; i < 200; i++)
                Assert.IsTrue(nonceSet.Add(i));
        }
    }
}
