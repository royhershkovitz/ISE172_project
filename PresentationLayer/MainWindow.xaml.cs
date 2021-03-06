﻿using System.Windows;
[assembly: log4net.Config.XmlConfigurator(Watch = true)]//Important: put it in the startup class, define before use log, should appear just once!!

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
            log4net.GlobalContext.Properties["Counter"] = new AlgoTrading.Data.LOG.Counter();//Optional: define counter in xaml - overall to count logs call, define before use log                     
            log4net.ILog Log = log4net.LogManager.GetLogger("MainWindow.cs");
            Log.Info("program launched");
            InitializeComponent();
            Content = new MainMenu();
        }
    }
}
