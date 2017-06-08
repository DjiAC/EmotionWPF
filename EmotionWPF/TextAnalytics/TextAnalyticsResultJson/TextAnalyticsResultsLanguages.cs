using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    /// <summary>
    /// Class for Text Analytics Languages results
    /// </summary>
    public class TextAnalyticsResultsLanguages
    {
        /// <summary>
        /// Documents for Languages detection
        /// </summary>
        public List<TextAnalyticsResultsLanguagesDocuments> languagesDocuments {get; set;}

        /// <summary>
        /// Errors for Languages detection
        /// </summary>
        public List<TextAnalyticsResultsErrors> languagesErrors { get; set; }

    }
}
