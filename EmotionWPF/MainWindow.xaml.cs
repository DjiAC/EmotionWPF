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
                    FrameContainer.Content = frameEmotion; 
                    break;
                case "Text Analysis":
                    FrameContainer.Content = frameTextAnalysis;
                    break;
                case "Statistics":
                    FrameContainer.Content = frameStatistics;
                    break;
            }
        }
    }
}
