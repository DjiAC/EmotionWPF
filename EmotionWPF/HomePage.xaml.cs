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

namespace EmotionWPF
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        public HomePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Access Main Page with Emotion Frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmotionButton(object sender, RoutedEventArgs e)
        {
            MainWindow.ChangePage("Emotion");
        }

        /// <summary>
        /// Access Main Page with Text Analysis Frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextAnalysisButton(object sender, RoutedEventArgs e)
        {
            MainWindow.ChangePage("Text Analysis");
        }

        /// <summary>
        /// Access Main Page with Statistics Frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatisticsButton(object sender, RoutedEventArgs e)
        {
            MainWindow.ChangePage("Statistics");
        }
    }
}
