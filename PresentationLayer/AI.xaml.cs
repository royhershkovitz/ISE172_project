using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using AlgoTrading;
using System.Diagnostics;
using System.Timers;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for AI.xaml
    /// </summary>
    // for AI uses
    public partial class AI : Page, INotifyPropertyChanged
    {
        //The algorithm thread
        private Thread _run;
        //The algorithm object
        private AlgoTrading.Logic.myAIAlgorithem _ama;
        //The user client uset - to communicate with the server
        private MarketClientOptions _UserOptions = new MarketClientOptions();
        //Timer to count the lap time and update the funds
        private System.Timers.Timer _myTimer;
        //A value we will use to calculate the revenue
        private float _startFunds;
        //An integer we use to store the property data
        private int _myTime = -1;
        //An string we use to store the property data
        private string _myStatus = String.Empty;
        //An string which represent the status of the class
        public int _timeElapsed
        {
            get { return _myTime; }
            set
            {
                if (_myTime != value)
                {
                    _myTime = value;
                    RaisePropertyChanged(this, "_timeElapsed"); // Tell WPF to check this property too
                }
            }
        }

        //An string which represent the status of the class
        public string _status
        {
            get { return _myStatus; }
            set
            {
                if (!_myStatus.Equals(value))
                {
                    _myStatus = value;
                    RaisePropertyChanged(this, "_status"); // Tell WPF to check this property too
                }
            }
        }
        private log4net.ILog _log;

        //Constructor
        public AI()
        {
            _log = log4net.LogManager.GetLogger("");
            InitializeComponent();
            WindowTitle = Title;
            DataContext = this;          
              
            _startFunds = _UserOptions.GetFunds();
            myFunds.Text = _startFunds.ToString();

            //the timer will auto update the user funds
            _myTimer = new System.Timers.Timer(1000);
            // Hook up the Elapsed event for the timer. 
            _myTimer.Elapsed += OnTimedEvent;
            _myTimer.AutoReset = true;

            //define the algorithem's thread
            _ama = new AlgoTrading.Logic.myAIAlgorithem();
            _run = new Thread(_ama.RunAlgorithemAI);
            Start(null, null);
        }

        //Timer event, update the funds and present the time loop.
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
                });
        }

        //runs the algorithem on thread
        private void Start(object sender, RoutedEventArgs e)
        {
            Trace.WriteLine("start startrun?: " + !_run.IsAlive);
            Trace.WriteLine("state?: " + _run.ThreadState);
            if (_run.ThreadState.ToString().Equals("Stopped") | _run.ThreadState.ToString().Equals("Unstarted"))
            {
                _status = "Runnig";
                _log.Info("AI started");
                Thread.Sleep(TimeSpan.FromSeconds(0.01));
                _timeElapsed = 10;
                _myTimer.Enabled = true;//run timer
                _run.Abort();
                _run = new Thread(_ama.RunAlgorithemAI);
                _run.Start();
            }
        }

        //stopping the algorithem
        private void Stop(object sender, RoutedEventArgs e)
        {
           Trace.WriteLine("stop stoprun?: " + _run.IsAlive);
           if (_run.IsAlive)
           {
                _status = "Please wait..";//why it is unreachable code?
                _log.Info("AI Aborted");
                Thread.Sleep(TimeSpan.FromSeconds(0.01));
                _ama.StopAlgorithemAI();
                Trace.WriteLine("StopState?: " + _run.ThreadState);
                //_run.Interrupt();
                _myTimer.Enabled = false;
                _timeElapsed = 0;                     
                _status = " Aborted";
                Trace.WriteLine("AI aborted");
                Trace.WriteLine("StopState?: " + _run.ThreadState);
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
            _myTimer.Close();
            _ama.StopAlgorithemAI();
            _run.Join();//waits until the thread be available
            _run.Abort();
            Trace.WriteLine("AI killed");
            ((Window)Parent).Content = new MainMenu();
        }       


        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        protected void RaisePropertyChanged(object sender, string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(sender, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
