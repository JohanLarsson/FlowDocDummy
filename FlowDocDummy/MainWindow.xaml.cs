using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace FlowDocDummy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly SolidColorBrush _blueBrush = Brushes.Blue;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void ApplyFormatClick(object sender, RoutedEventArgs e)
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            FlowDocument doc = Rtb.Document;
            TextRange range = new TextRange(doc.ContentStart, doc.ContentEnd);
            range.ClearAllProperties();
            int i = 0;
            while (true)
            {
                TextPointer p1 = range.Start.GetPositionAtOffset(i);
                i++;
                TextPointer p2 = range.Start.GetPositionAtOffset(i);
                if (p2 == null)
                    break;
                TextRange tempRange = new TextRange(p1, p2);
                if (tempRange != null)
                {

                    tempRange.ApplyPropertyValue(TextElement.ForegroundProperty, _blueBrush);
                    tempRange.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
                }
                i++;

            }
            Time.Text = "Formatting took: " + stopwatch.ElapsedMilliseconds + " ms, number of characters: " + range.Text.Length;
        }

    }
}
