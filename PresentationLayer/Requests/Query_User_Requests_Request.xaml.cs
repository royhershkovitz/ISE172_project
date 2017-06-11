using System.Windows;
using System.Windows.Controls;
using AlgoTrading;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Query_User_Requests_Request.xaml
    /// </summary>
    public partial class Query_User_Requests_Request : Page
    {
        public Query_User_Requests_Request()
        {
            InitializeComponent();
            this.WindowTitle = this.Title;
            MarketClientOptions UserOptions = new MarketClientOptions();
            AlgoTrading.Data.QueryUserRequestsRequest response = (AlgoTrading.Data.QueryUserRequestsRequest)UserOptions.SendQueryUserRequests();
            if (response != null) Result.Text = response.ToString();
            else Result.Text = "Error has been occured";
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Requests(); 
        }
    }
}
