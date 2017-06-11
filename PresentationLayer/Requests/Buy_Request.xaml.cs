using System.Windows;
using System.Windows.Controls;
using AlgoTrading;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for Buy_Request.xaml
    /// </summary>
    public partial class Buy_Request : Page
    {
        public Buy_Request()
        {
            InitializeComponent();
            this.WindowTitle = this.Title;
        }

        private void B_Send_Click(object sender, RoutedEventArgs e)
        {
            MarketClientOptions UserOptions = new MarketClientOptions();
            int price = Parser.ReadIntString(priceInput, Result);
            int amount = Parser.ReadIntString(amountInput, Result);
            int commodity = Parser.ReadIntString(commodityInput, Result);
            int response = -1;
            if (price != -1 & amount != -1 & commodity != -1)//check that no - one of them contain illigal input
            {
                response = UserOptions.SendBuyRequest(price, commodity, amount);
                if (response != -1) Result.Content = "Your id is: " + response;
                else Result.Content = "Error has been occured";
            }
        }

        private void B_Back_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Requests(); 
        }
    }
}
