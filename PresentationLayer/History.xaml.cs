using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using AlgoTrading.Data.History;
using System.Windows.Data;

namespace PresentationLayer
{
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
            WindowTitle = Title;           
            DataContext = this;
            _historyList = new ListCollectionView(HistoryDataBase.GetAllHistory());
        }
    
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ((Window)Parent).Content = new MainMenu(); 
        }

        private void ApplyGrouping(object sender, RoutedEventArgs e)
        {
            //System.Diagnostics.Trace.WriteLine(_type + " " + _price + " " + _commodity + " " + _amount + " " + _IsAma + " " + _validation);
            _historyList.GroupDescriptions.Clear();
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
            //System.Diagnostics.Trace.WriteLine(_type + " " + _price + " " + _commodity + " " + _amount + " " + _IsAma + " " + _validation);

        }
    }
}
