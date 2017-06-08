using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    /// <summary>
    /// Class for Text Analytics Sentiment results
    /// </summary>
    public class TextAnalyticsResultsSentiment
    {
        /// <summary>
        /// Documents for Sentiment detection
        /// </summary>
        public List<TextAnalyticsResultsSentimentDocuments> sentimentDocuments {get; set;}

        /// <summary>
        /// Errors for Sentiment detection
        /// </summary>
        public List<TextAnalyticsResultsErrors> sentimentErrors { get; set; }

    }
}
