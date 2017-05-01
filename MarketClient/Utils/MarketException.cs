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
            if (message == "No price or commodity type/amount" | message == "Bad commodity" | message == "Bad amount" | message == "No query id" | message == "No commodity" |
                 message == "No auth key" | message == "No user or auth token" | message == "Verification failure" | message == "No type key" | message == "Bad request type" |
                 message == "Id not found" | message == "User does not match" | message == "Insufficient funds" | message == "Insufficient commodity")
                Console.WriteLine(message);
        }
    }
}