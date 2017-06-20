using System.Windows;
using System.Windows.Controls;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainMenu.xaml
    /// </summary>
    public partial class MainMenu : Page
    {
        public MainMenu()
        {
            InitializeComponent();
            WindowTitle = Title;
        }

        //botton fucntion call another page to appear
        private void B_Credits_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Credits();
        }

        //botton fucntion call another page to appear
        private void B_Requests_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Requests();
        }

        //botton fucntion call another page to appear
        private void B_History_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new History();
        }

        //botton fucntion call another page to appear
        private void B_AI_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new AI();
        }

        //botton fucntion call another page to appear
        private void B_Stats_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Statistics();
        }

    }
}
