using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    /// <summary>
    /// Class for Text Analytics Results
    /// </summary>
    public class TextAnalyticsResults
    {
        /// <summary>
        /// Language detection of the text analysed
        /// </summary>
        public string languageDetected { get; set; }

        /// <summary>
        /// Key Phrases of the text analysed
        /// </summary>
        public List<String> keyPhrases { get; set; }

        /// <summary>
        /// Sentiment of the text analysed
        /// </summary>
        public float sentimentScore { get; set; }
    }
}
