using System.Windows;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]//Important: put it in the startup class, define before use log

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
   
    public partial class MainWindow : Window
    {
        // opens the main menu page
        public MainWindow()
        {
            InitializeComponent();
            Content = new mainMenu();
        }

        // These function close the progran
        public void exitProgram()
        {
            Close();
        }
    }
}
