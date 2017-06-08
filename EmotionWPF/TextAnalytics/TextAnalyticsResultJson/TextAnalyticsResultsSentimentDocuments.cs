using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    /// <summary>
    /// Class for Text Analytics Sentiment Documents
    /// </summary>
    public class TextAnalyticsResultsSentimentDocuments
    {
        /// <summary>
        /// API Request ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Sentiment score
        /// </summary>
        public float score { get; set; }
    }
}
