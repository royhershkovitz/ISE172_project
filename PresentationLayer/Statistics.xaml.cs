using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Data.SqlClient;
using System.Diagnostics;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class Statistics : Page
    {
        private static readonly String connectionString = @"Data Source=ise172.ise.bgu.ac.il;Initial Catalog=history;User ID=labuser;Password=wonsawheightfly";
        private static SqlConnection myConnection;
        private static List<KeyValuePair<string, float>> MyValue = null;
        private static List<KeyValuePair<string, int>> MyValue2 = null;
        private static List<KeyValuePair<string, float>> MyValue3 = null;
        private static List<KeyValuePair<string, float>> MyValue4 = null;

        //Constructor read the information from the server
        public Statistics()
        {
            InitializeComponent();
            pieChart.Visibility = Visibility.Hidden;
            lineChart2.Visibility = Visibility.Hidden;
            PieChart2.Visibility = Visibility.Hidden;
            if (MyValue == null)
            {
                String c0 = setGraph("SELECT TOP 50 Avg(price) AS AveragePrice FROM items WHERE commodity=0  and amount=1");
                String c1 = setGraph("SELECT TOP 50 Avg(price) AS AveragePrice FROM items WHERE commodity=1  and amount=1");
                String c2 = setGraph("SELECT TOP 50 Avg(price) AS AveragePrice FROM items WHERE commodity=2  and amount=1");
                String c3 = setGraph("SELECT TOP 50 Avg(price) AS AveragePrice FROM items WHERE commodity=3  and amount=1");
                String c4 = setGraph("SELECT TOP 50 Avg(price) AS AveragePrice FROM items WHERE commodity=4  and amount=1");
                String c5 = setGraph("SELECT TOP 50 Avg(price) AS AveragePrice FROM items WHERE commodity=5  and amount=1");
                String c6 = setGraph("SELECT TOP 50 Avg(price) AS AveragePrice FROM items WHERE commodity=6  and amount=1");
                String c7 = setGraph("SELECT TOP 50 Avg(price) AS AveragePrice FROM items WHERE commodity=7  and amount=1");
                String c8 = setGraph("SELECT TOP 50 Avg(price) AS AveragePrice FROM items WHERE commodity=8  and amount=1");
                String c9 = setGraph("SELECT TOP 50 Avg(price) AS AveragePrice FROM items WHERE commodity=9  and amount=1");


                MyValue = new List<KeyValuePair<string, float>>();
                MyValue.Add(new KeyValuePair<string, float>("0", float.Parse(c0)));
                MyValue.Add(new KeyValuePair<string, float>("1", float.Parse(c1)));
                MyValue.Add(new KeyValuePair<string, float>("2", float.Parse(c2)));
                MyValue.Add(new KeyValuePair<string, float>("3", float.Parse(c3)));
                MyValue.Add(new KeyValuePair<string, float>("4", float.Parse(c4)));
                MyValue.Add(new KeyValuePair<string, float>("5", float.Parse(c5)));
                MyValue.Add(new KeyValuePair<string, float>("6", float.Parse(c6)));
                MyValue.Add(new KeyValuePair<string, float>("7", float.Parse(c7)));
                MyValue.Add(new KeyValuePair<string, float>("8", float.Parse(c8)));
                MyValue.Add(new KeyValuePair<string, float>("9", float.Parse(c9)));
            }
            LineChart1.DataContext = MyValue;


            if (MyValue2 == null)
            {
                String buyer = setGraph("SELECT COUNT(*) FROM items where buyer=30");
                String seller = setGraph("SELECT COUNT(*) FROM items where seller=30");
                MyValue2 = new List<KeyValuePair<string, int>>();
                MyValue2.Add(new KeyValuePair<string, int>("Buyer", int.Parse(buyer)));
                MyValue2.Add(new KeyValuePair<string, int>("Seller", int.Parse(seller)));
            }
            pieChart.DataContext = MyValue2;

            DateTime today = DateTime.Now.Date;
            today = today.AddDays(-7);



            if (MyValue3 == null)
            {
                String day1 = setGraph("select TOP 50 Sum(price) from items where timestamp >= '" + today.Year + "-" + today.Month + "-" + today.Day + "' and timestamp <='" + today.AddDays(1).Year + "-" + today.AddDays(1).Month + "-" + today.AddDays(1).Day + "' and amount=1");
                today = today.AddDays(1);
                String day2 = setGraph("select TOP 50 Sum(price) from items where timestamp >= '" + today.Year + "-" + today.Month + "-" + today.Day + "' and timestamp <='" + today.AddDays(1).Year + "-" + today.AddDays(1).Month + "-" + today.AddDays(1).Day + "' and amount=1");
                today = today.AddDays(1);
                String day3 = setGraph("select TOP 50 Sum(price) from items where timestamp >= '" + today.Year + "-" + today.Month + "-" + today.Day + "' and timestamp <='" + today.AddDays(1).Year + "-" + today.AddDays(1).Month + "-" + today.AddDays(1).Day + "' and amount=1");
                today = today.AddDays(1);
                String day4 = setGraph("select TOP 50 Sum(price) from items where timestamp >= '" + today.Year + "-" + today.Month + "-" + today.Day + "' and timestamp <='" + today.AddDays(1).Year + "-" + today.AddDays(1).Month + "-" + today.AddDays(1).Day + "' and amount=1");
                today = today.AddDays(1);
                String day5 = setGraph("select TOP 50 Sum(price) from items where timestamp >= '" + today.Year + "-" + today.Month + "-" + today.Day + "' and timestamp <='" + today.AddDays(1).Year + "-" + today.AddDays(1).Month + "-" + today.AddDays(1).Day + "' and amount=1");
                today = today.AddDays(1);
                String day6 = setGraph("select TOP 50 Sum(price) from items where timestamp >= '" + today.Year + "-" + today.Month + "-" + today.Day + "' and timestamp <='" + today.AddDays(1).Year + "-" + today.AddDays(1).Month + "-" + today.AddDays(1).Day + "' and amount=1");
                today = today.AddDays(1);
                String day7 = setGraph("select TOP 50 Sum(price) from items where timestamp >= '" + today.Year + "-" + today.Month + "-" + today.Day + "' and timestamp <='" + today.AddDays(1).Year + "-" + today.AddDays(1).Month + "-" + today.AddDays(1).Day + "' and amount=1");
                MyValue3 = new List<KeyValuePair<string, float>>();
                MyValue3.Add(new KeyValuePair<string, float>(DateTime.Now.Date.AddDays(-7).ToShortDateString(), float.Parse(day1)));
                MyValue3.Add(new KeyValuePair<string, float>(DateTime.Now.Date.AddDays(-6).ToShortDateString(), float.Parse(day2)));
                MyValue3.Add(new KeyValuePair<string, float>(DateTime.Now.Date.AddDays(-5).ToShortDateString(), float.Parse(day3)));
                MyValue3.Add(new KeyValuePair<string, float>(DateTime.Now.Date.AddDays(-4).ToShortDateString(), float.Parse(day4)));
                MyValue3.Add(new KeyValuePair<string, float>(DateTime.Now.Date.AddDays(-3).ToShortDateString(), float.Parse(day5)));
                MyValue3.Add(new KeyValuePair<string, float>(DateTime.Now.Date.AddDays(-2).ToShortDateString(), float.Parse(day6)));
                MyValue3.Add(new KeyValuePair<string, float>(DateTime.Now.Date.AddDays(-1).ToShortDateString(), float.Parse(day7)));
            }
            lineChart2.DataContext = MyValue3;

            if (MyValue4 == null)
            {
                String maxSellPrice = setGraph("select Max(price) from items");
                String minSellPrice = setGraph("select Min(price) from items");
                MyValue4 = new List<KeyValuePair<string, float>>();
                MyValue4.Add(new KeyValuePair<string, float>("Max Sell Price", float.Parse(maxSellPrice)));
                MyValue4.Add(new KeyValuePair<string, float>("Min Sell Price", float.Parse(minSellPrice)));
            }

            PieChart2.DataContext = MyValue4;
        }

        //Get query and asks the server
        public String setGraph(String query)
        {
            String a = "";
            myConnection = new SqlConnection(connectionString);
            try
            {
                myConnection.Open();
                String sql = query;

                SqlCommand myCommand;
                SqlDataReader myReader;
                myCommand = new SqlCommand(sql, myConnection);
                myReader = myCommand.ExecuteReader();
                while (myReader.Read())
                {
                    a = myReader[0].ToString();
                    Trace.WriteLine(a);
                }
            }
            catch
            {
                System.Diagnostics.Trace.WriteLine("Error2");
            }
            myConnection.Close();



            return a;


        }

        //retrurns to the previous page
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            ((Window)Parent).Content = new MainMenu();

        }

        //hidden all the graph except to the graph of the average price per comudity grapth
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LineChart1.Visibility = Visibility.Visible;
            pieChart.Visibility = Visibility.Hidden;
            lineChart2.Visibility = Visibility.Hidden;
            PieChart2.Visibility = Visibility.Hidden;
        }

        //hidden all the graph except to our buy vs sell pie chart
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            LineChart1.Visibility = Visibility.Hidden;
            pieChart.Visibility = Visibility.Visible;
            lineChart2.Visibility = Visibility.Hidden;
            PieChart2.Visibility = Visibility.Hidden;
        }

        //hidden all the graph except to the graph of the all deals prices that done 
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            LineChart1.Visibility = Visibility.Hidden;
            pieChart.Visibility = Visibility.Hidden;
            lineChart2.Visibility = Visibility.Visible;
            PieChart2.Visibility = Visibility.Hidden;
        }

        //hidden all the graph except to maxprice vs min price pie chart
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            LineChart1.Visibility = Visibility.Hidden;
            pieChart.Visibility = Visibility.Hidden;
            lineChart2.Visibility = Visibility.Hidden;
            PieChart2.Visibility = Visibility.Visible;
        }
    }
}
