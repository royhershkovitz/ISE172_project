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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            this.WindowTitle = this.Title;
        }        

        private void B_Credits_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Credits(); 
        }

        private void B_Requests_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new Requests(); 
        }

        private void B_History_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new History(); 
        }

        private void B_AI_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new AI(); 
        }

    }
}
