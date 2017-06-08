using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    /// <summary>
    /// Class for Statistics Format - Emotion
    /// </summary>
    public class EmotionCallStatistics
    {
        /// <summary>
        /// Unique Id of the Emotion Call
        /// </summary>
        public int idEmotionCall { get; set; }

        /// <summary>
        /// Number of Face detected
        /// </summary>
        public int faceDetected { get; set; }

        /// <summary>
        /// Association of Face Id and main Emotion
        /// </summary>
        public Tuple<int, String> faceEmotion { get; set; }

        /// <summary>
        /// Date of the Emotion Call
        /// </summary>
        public DateTime callEmotionDate { get; set; }
    }

    /// <summary>
    /// Class for Statistics Format - Text Analysis
    /// </summary>
    public class TextAnalysisCallStatistics
    {
        /// <summary>
        /// Unique Id of the Text Analysis Call
        /// </summary>
        public int idTextAnalysisCall { get; set; }

        /// <summary>
        /// Detected Language detectzd
        /// </summary>
        public string languageDetected { get; set; }

        /// <summary>
        /// Sentiment Score detected
        /// </summary>
        public float sentimentScore { get; set; }        

        /// <summary>
        /// Date of the Text Analytics Call
        /// </summary>
        public DateTime callTextAnalyticsDate { get; set; }
    }


}
