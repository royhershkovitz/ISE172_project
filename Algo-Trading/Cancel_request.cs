using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_Trading 
{
    // A class of the user cancel request
    public class Cancel_request
    {
        public String type = "cancelBuySell";
        public int id;

        public Cancel_request(int my_id)
        {
            id = my_id;
        }
    }
}
    /*Sell request
    {"price": 5, "amount": 10, "type": "sell", "commodity": 2, "auth": {"token": privateKey.sign("user99"), "user": "user99"}}
    Buy request
    {"price": 5, "amount": 10, "type": "buy", "commodity": 1, "auth": {"token": privateKey.sign("user99"), "user": "user99"}}
    Cancel request
    {"type": "cancelBuySell", "id": 2, "auth": {"token": privateKey.sign("user99"), "user": "user99"}}
    Query sell/buy request
    {"type": "queryBuySell", "id": 1, "auth": {"token": privateKey.sign("user99"), "user": "user99"}}
    Query user request
    {"type": "queryUser", "auth": {"token": privateKey.sign("user99"), "user": "user99"}}
    Query market request
    {"type": "queryMarket", "commodity": 1, "auth": {"token": privateKey.sign("user99"), "user": "user99"}}
    */
