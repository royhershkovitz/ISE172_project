﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoTrading.Communication
{
    class SQL_HISTORY_EXAMPLE
    {
        public static void Main(string[] args)
        {
            String connectionString = @"Data Source=ise172.ise.bgu.ac.il;Initial Catalog=history;User ID=labuser;Password=wonsawheightfly";
            SqlConnection myConnection = new SqlConnection(connectionString);
            String sql = @"SELECT timestamp, commodity, amount, price, seller, buyer FROM dbo.items where buyer = 30 OR seller = 30";
            SqlCommand myCommand;//timestamp, commodity, amount, price, 
        
            try
            {
              myConnection.Open();              
              myCommand = new SqlCommand(sql, myConnection);
              Console.WriteLine("open connection");
              SqlDataReader reader = myCommand.ExecuteReader();

              while (reader.Read())
              {
                  Console.WriteLine("commodity: " + reader[1] + ", amount: " + reader[2] + ", price: " + reader[3] + ", " + reader[4] + "->" + reader[5] + ", when: " + reader[0]);
              }
              myConnection.Close();
            }
            catch (Exception e)
            {
              Console.WriteLine(e.ToString());
            }
            Console.WriteLine("close connection");
            Console.Read();
        }
    }
}
