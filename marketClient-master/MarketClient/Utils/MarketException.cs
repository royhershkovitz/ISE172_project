using System;

namespace MarketClient.Utils
{
    public class MarketException : Exception
    {
        public MarketException()
        {
        }

        public MarketException(string message) : base(message)
        {
            if (message == "No query id")
                Console.WriteLine("No query id");
            else if (message == "Bad commodity") 
            Console.WriteLine("Bad commodity");
        }
    }

}