﻿using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarketClient;
using MarketClient.Utils;

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

        [TestMethod]
        public void TestSimpleHTTPPost()
        {
            // Attantion!, this code is not good practice! this was made for the sole purpose of being an example.
            // A real good code, should use defined classes and and not hardcoded values!
            SimpleHTTPClient client = new SimpleHTTPClient();
            var request = new{
                type = "queryUser",
            };
            string response = client.SendPostRequest(Url,User,SimpleCtyptoLibrary.CreateToken(User,PrivateKey), request);
            Trace.Write($"Server response is: {response}");
            Console.WriteLine("TestSimpleHTTPPost " + response);
        }

        [TestMethod]
        public void TestObjectBasedHTTPPost()
        {
            // This test query a diffrent site (not the MarketServer)! it's only for demostration.
            // this site doenst accept authentication, it only returns objects.
            string url = "http://ip.jsontest.com/";
            SimpleHTTPClient client = new SimpleHTTPClient();
            IpAddress ip = new IpAddress {Ip = "8.8.8.8"};
            IpAddress response = client.SendPostRequest<IpAddress,IpAddress>(url, null, null, ip);
            Assert.IsNotNull(response);
            Assert.IsNotNull(response.Ip);
            Trace.Write($"Server response is: {response.Ip}");
            Console.WriteLine("TestObjectBasedHTTPPost " + response);
        }

        private class IpAddress
        {
            public string Ip { get; set; }
        }
    }
}