using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using AlgoTrading;
using System.Diagnostics;
using System.Timers;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for AI.xaml
    /// </summary>
    // for AI uses
    public partial class AI : Page
    {        
        private Thread _run = null;
        private AlgoTrading.Logic.myAIAlgorithem _ama = null;
        private MarketClientOptions _UserOptions = new MarketClientOptions();
        private System.Timers.Timer myTimer;
        private log4net.ILog log;
        private float startFunds;
        //constructor
        public AI()
        {

            log = log4net.LogManager.GetLogger("");
            InitializeComponent();
            this.WindowTitle = this.Title;
            startFunds = _UserOptions.getFunds();
            myFunds.Text = startFunds.ToString();
            //the timer will auto update the user funds
            myTimer = new System.Timers.Timer(10000);
            // Hook up the Elapsed event for the timer. 
            myTimer.Elapsed += OnTimedEvent;
            myTimer.AutoReset = true;
            start(null, null);
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {         
            this.Dispatcher.Invoke(() =>
                {
                    this.updateFunds();// your code here.
                });
        }
        
        //stopping the algorithem
        private void stop(object sender, RoutedEventArgs e)
        {
            if (_ama != null) {
                if (_run != null && _run.IsAlive)
                {                    
                    myTimer.Enabled = false;
                    myStatus.Text = "Please wait..";//why it is unreachable code?
                    log.Info("AI A");
                    Thread.Sleep(TimeSpan.FromSeconds(0.01));
                    _ama.stopAlgorithemAI();
                    Trace.WriteLine("stop pressed");
                    while (_ama.canAbortThread())
                    {
                        //Trace.WriteLine("waits to thread");//unreachable code
                    }
                    //_run.Abort();
                    _run.Join();
                    Trace.WriteLine("AI aborted");
                    updateFunds();
                    myStatus.Text = "Stopped";
                }
            }
        }

        //updating the funds value
        public void updateFunds()
        {
            float tValue = _UserOptions.getFunds();
            float revenue = tValue-startFunds;
            myFunds.Text = tValue.ToString() + ", revenue " + revenue;
        }


        private void back(object sender, RoutedEventArgs e)
        {
            stop(null, null);
            ((Window)this.Parent).Content = new MainMenu();
        }

        //runs the algorithem on thread
        private void start(object sender, RoutedEventArgs e)
        {
            if (_run == null || !_run.IsAlive) {
                myStatus.Text = "Runnig";
                log.Info("AI started");
                Thread.Sleep(TimeSpan.FromSeconds(0.01));
                myTimer.Enabled = true;
                _ama = new AlgoTrading.Logic.myAIAlgorithem();//this);                
                _run = new Thread(new ThreadStart(_ama.runAlgorithemAI));
                _run.Start();
            }
        }
    }
}
