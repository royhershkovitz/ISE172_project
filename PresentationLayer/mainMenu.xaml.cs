using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;


namespace PresentationLayer
{
    /// <summary>
    /// This page is the program main menu
    /// </summary>
    
    public partial class mainMenu : Page
    {
        public mainMenu()
        {
            InitializeComponent();
        }

        //open AMA options
        private void AI_Click(object sender, RoutedEventArgs e)
        {
            throw new NotSupportedException("ToBeImplemented");
        }

        //open credits page
        private void Credits_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new CreditsPage();
        }

        //cmd func important methods
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32", SetLastError = true)]
        public static extern void FreeConsole();

        //this func can be run just once
        private void Requests_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AllocConsole();
                (new AlgoTrading.CmdUserInterface()).cmd();
                //FreeConsole();
            }
            catch
            {
                FreeConsole();
            }

        }

        //exit from the program
        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow) Window.GetWindow(this)).exitProgram();
        }
    }
}
