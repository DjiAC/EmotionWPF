using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    /// <summary>
    /// Class for Text Analytics Key Phrases Documents
    /// </summary>
    public class TextAnalyticsResultsKeyPhrasesDocuments
    {
        /// <summary>
        /// API Request ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// List of Key Phrases detected
        /// </summary>
        public List<string> keyPhrases { get; set; }

    }
}
