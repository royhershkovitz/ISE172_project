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
    /// Interaction logic for CancelRequest.xaml
    /// </summary>
    public partial class Cancel_Request : Page
    {
        public Cancel_Request()
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
            bool check = UserOptions.SendCancelBuySellRequest(int.Parse(idInput.Text));
            if (check) Result.Content = "Canceled Succesfully!";
            else Result.Content = "Wrong id";

        }
    }
}
