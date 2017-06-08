using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    /// <summary>
    /// Class for Text Analytics Languages Detected Languages
    /// </summary>
    public class TextAnalyticsResultsDetectedLanguages
    {
        /// <summary>
        /// Language detected name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// Language detected name - ISO6391 Format
        /// </summary>
        public string iso6391Name { get; set; }

        /// <summary>
        /// Language detection score
        /// </summary>
        public float score { get; set; }
    }
}
