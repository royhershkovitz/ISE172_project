using System;
using System.Collections.Generic;
using System.IO;
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
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Page
    {
        public History()
        {
            InitializeComponent();
            this.WindowTitle = this.Title;
            readHistory();
        }

        //read the text from the file
        public void readHistory()
        {        
            string path = @"C:\logs\UserActionsLog.txt";
            string output = "";
            try
            {
                // Delete the file if it exists.
                if (File.Exists(path))
                {
                    // Open the stream and read it back.
                    using (StreamReader sR = File.OpenText(path))
                    {
                        string ourText = "";
                        while ((ourText = sR.ReadLine()) != null)
                            output = output + ourText + "\n";
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            Result.Text = output;
        }
    
        private void back_Click(object sender, RoutedEventArgs e)
        {
            ((Window)this.Parent).Content = new MainMenu(); 
        }
    }
}
