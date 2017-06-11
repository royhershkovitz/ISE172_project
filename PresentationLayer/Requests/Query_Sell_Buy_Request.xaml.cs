using System.Windows;
using System.Windows.Controls;
using AlgoTrading;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Query_Sell_Buy_Request.xaml
    /// </summary>
    public partial class Query_Sell_Buy_Request : Page
    {
        public Query_Sell_Buy_Request()
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
            int id = Parser.ReadIntString(idInput, Result);
            if (id != -1)//check that no - one of them contain illigal input
            {
                MarketClient.DataEntries.IMarketItemQuery response = UserOptions.SendQueryBuySellRequest(id);
                if (response != null) Result.Content = response.ToString();
                else Result.Content = "Error has been occured";
            }

        }
    }
}
