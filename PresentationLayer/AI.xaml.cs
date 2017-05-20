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
        private float _startFunds;
        private System.Timers.Timer _myTimer;
        private int _timeElapsed;
        private log4net.ILog _log;
        //constructor
        public AI()
        {
            _log = log4net.LogManager.GetLogger("");
            InitializeComponent();
            this.WindowTitle = this.Title;
            _startFunds = _UserOptions.GetFunds();
            myFunds.Text = _startFunds.ToString();
            //the timer will auto update the user funds
            _myTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            _myTimer.Elapsed += OnTimedEvent;
            _myTimer.AutoReset = true;
            Start(null, null);
        }
        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {         
            Dispatcher.Invoke(() =>
                {
                    if (_timeElapsed == 0)
                    {
                        UpdateFunds();
                        _timeElapsed = 10;
                    }
                    else
                        _timeElapsed--;
                    TimeLeft.Text = _timeElapsed.ToString();
                });
        }

        //runs the algorithem on thread
        private void Start(object sender, RoutedEventArgs e)
        {
            if (_run == null || !_run.IsAlive)
            {
                myStatus.Text = "Runnig";
                _log.Info("AI started");
                Thread.Sleep(TimeSpan.FromSeconds(0.01));
                _myTimer.Enabled = true;
                _timeElapsed = 10;
                _ama = new AlgoTrading.Logic.myAIAlgorithem();//this);                
                _run = new Thread(new ThreadStart(_ama.RunAlgorithemAI));
                _run.Start();
            }
        }

        //stopping the algorithem
        private void Stop(object sender, RoutedEventArgs e)
        {
            if (_ama != null) {
                if (_run != null && _run.IsAlive)
                {                    
                    _myTimer.Enabled = false;
                    myStatus.Text = "Please wait..";//why it is unreachable code?
                    _log.Info("AI Aborted");
                    Thread.Sleep(TimeSpan.FromSeconds(0.01));
                    _ama.StopAlgorithemAI();
                    Trace.WriteLine("stop pressed");
                    while (_ama.CanAbortThread())
                    {
                        Thread.Sleep(TimeSpan.FromSeconds(1));//unreachable code
                        //Trace.WriteLine("waits to thread");//unreachable code
                    }
                    //_run.Abort();
                    _run.Join();
                    Trace.WriteLine("AI aborted");
                    myStatus.Text = "Stopped";
                }
            }
        }

        //updating the funds value
        public void UpdateFunds()
        {
            float tValue = _UserOptions.GetFunds();
            Thread.Sleep(TimeSpan.FromSeconds(0.01));
            float revenue = tValue-_startFunds;
            myFunds.Text = tValue.ToString() + ", revenue " + revenue;
        }


        private void Back(object sender, RoutedEventArgs e)
        {
            Stop(null, null);
            ((Window)this.Parent).Content = new MainMenu();
        }
    }
}
