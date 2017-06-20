using System.Windows;
using System.Windows.Controls;
using AlgoTrading.Data.History;
using System.Windows.Data;
using iTextSharp.text.pdf;
using System.IO;
using iTextSharp.text;
using System;

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
        
        //retrurns to the previous page
        private void Back_Click(object sender, RoutedEventArgs e)
        {
            ((Window)Parent).Content = new MainMenu(); 
        }

        //groups the information by the chosen opportunities
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

        //save the information as a pdf file
        private void ExportAsPDF(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "HistoryFile"; // Default file name
            dlg.DefaultExt = ".pdf"; // Default file extension
            dlg.Filter = "PDF documents (.pdf)|*.pdf"; // Filter files by extension 

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();

            // Process open file dialog box results 
            if (result == true)
            {
                // Open document
                string res = dlg.FileName;

                var doc1 = new Document();
                PdfWriter.GetInstance(doc1, new FileStream(res, FileMode.Create));

                doc1.Open();
                var Header = new Paragraph("History file\n", FontFactory.GetFont("David", 22, Font.UNDERLINE, new BaseColor(160, 200, 210)));
                Header.Alignment = (int) HorizontalAlignment.Center;
                doc1.Add(Header);
                doc1.Add(new Paragraph("ID-Type-IsAma-Price-Commodity-Amount-Validation", FontFactory.GetFont("David", 14)));
                foreach (HistoryUnit HU in _historyList)
                    doc1.Add(new Paragraph(HU.ToString(), FontFactory.GetFont("David", 12)));
                doc1.Close();
            }
            MessageBox.Show("File has been exported as PDF Successfully");
        }
    }    
}
