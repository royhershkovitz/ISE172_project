using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
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
        System.Timers.Timer myTimer;
        private float startValue;
        //constructor
        public AI()
        {           
            InitializeComponent();
            this.WindowTitle = this.Title;
            startValue = _UserOptions.getFunds();
            myFunds.Text = startValue.ToString();
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
            float revenue = tValue-startValue;
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
                myTimer.Enabled = true;
                _ama = new AlgoTrading.Logic.myAIAlgorithem();//this);                
                _run = new Thread(new ThreadStart(_ama.runAlgorithemAI));
                _run.Start();
            }
        }
    }
}
