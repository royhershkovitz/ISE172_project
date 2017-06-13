using System;
using System.Collections.Generic;
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

//Added for using the basic iSharp's abilities
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
//more info from: http://www.mikesdotnetting.com/Article/80/Create-PDFs-in-ASP.NET-getting-started-with-iTextSharp


namespace PDFopensourceExample
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Glimpse(object sender, RoutedEventArgs e)
        {
            //new Glimpse.Histogram;
            double[] a = { 1, 2, 3 };
            new Glimpse.Histogram(a);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {            
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
            dlg.FileName = "Document"; // Default file name
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
                doc1.Add(new iTextSharp.text.Paragraph("My first PDF"));
                doc1.Add(new iTextSharp.text.Paragraph("BOLD", FontFactory.GetFont("Arial", 28, Font.BOLD, new iTextSharp.text.BaseColor(60, 60, 60))));
                doc1.Add(new iTextSharp.text.Paragraph("BOLDITALIC", FontFactory.GetFont("Lucida Sans", 27, Font.BOLDITALIC, new iTextSharp.text.BaseColor(120, 60, 60))));
                doc1.Add(new iTextSharp.text.Paragraph("DEFAULTSIZE", FontFactory.GetFont("Courier", 26, Font.DEFAULTSIZE, new iTextSharp.text.BaseColor(0, 0, 0))));
                doc1.Add(new iTextSharp.text.Paragraph("ITALIC", FontFactory.GetFont("Courier", 25, Font.ITALIC, new iTextSharp.text.BaseColor(180, 60, 60))));
                doc1.Add(new iTextSharp.text.Paragraph("NORMAL", FontFactory.GetFont("Courier", 24, Font.NORMAL, new iTextSharp.text.BaseColor(60, 120, 60))));
                doc1.Add(new iTextSharp.text.Paragraph("STRIKETHRU", FontFactory.GetFont("Courier", 23, Font.STRIKETHRU, new iTextSharp.text.BaseColor(60, 180, 60))));
                doc1.Add(new iTextSharp.text.Paragraph("UNDEFINED", FontFactory.GetFont("Courier", 22, Font.UNDEFINED, new iTextSharp.text.BaseColor(60, 60, 120))));
                doc1.Add(new iTextSharp.text.Paragraph("UNDERLINE", FontFactory.GetFont("Courier", 21, Font.UNDERLINE, new iTextSharp.text.BaseColor(60, 60, 180))));
                doc1.Add(new iTextSharp.text.Paragraph("NONE", FontFactory.GetFont("Courier", 20, new iTextSharp.text.BaseColor(120, 120, 120))));
                doc1.Close();

            }

        }
    }
}
