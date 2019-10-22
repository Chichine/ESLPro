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
using System.Windows.Shapes;
using Spire.Pdf;
using Spire.Pdf.Graphics;


namespace ESLPro
{
    /// <summary>
    /// Logique d'interaction pour PDF.xaml
    /// </summary>
    public partial class PDF : Window
    {
        public PDF()
        {
            InitializeComponent();
        }

        public PdfDocument CreateDoc()
        {
            PdfDocument doc = new PdfDocument();

            return doc;
        }

        public PdfPageBase CreatePage(PdfDocument doc)
        {
            return doc.Pages.Add();
        }

        public void SaveAndOpen(PdfDocument doc)
        {
            doc.SaveToFile(@"Tree.pdf");
            
            System.Diagnostics.Process.Start(@"Tree.pdf");
        }

        public PdfPageBase newTitle(PdfPageBase page, string text, float x, float y)
        {
            PdfBrush thisColor = PdfBrushes.Black;
            PdfFont font = new PdfFont(PdfFontFamily.Courier, 20, PdfFontStyle.Bold);
            System.Drawing.PointF position = new System.Drawing.PointF(x, y);
            page.Canvas.DrawString(text, font, thisColor, position);

            return page;
        }
    }
}
