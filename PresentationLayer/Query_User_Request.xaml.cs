﻿using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using AlgoTrading;
using MarketClient;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Query_User_Request.xaml
    /// </summary>
    public partial class Query_User_Request : Page
    {
        public Query_User_Request()
        {
            InitializeComponent();
            this.WindowTitle = this.Title;
            MarketClientOptions UserOptions = new MarketClientOptions();
            MarketClient.DataEntries.IMarketUserData response = UserOptions.SendQueryUserRequest();
            Result.Text = response.ToString();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Requests(); 
        }
    }
}