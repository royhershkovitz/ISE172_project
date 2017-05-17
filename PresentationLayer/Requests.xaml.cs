using System;
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

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Requests.xaml
    /// </summary>
    public partial class Requests : Page
    {
        public Requests()
        {
            InitializeComponent();
            this.WindowTitle = this.Title;
        }

        private void Back_button_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new MainMenu(); 
        }

        private void Buy_Request_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Buy_Request(); 
        }

        private void SellRequest_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Sell_Requests();
        }

        private void Cancelrequest_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Cancel_Request();
        }

        private void QuerysellBuyRequest_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Query_Sell_Buy_Request();
        }

        private void QueryUserRequest_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Query_User_Request();
        }

        private void QueryMarketRequest_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Query_Market_Request();
        }

        private void QueryAllMarketRequest_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Query_All_Market_Request();
        }

        private void QueryuserRequestsRequest_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Query_User_Requests_Request();
        }
    }
}
