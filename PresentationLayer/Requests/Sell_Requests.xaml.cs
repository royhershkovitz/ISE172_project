using System.Windows;
using System.Windows.Controls;
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
            WindowTitle = Title;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Requests(); 
        }

        private void Send_Click(object sender, RoutedEventArgs e)
        {
            MarketClientOptions UserOptions = new MarketClientOptions();
            int price = Parser.ReadIntString(Iprice, Result);
            int amount = Parser.ReadIntString(Iamount, Result);
            int commodity = Parser.ReadIntString(ICommodity, Result);
            int response = -1;
            if (price != -1 & amount != -1 & commodity != -1)//check that no - one of them contain illigal input
            {
                response = UserOptions.SendSellRequest(price, commodity, amount);
                if (response != -1) Result.Content = "Your id is: " + response;
                else Result.Content = UserOptions.latestServerResponse;
            }
        }
    }
}
