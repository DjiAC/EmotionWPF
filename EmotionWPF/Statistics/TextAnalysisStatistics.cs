using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{ 
    /// <summary>
    /// Class for Text Analysis Statistics
    /// </summary>
    public class TextAnalysisStatistics
    {
        /// <summary>
        /// Unique ID of TextAnalysis Call
        /// </summary>
        public int idTextAnalysisCall { get; set; }

        /// <summary>
        /// Language detected
        /// </summary>
        public string languageDetected { get; set; }

        /// <summary>
        /// Sentiment score detected
        /// </summary>
        public float sentimentScore { get; set; }

        /// <summary>
        /// Date of Text Analytics Call
        /// </summary>
        public DateTime callTextAnalyticsDate { get; set; }
    }
}
