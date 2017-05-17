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
using MarketClient;
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
            MarketClient.DataEntries.IMarketItemQuery response = UserOptions.SendQueryBuySellRequest(int.Parse(idInput.Text));            
            Result.Content = response.ToString();

        }
    }
}
