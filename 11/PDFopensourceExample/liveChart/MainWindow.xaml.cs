using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace liveChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            String connectionString = @"Data Source=ise172.ise.bgu.ac.il;Initial Catalog=history;User ID=labuser;Password=wonsawheightfly";
            SqlConnection myConnection = new SqlConnection(connectionString);
            String sql = @"SELECT timestamp, commodity, amount, price, seller, buyer FROM dbo.items where buyer = 30 OR seller = 30";//String sql = @"SELECT timestamp, commodity, amount, price, seller, buyer FROM dbo.items where buyer = 30 OR seller = 30";
            SqlCommand myCommand;//timestamp, commodity, amount, price, 
        
            try
            {
              myConnection.Open();              
              myCommand = new SqlCommand(sql, myConnection);
              Console.WriteLine("open connection");
              SqlDataReader reader = myCommand.ExecuteReader();
              
              DataTable myData = new DataTable();
              myData.Columns.Add("timestamp", typeof(string));
              myData.Columns.Add("commodity", typeof(string));              
              myData.Columns.Add("amount", typeof(int));
              myData.Columns.Add("price", typeof(int));
              myData.Columns.Add("seller", typeof(string));
              myData.Columns.Add("buyer", typeof(string));

              while (reader.Read())
              {
                  //Console.WriteLine(reader[2]+" "+reader[3]);
                  myData.Rows.Add(reader[0], reader[1], reader[2], reader[3], reader[4], reader[5]);
                  //Console.WriteLine("commodity: " + reader[1] + ", amount: " + reader[2] + ", price: " + reader[3] + ", " + reader[4] + "->" + reader[5] + ", when: " + reader[0]);                  
              }
              Console.WriteLine("print DT");
              foreach (DataRow row in myData.Rows)
                  Console.WriteLine(row.Field<string>(1) + " " + row.Field<int>(3));
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
