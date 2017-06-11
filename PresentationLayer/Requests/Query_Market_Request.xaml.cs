using System.Windows;
using System.Windows.Controls;
using AlgoTrading;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Query_Market_Request.xaml
    /// </summary>
    public partial class Query_Market_Request : Page
    {
        public Query_Market_Request()
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
            int commodity = Parser.ReadIntString(input, Result);
            if (commodity != -1)//check that no - one of them contain illigal input
            {
                MarketClient.DataEntries.IMarketCommodityOffer response = UserOptions.SendQueryMarketRequest(commodity);
                if (response != null) Result.Content = response.ToString();
                else Result.Content = "Error has been occured";
            }
        }
    }
}
