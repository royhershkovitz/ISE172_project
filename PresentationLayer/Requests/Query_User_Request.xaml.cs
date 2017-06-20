using System.Windows;
using System.Windows.Controls;
using AlgoTrading;

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
            if (response != null) Result.Text = response.ToString();
            else Result.Text = UserOptions.latestServerResponse;
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Requests(); 
        }
    }
}
