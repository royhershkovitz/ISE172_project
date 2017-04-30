using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for CreditsPage.xaml
    /// </summary>
    public partial class CreditsPage : Page
    {
        public CreditsPage()
        {
            InitializeComponent();
        }
        //retruns to main menu page
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new mainMenu();           
        }
    }
}
