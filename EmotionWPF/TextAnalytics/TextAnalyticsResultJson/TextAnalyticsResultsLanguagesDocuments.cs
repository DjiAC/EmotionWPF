using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    /// <summary>
    /// Class for Text Analytics Languages Documents
    /// </summary>
    public class TextAnalyticsResultsLanguagesDocuments
    {
        /// <summary>
        /// API Request ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// List of languages detected
        /// </summary>
        public List<TextAnalyticsResultsDetectedLanguages> detectedLanguages { get; set; }

    }
}
