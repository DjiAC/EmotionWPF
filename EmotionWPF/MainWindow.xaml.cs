using System;
using System.Windows;
using System.Windows.Controls;

namespace EmotionWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Home Page 
        /// </summary>
        static HomePage homePage { get; set; }

        /// <summary>
        /// To Handle Left Side of the Window - Frame between Menu for Home - Emotion - Text Analysis - Statistics
        /// </summary>
        static Grid menuSwitch { get; set; }

        /// <summary>
        /// Frame for Emotion Part
        /// </summary>
        static FrameEmotion frameEmotion { get; set; }

        /// <summary>
        /// Frame for Text Analysis Part
        /// </summary>
        static FrameTextAnalysis frameTextAnalysis { get; set; }

        /// <summary>
        /// Frame for Statistics Part
        /// </summary>
        static FrameStatistics frameStatistics { get; set; }

        /// <summary>
        /// To Handle Right Side of the Window - Frame between Emotion - Text Analysis - Statistics
        /// </summary>
        static Frame frameSwitch { get; set; }       


        /// <summary>
        /// Constructor
        /// </summary>
        public MainWindow()
        {
            // Initialize Component
            InitializeComponent();
           
            // Initialize Menu - Frame Container - Emotion/TextAnalysis/Statistics Frames
            menuSwitch = MenuContainer;            
            frameSwitch = FrameContainer;
            frameEmotion = new FrameEmotion();
            frameTextAnalysis = new FrameTextAnalysis();
            frameStatistics = new FrameStatistics();

            homePage = new HomePage();

            ChangePage("home");
        }
        
        /// <summary>
        /// Change the Page displayed
        /// </summary>
        /// <param name="newPage">New Page to reach</param>
        public static void ChangePage(string newPage)
        {
            switch (newPage)
            {
                case "Emotion":
                    frameSwitch.Content = frameEmotion;
                    break;
                case "Text Analysis":
                    frameSwitch.Content = frameTextAnalysis;
                    break;
                case "Statistics":
                    frameSwitch.Content = frameStatistics;
                    break;
                case "Home Page":
                    frameSwitch.Content = homePage;
                    break;
            }          
        }

        /// <summary>
        /// Access Home Page
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HomeButton(object sender, RoutedEventArgs e)
        {
            ChangePage("Home Page");
        }

        /// <summary>
        /// Access Main Page with Emotion Frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmotionButton(object sender, RoutedEventArgs e)
        {
            ChangePage("Emotion");
        }

        /// <summary>
        /// Access Main Page with Text Analysis Frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextAnalysisButton(object sender, RoutedEventArgs e)
        {
            ChangePage("Text Analysis");
        }

        /// <summary>
        /// Access Main Page with Statistics Frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatisticsButton(object sender, RoutedEventArgs e)
        {
            ChangePage("Statistics");
        }        
    }
}
