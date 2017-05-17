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
using AlgoTrading;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for SellRequests.xaml
    /// </summary>
    public partial class Sell_Requests : Page
    {
        public Sell_Requests()
        {
            InitializeComponent();
            this.WindowTitle = this.Title;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Requests(); 
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            MarketClientOptions UserOptions = new MarketClientOptions();
            int price = int.Parse(Iprice.Text);
            int amount = int.Parse(Iamount.Text);
            int commodity = int.Parse(ICommodity.Text);
            Result.Content = "Your id is: " + (UserOptions.SendSellRequest(price, commodity, amount)).ToString();
        }
    }
}
