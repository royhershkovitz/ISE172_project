using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarketClientTest
{
    [TestClass]
    public class UnitTest1
    { 
        /*static void Main(string[] args)
        {
            Console.WriteLine("start unit test");
            UnitTest1 test = new UnitTest1();
            test.TestObjectBasedHTTPPost();
            test.TestSimpleHTTPPost();
            Console.WriteLine("url " + Url + ", user" + User);
        }*/

        // fill those variable with our own data
        private const string Url = "http://ise172.ise.bgu.ac.il";
        private const string User = "user30";
        private const string PrivateKey = @"-----BEGIN RSA PRIVATE KEY-----
                                            MIICXgIBAAKBgQCWtmbOG8Vr+tkQEzRnpWykuDw/CU69uPJS5Nw1Gi9eXom6a9D4
                                            KIWQvrhArC7aTg1q1A+XgEfKTsz0otqkYtzYgAneHZv4NDThUJerxppWQX+JeQYV
                                            YroimM4wgBd7hV4pAsXE45A6EM5pjW7rSSoAUYyJH8larjUymm4iqSBQSwIDAQAB
                                            AoGBAI66ZPfSQw/0uvZHSbzSY+ZG9/82oFR6PzsTtBuyFaQIYeSjUH6DWaJvi+zr
                                            Y1+oxXojJDT07ogAQod3ZxqA6eXGp301olM1529q/CkqVwwlFr8QTfxbdUL9+Tge
                                            FNlWeoTkXtzFxfZT+p6XybnZ9R7bLaG6UM6btxY46Q/TS/qBAkEAwyyE3tdSev4C
                                            ZGJHbEjPEK6o6rWClhfElhn4xW/3ncxxYUQXLpk8MXuZv03qn5g6LmZ59SwgsPH2
                                            KAPMMXmtiwJBAMWuowkj/7YX6M7RUEeoTC2MswGtsbl+OHZeQAoGuFQIen6y/BYK
                                            eOZ3usnCcOavcqkEp1PAdch1mmqB1D2ZwEECQDXKOTxpP5QiGWqtI14WmurQGEHH
                                            kJvpJQbxVXykpSvaQo06BOGU3eANXow43ybo/2/2Ujpd1QyvQtY4Zbhk/o0CQQC1
                                            /PZfPeL2EsDjVdOghJHNBVDu5KdPa6IzZsVx9YnQ4xVSexiUegOfuO4fPICP/0mB
                                            zKT296H3cD0+fFOWemuBAkEApKUOEddKJFp51eTuxoIRTGyqFnBIuVhzsa17GiQ8
                                            0cIu7c2z1VplPld/GQOD1R+7RwQwVsG6TmXWID2C5j/4yA==
                                            -----END RSA PRIVATE KEY-----";
        static void Main(string[] args)
        {
            UnitTest1 test = new UnitTest1();
            Console.WriteLine("UnitTest1");
            test.TestSimpleHTTPPost();
            Console.WriteLine("TestSimpleHTTPPost");
            //test.TestObjectBasedHTTPPost();
            Console.WriteLine("end UnitTest1");

            TestParser test2 = new TestParser();
            Console.WriteLine("test2");
            test2.TestParse();
            Console.WriteLine("end test2");
           
            TestHistory test3 = new TestHistory();
            Console.WriteLine("test3");
            test3.TestAdding("take", -1, false, "toys");
            test3.TestCancel("take", -1, false, "toys");
            test3.TestAdding("give", -2, true, "Books");
            test3.TestAdding("take", -3, false, "toys");
            test3.TestCancel("give", -2, true, "Books");
            test3.TestCancel("give", -2, true, "Books");
            test3.deleteHistory();//delete the file
            Console.WriteLine("end test3");

            TestNonceSet test4 = new TestNonceSet();
            Console.WriteLine("test4");
            test4.TestSet();
            Console.WriteLine("end test4");
            Console.Read();

        }

        [TestMethod]
        public void TestSimpleHTTPPost()
        {
            // Attantion!, this code is not good practice! this was made for the sole purpose of being an example.
            // A real good code, should use defined classes and and not hardcoded values!
            SimpleHTTPClient client = new SimpleHTTPClient(User, PrivateKey);
            var request = new{
                type = "queryUser",
            };
            string response = client.SendPostRequest(Url, request);
            Trace.Write($"Server response is: {response}");
            Console.WriteLine($"Server response is: {response}");
        }

        [TestMethod]
        public void TestObjectBasedHTTPPost()
        {
            // This test query a diffrent site (not the MarketServer)! it's only for demostration.
            // this site doenst accept authentication, it only returns objects.
            string url = "http://ip.jsontest.com/";
            SimpleHTTPClient client = new SimpleHTTPClient(null, null);
            IpAddress ip = new IpAddress { Ip = "8.8.8" };
            IpAddress response = client.SendPostRequest<IpAddress,IpAddress>(url, ip);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Ip);
            Trace.Write($"Server response is: {response.Ip}");
            Console.WriteLine($"Server response is: {response.Ip}");
        }

        private class IpAddress
        {
            public string Ip { get; set; }
        }
    }
}
