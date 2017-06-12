using System.Collections.Generic;
using System.Windows.Controls;

namespace EmotionWPF
{
    /// <summary>
    /// Interaction logic for FrameStatistics.xaml
    /// </summary>
    public partial class FrameStatistics : Page
    {
        // Instance of Statistics
        public static Statistics statisticsGlobal { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public FrameStatistics()
        {
            InitializeComponent();

            statisticsGlobal = new Statistics();

            InitStats(statisticsGlobal.EmotionStats, statisticsGlobal.TextAnalysisStats);
        }

        /// <summary>
        /// Initiate Statistics by getting them from EmotionStats & TextAnalyticsStats Objects
        /// </summary>
        public void InitStats(List<EmotionStatistics> EmotionStats, List<TextAnalysisStatistics> TextAnalysisStats)
        {
            // Total number of calls
            callsEmotion.Content = statisticsGlobal.EmotionStats.Count.ToString();
            callsTextAnalytics.Content = statisticsGlobal.TextAnalysisStats.Count.ToString();

            // Emotion
            // Calls per Day
            callsPerDayEmotion.Content = statisticsGlobal.callPerDayEmotion.ToString();

            // Faces per Call
            facesPerCall.Content = statisticsGlobal.nbMeanFaces.ToString();

            // Total Main Emotion Faces
            totalAnger.Content = statisticsGlobal.facesPerEmotion["Anger"];
            totalContempt.Content = statisticsGlobal.facesPerEmotion["Contempt"];
            totalDisgust.Content = statisticsGlobal.facesPerEmotion["Disgust"];
            totalFear.Content = statisticsGlobal.facesPerEmotion["Fear"];
            totalHappiness.Content = statisticsGlobal.facesPerEmotion["Happiness"];
            totalNeutral.Content = statisticsGlobal.facesPerEmotion["Neutral"];
            totalSadness.Content = statisticsGlobal.facesPerEmotion["Sadness"];
            totalSurprise.Content = statisticsGlobal.facesPerEmotion["Surprise"];

            // Text Analysis
            // Calls per Day
            callsPerDayTextAnalytics.Content = statisticsGlobal.callPerDayTextAnalytics.ToString();

        }
    }
}
