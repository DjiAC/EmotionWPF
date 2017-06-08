using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    #region Language

    /// <summary>
    /// Class for Text Analytics Json Format - Language
    /// </summary>
    public class TextAnalyticsJsonFormatLanguage
    {
        /// <summary>
        /// List of TextAnalyticsLanguagesDocuments 
        /// </summary>
        public List<TextAnalyticsLanguagesDocuments> documentsLanguages { get; set; }
    }

    /// <summary>
    /// Class for Text Analytics Json Format - Language / Documents
    /// </summary>
    public class TextAnalyticsLanguagesDocuments
    {
        /// <summary>
        /// Text to analyse ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Text to analyse
        /// </summary>
        public string text { get; set; }
    }

    /// <summary>
    /// Class for Text Analysis Results Json Format - Language
    /// </summary>
    public class TextAnalyticsLanguagesResults
    {
        public List<TextAnalyticsResultsLanguagesDocuments> documentsLanguages { get; set; }

        public List<TextAnalyticsResultsErrors> errorsLanguages { get; set; }
    }
    
    #endregion

    #region KeyPhrases & Sentiment

    /// <summary>
    /// Class for Text Analytics Json Format - Key Phrases & Sentiment
    /// </summary>
    public class TextAnalyticsJsonFormatKeyPhrasesSentiment
    {
        /// <summary>
        /// List of TextAnalyticsKeyPhraseSentimentDocuments 
        /// </summary>
        public List<TextAnalyticsKeyPhrasesSentimentDocuments> documentsKeyPhrasesSentiment { get; set; }
    }

    /// <summary>
    /// Class for Text Analytics Json Format - Key Phrases & Sentiment / Documents
    /// </summary>
    public class TextAnalyticsKeyPhrasesSentimentDocuments
    {
        /// <summary>
        /// Language of the text to analyse
        /// </summary>
        public string language { get; set; }

        /// <summary>
        /// Text to analyse ID
        /// </summary>
        public string id { get; set; }

        /// <summary>
        /// Text to analyse
        /// </summary>
        public string text { get; set; }

        
    }

    /// <summary>
    /// Class for Text Analysis Results Json Format - Key Phrases
    /// </summary>
    public class TextAnalyticsKeyPhrasesResults
    {
        public List<TextAnalyticsResultsKeyPhrasesDocuments> documentsKeyPhrases { get; set; }

        public List<TextAnalyticsResultsErrors> errorsKeyPhrases { get; set; }
    }

    /// <summary>
    /// Class for Text Analysis Results Json Format - Sentiment
    /// </summary>
    public class TextAnalyticsSentimentResults
    {
        public List<TextAnalyticsResultsSentimentDocuments> documentsSentiment { get; set; }

        public List<TextAnalyticsResultsErrors> errorsSentiment { get; set; }
    }


    #endregion
}
