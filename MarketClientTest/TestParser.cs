using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PresentationLayer;

namespace MarketClientTest
{
    [TestClass]
    class TestParser
    {

        [TestMethod]
        //Test the parser responses to different strings inputs
        public void TestParse()
        {
            //legal and supported inputs
            string textInput = " 1 2 3   4 ";
            Assert.AreEqual(1234, Parser.ReadIntString(textInput));
            Assert.AreEqual(" 1 2 3   4 ", textInput);// didn't change the data
            textInput = "1";
            Assert.AreEqual(1, Parser.ReadIntString(textInput));
            Assert.AreEqual("1", textInput);// didn't change the data
            textInput = "12";
            Assert.AreEqual(12, Parser.ReadIntString(textInput));
            Assert.AreEqual("12", textInput);// didn't change the data
            //Illigal Inputs
            Assert.AreEqual(-1, Parser.ReadIntString(""));
            Assert.AreEqual(-1, Parser.ReadIntString(" "));
            Assert.AreEqual(-1, Parser.ReadIntString("a"));
            Assert.AreEqual(-1, Parser.ReadIntString(" a "));
            Assert.AreEqual(-1, Parser.ReadIntString("1a"));
            Assert.AreEqual(-1, Parser.ReadIntString(" 2 a "));
            Assert.AreEqual(-1, Parser.ReadIntString(" a 2 "));
            Assert.AreEqual(-1, Parser.ReadIntString(" ) * & "));
        }
    }
}
