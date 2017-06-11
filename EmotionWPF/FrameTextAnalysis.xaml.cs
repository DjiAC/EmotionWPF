using System;
using System.Windows.Controls;

namespace EmotionWPF
{
    /// <summary>
    /// Interaction logic for FrameTextAnalysis.xaml
    /// </summary>
    public partial class FrameTextAnalysis : Page
    {       
        // Instance of TextAnalyticsConnect
        public static TextAnalyticsConnect textAnalyticsAction { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public FrameTextAnalysis()
        {
            InitializeComponent();

            textAnalyticsAction = new TextAnalyticsConnect();
        }

        /// <summary>
        /// Start analysis of the text filled in inputTextAnalysis 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void startTextAnalysis(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Text filled in inputTextAnalysis
            string inputText = inputTextAnalysis.Text;

            // Empty Text Analysis Results Blocks
            EmptyTextAnalysisResultsBox();

            textAnalysisErrors.Content = "";

            // Check if text was written and different from place holder
            if (inputText == "Please enter the to analyse here")
            {
                // Advert user
                textAnalysisErrors.Content = "You didn't change the initial text";
            }
            else if (inputText == "")
            {
                // Advert user
                textAnalysisErrors.Content = "No text is written";
            }
            else
            {
                // Call Text Analytics API Service
                TextAnalyticsConnect.ConnectionResults textAnalysisResult = await textAnalyticsAction.CallService(inputText);
                // If everything went fine for at least one of the request
                if (textAnalysisResult == TextAnalyticsConnect.ConnectionResults.success
                    || textAnalysisResult == TextAnalyticsConnect.ConnectionResults.SentimentLanguageNotSupported
                    || textAnalysisResult == TextAnalyticsConnect.ConnectionResults.KeyPhraseLanguageNotSupported)
                {
                    // Display Text Analysis Results
                    DisplayTextAnalysisResults(textAnalysisResult);
                }
                // If any problem
                else
                {
                    // Display Text Analysis Errors
                    DisplayTextAnalysisErrors(textAnalysisResult);
                }
            }
        }

        /// <summary>
        /// To display the results from Text Analysis
        /// </summary>
        void DisplayTextAnalysisResults(TextAnalyticsConnect.ConnectionResults textAnalysisResult)
        {
            // Display language Detected
            resultLanguage.Text = textAnalyticsAction.textAnalyticsResults.languageDetected;

            // Display Sentiment Score
            // If everything is detected
            if(textAnalysisResult == TextAnalyticsConnect.ConnectionResults.success)
            {
                resultSentiment.Text = textAnalyticsAction.textAnalyticsResults.sentimentScore.ToString();

                // Display Key Phrases
                resultKeyPhrases.Text = "";
                foreach (string keyPhrase in textAnalyticsAction.textAnalyticsResults.keyPhrases)
                {
                    resultKeyPhrases.Text += Environment.NewLine + keyPhrase;
                }
            }
            // If Language not supported for Sentiment
            else if (textAnalysisResult == TextAnalyticsConnect.ConnectionResults.SentimentLanguageNotSupported)
            {
                resultSentiment.Text = "Language Not Supported";
                textAnalysisErrors.Content = "Language not supported for Sentiment Phrases";                
            }
            // If Language not supported for Key Phrases
            else if (textAnalysisResult == TextAnalyticsConnect.ConnectionResults.KeyPhraseLanguageNotSupported)
            {
                resultSentiment.Text = textAnalyticsAction.textAnalyticsResults.sentimentScore.ToString();
                resultKeyPhrases.Text = "Language Not Supported";
                textAnalysisErrors.Content = "Language not supported for Key Phrases";
            }
        }

        /// <summary>
        /// To display the errors from Text Analysis Service
        /// </summary>
        /// <param name="textAnalysisResult">Text Analysis Connection Results</param>
        void DisplayTextAnalysisErrors(TextAnalyticsConnect.ConnectionResults textAnalysisResult)
        {
            // Language not supported
            if (textAnalysisResult == TextAnalyticsConnect.ConnectionResults.languageNotSupported)
            {
                textAnalysisErrors.Content = "This language is currently not supported by the Cognitive Service";
            }
            // Network Trouble
            else if (textAnalysisResult == TextAnalyticsConnect.ConnectionResults.networkTrouble)
            {
                textAnalysisErrors.Content = "It seems you have network trouble - Check your internet connection";
            }
            // Service Trouble
            else if (textAnalysisResult == TextAnalyticsConnect.ConnectionResults.serviceTrouble)
            {
                textAnalysisErrors.Content = "The Cognitive Service returned an error";
            }  
        }

        /// <summary>
        /// Empty results text box to "clean"
        /// </summary>
        void EmptyTextAnalysisResultsBox()
        {
            resultLanguage.Text = resultSentiment.Text = resultKeyPhrases.Text = "";
        }
    }
}
