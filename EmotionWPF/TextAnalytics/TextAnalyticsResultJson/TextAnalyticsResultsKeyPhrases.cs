using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    /// <summary>
    /// Class for Text Analytics Key Phrases results
    /// </summary>
    public class TextAnalyticsResultsKeyPhrases
    {
        /// <summary>
        /// Documents for Key Phrases detection
        /// </summary>
        public List<TextAnalyticsResultsKeyPhrasesDocuments> keyPhrasesDocuments {get; set;}

        /// <summary>
        /// Errors for Key Phrases detection
        /// </summary>
        public List<TextAnalyticsResultsErrors> keyPhrasesErrors { get; set; }

    }
}
