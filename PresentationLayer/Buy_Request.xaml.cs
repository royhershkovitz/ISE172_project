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
            int price = int.Parse(priceInput.Text);
            int amount = int.Parse(amountInput.Text);
            int commodity = int.Parse(commodityInput.Text);
            int response = UserOptions.SendSellRequest(price, commodity, amount);
            if (response != -1) Result.Content = "Your id is: " + response;
            else Result.Content = Result.Content = "Error has been occured";


        }

        private void B_Back_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Requests(); 
        }
    }
}
