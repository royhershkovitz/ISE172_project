using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTrading.Data.History
{
    //This class use to turn user action to csv
    public class HistoryUnit
    {
        public int ID { get; set; }
        public string Type { get; set; }        
        public int Price { get; set; }
        public int Commodity { get; set; }
        public int Amount { get; set; }       
        public bool IsAma { get; set; }
        public string Validation { get; set; }

        //returns a string that represent the class
        override
        public string ToString()
        {
            return ID + "," + Type + "," + IsAma + "," + Price + "," + Commodity + "," + Amount + "," + Validation;
        }
    }    
    
    //"SellRequest", parsedID, _isAMA, price + ":" + commodity + ":" + amount
}
