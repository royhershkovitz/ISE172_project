using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketClientTest
{
    [TestClass]
    class TestNonceSet
    {
        [TestMethod]
        public void TestSet()
        {
            myNonceSet nonceSet = new myNonceSet();
            //Check blocking-multiple inserting
            for (int i = 0; i < 100; i++)
                Assert.IsTrue(nonceSet.Add(i));
            for (int i = 0; i < 100; i++)
                Assert.IsFalse(nonceSet.Add(i));
            //check auto deleting
            for (int i = 100; i < 110; i++)
                Assert.IsTrue(nonceSet.Add(i));
            for (int i = 0; i < 110; i++)
                Assert.IsTrue(nonceSet.Add(i));
        }
    }
}
