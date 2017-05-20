using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AlgoTrading.Data.History;
using System.Windows.Data;

namespace PresentationLayer
{
    /// <summary>
    /// Interaction logic for History.xaml
    /// </summary>
    public partial class History : Page
    {
        public ListCollectionView _historyList { get; set; }

        public bool _type { get; set; }
        public bool _price { get; set; }
        public bool _commodity { get; set; }
        public bool _amount { get; set; }
        public bool _IsAma { get; set; }
        public bool _validation { get; set; }

        public History()
        {
            InitializeComponent();
            HistoryWriter.AddSpecipicDataToHistory("buy", 1, false, "2,3,4");
            HistoryWriter.AddSpecipicDataToHistory("sell", 2, true, "4,5,6");
            WindowTitle = Title;           
            DataContext = this;
            _historyList = new ListCollectionView(HistoryDataBase.GetAllHistory());
            //    _historyList.GroupDescriptions.Add(new PropertyGroupDescription("Type"));            
            //    _historyList.GroupDescriptions.Add(new PropertyGroupDescription("Commodity"));            
            //    _historyList.GroupDescriptions.Add(new PropertyGroupDescription("Amount"));           
            //    _historyList.GroupDescriptions.Add(new PropertyGroupDescription("Price"));           
            //    _historyList.GroupDescriptions.Add(new PropertyGroupDescription("IsAma"));          
            //    _historyList.GroupDescriptions.Add(new PropertyGroupDescription("Validation"));
        }
    
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ((Window)Parent).Content = new MainMenu(); 
        }

        private void ApplyGrouping(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Trace.WriteLine(_type + " " + _price + " " + _commodity + " " + _amount + " " + _IsAma + " " + _validation);
            _historyList.GroupDescriptions.Clear();
            //_historyList.GroupDescriptions.Add(new PropertyGroupDescription("Type"));
            //_historyList.GroupDescriptions.Add(new PropertyGroupDescription("Commodity"));
            //_historyList.GroupDescriptions.Add(new PropertyGroupDescription("Amount"));
            //_historyList.GroupDescriptions.Add(new PropertyGroupDescription("Price"));
            //_historyList.GroupDescriptions.Add(new PropertyGroupDescription("IsAma"));
            //_historyList.GroupDescriptions.Add(new PropertyGroupDescription("Validation"));
            if (_type)
                _historyList.GroupDescriptions.Add(new PropertyGroupDescription("Type"));
            if (_commodity)
                _historyList.GroupDescriptions.Add(new PropertyGroupDescription("Commodity"));
            if (_amount)
                _historyList.GroupDescriptions.Add(new PropertyGroupDescription("Amount"));
            if (_price)
                _historyList.GroupDescriptions.Add(new PropertyGroupDescription("Price"));
            if (_IsAma)
                _historyList.GroupDescriptions.Add(new PropertyGroupDescription("IsAma"));
            if (_validation)
                _historyList.GroupDescriptions.Add(new PropertyGroupDescription("Validation"));
            System.Diagnostics.Trace.WriteLine(_type + " " + _price + " " + _commodity + " " + _amount + " " + _IsAma + " " + _validation);

        }
    }
}
