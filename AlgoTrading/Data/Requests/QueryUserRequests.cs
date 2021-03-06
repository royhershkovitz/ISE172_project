﻿using System;
using System.Collections.Generic;


//This request returns a list of all of the active requests a user has in the server.
namespace AlgoTrading.Data
{
    public class QueryUserRequests
    {

        public string type { get; private set; }

        public QueryUserRequests()
        {
            type = "queryUserRequests";
        }

        //Returns this class string which represent the class
        override
        public string ToString()
        {
            return "Type: "+type;
        }
    }

}
