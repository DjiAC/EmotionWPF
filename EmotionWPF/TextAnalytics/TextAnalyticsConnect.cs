using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;

namespace Emotion.Core
{
    /// <summary>
    /// Connection to Cognitive Services Microsoft API - TEXT ANALYTICS
    /// </summary>
    public class TextAnalyticsConnect
    {
        #region Var/Properties/Constructor

        /// <summary>
        /// Differents Connection Response Status
        /// </summary>
        public enum ConnectionResults {
            success,
            networkTrouble,
            serviceTrouble,
            languageNotSupported
        }

        /// <summary>
        /// Text Analysis Response
        /// </summary>
        public TextAnalyticsResults textAnalyticsResults { get; set; }

        /// <summary>
        /// Text Analysis Statistics
        /// </summary>
        public TextAnalysisStatistics textAnalysisConnectStats { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public TextAnalyticsConnect()
        {
            textAnalyticsResults = new TextAnalyticsResults();

            textAnalysisConnectStats = new TextAnalysisStatistics();
        }

        #endregion

        #region Call Web Services

        /// <summary>
        /// Cognitives Text Analytics Service call
        /// </summary>
        /// <param name="textAnalyse">Text to be analyse</param>
        /// <returns>Connection results Status</returns>
        public async Task<ConnectionResults> CallService(string textAnalyse)
        {
            // Create http client
            HttpClient webclient = new HttpClient();

            // Base URL of the http client
            webclient.BaseAddress = new Uri("https://westus.api.cognitive.microsoft.com/text/analytics/v2.0/");

            // Request Headers
            webclient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "fca542fd93de4b6aa04a533b62e425e0");
            webclient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Get Language
            byte[] textByte = LanguageRequestFormat(textAnalyse);
            Tuple<ConnectionResults, String> languageDetectionResults = await DetectLanguage(webclient, textByte);

            // Get results from language detection
            ConnectionResults resultLanguageConnection = languageDetectionResults.Item1;
            string language = languageDetectionResults.Item2;

            // If connection went well
            if (resultLanguageConnection == ConnectionResults.success)
            {
                textByte = KeyPhrasesSentimentRequestFormat(textAnalyse, language);

                // Get Key Phrases with language precision
                Tuple<ConnectionResults, String> keyPhrasesResults = await DetectKeyPhrases(webclient, textByte, language);

                // Get Sentiment with language precision
                Tuple<ConnectionResults, String> sentimentResults = await DetectSentiment(webclient, textByte, language);

                // Return ConnectionResults details
                if(keyPhrasesResults.Item1 == ConnectionResults.success && sentimentResults.Item1 == ConnectionResults.success)
                {
                    return ConnectionResults.success;
                }
                else if (keyPhrasesResults.Item1 != ConnectionResults.success)
                {
                    return keyPhrasesResults.Item1;
                }
                else if (sentimentResults.Item1 != ConnectionResults.success)
                {
                    return sentimentResults.Item1;
                }
            }

            return resultLanguageConnection;
        }

        /// <summary>
        /// Global call to Text Analytics API
        /// </summary>
        /// <param name="webclient">HTTP Client</param>
        /// <param name="uri">URI to call</param>
        /// <param name="textByte">Text to analyse transformed to Byte format</param>
        /// <returns></returns>
        async Task<String> CallTextAnalyticsAPI(HttpClient webclient, string uri, byte[] textByte)
        {
            string responseAPI = "";
            HttpResponseMessage response;

            using (var content = new ByteArrayContent(textByte))
            {
                // Try HTTP Request
                try
                {
                    response = await webclient.PostAsync(uri, content);
                    responseAPI = await response.Content.ReadAsStringAsync();
                }
                // Catch HTTP Request Exceptions
                catch (Exception)
                {
                    return "Exception during request";
                }

                return responseAPI;
            }
        }

        /// <summary>
        /// Settings for Language analytics with API
        /// </summary>
        /// <param name="webclient">HTTP client with base url</param>
        /// <param name="textByte">Text to analyse</param>
        /// <returns></returns>
        async Task<String> CallLanguageAPI(HttpClient webclient, byte[] textByte)
        {
            string uri = "languages?numberOfLanguagesToDetect=1";
            return await CallTextAnalyticsAPI(webclient, uri, textByte);
        }

        /// <summary>
        /// Settings for Key Phrases analytics with API
        /// </summary>
        /// <param name="webclient">HTTP client with base url</param>
        /// <param name="textByte">Text to analyse</param>
        /// <returns></returns>
        async Task<String> CallKeyPhraseAPI(HttpClient webclient, byte[] textByte)
        {
            string uri = "keyPhrases";
            return await CallTextAnalyticsAPI(webclient, uri, textByte);
        }

        /// <summary>
        /// Settings for Sentiment analytics with API
        /// </summary>
        /// <param name="webclient">HTTP client with base url</param>
        /// <param name="textByte">Text to analyse</param>
        /// <returns></returns>
        async Task<String> CallSentimentAPI(HttpClient webclient, byte[] textByte)
        {
            string uri = "sentiment";
            return await CallTextAnalyticsAPI(webclient, uri, textByte);
        }

        #endregion

        #region Detection

        /// <summary>
        /// To detect language of the text and get connection result
        /// </summary>
        /// <param name="webclient">HTTP Client</param>
        /// <param name="textByte">Text to analyse transformed to byte</param>
        /// <returns></returns>
        async Task<Tuple<ConnectionResults, String>> DetectLanguage(HttpClient webclient, byte[] textByte)
        {
            // Call language detection API
            string languageResult = await CallLanguageAPI(webclient, textByte);

            TextAnalyticsLanguagesResults languagesResultJson = new TextAnalyticsLanguagesResults();

            // Test language detection results
            // Detect connection trouble
            if (languageResult == "")
            {
                return new Tuple<ConnectionResults, string>(ConnectionResults.networkTrouble, "Probably network trouble");
            }

            // Detect API service trouble (code error)        
            // From exception
            try
            {
                languagesResultJson = JsonConvert.DeserializeObject<TextAnalyticsLanguagesResults>(languageResult);
            }
            catch (Exception)
            {
                return new Tuple<ConnectionResults, string>(ConnectionResults.serviceTrouble, "Service Trouble");
            }

            // From Errors indicated by API
            if (languagesResultJson.errorsLanguages.Count != 0)
            {
                return new Tuple<ConnectionResults, string>(ConnectionResults.serviceTrouble, "Service Trouble - Error : " 
                    + languagesResultJson.errorsLanguages[0].id + " - Message : " 
                    + languagesResultJson.errorsLanguages[0].message);
            }

            // Get Language
            try
            {
                textAnalyticsResults.languageDetected = languagesResultJson.documentsLanguages[0].detectedLanguages[0].name;

                string languageShort = languagesResultJson.documentsLanguages[0].detectedLanguages[0].iso6391Name;

                return new Tuple<ConnectionResults, string>(ConnectionResults.success, languageShort);
            }
            catch (Exception)
            {
                return new Tuple<ConnectionResults, string>(ConnectionResults.serviceTrouble, "Service Trouble");
            }
        }

        /// <summary>
        /// To detect key phrases of the text to analyse with language precision and get connection result
        /// </summary>
        /// <param name="webclient">HTTP Client</param>
        /// <param name="textByte">Text to analyse transformed to byte</param>
        /// <param name="language">Language detected before</param>
        /// <returns></returns>
        async Task<Tuple<ConnectionResults, String>> DetectKeyPhrases(HttpClient webclient, byte[] textByte, string language)
        {
            // Call language detection API
            string keyPhrasesResult = await CallKeyPhraseAPI(webclient, textByte);

            TextAnalyticsKeyPhrasesResults keyPhrasesResultJson = new TextAnalyticsKeyPhrasesResults();

            // Test Key Phrases detection results
            // Detect connection trouble
            if (keyPhrasesResult == "")
            {
                return new Tuple<ConnectionResults, string>(ConnectionResults.networkTrouble, "Probably network trouble");
            }

            // Detect API service trouble (code error)        
            // From exception
            try
            {
                keyPhrasesResultJson = JsonConvert.DeserializeObject<TextAnalyticsKeyPhrasesResults>(keyPhrasesResult);
            }
            catch (Exception)
            {
                return new Tuple<ConnectionResults, string>(ConnectionResults.serviceTrouble, "Service Trouble");
            }

            // Language not supported or others errors indicated by API
            if (keyPhrasesResultJson.errorsKeyPhrases.Count != 0)
            {
                bool languageNotSupported = false;

                foreach (var errorMessage in keyPhrasesResultJson.errorsKeyPhrases)
                {
                    if (errorMessage.message.Contains("Supplied language not supported"))
                    {
                        languageNotSupported = true;
                    }
                }

                if (languageNotSupported)
                {
                    return new Tuple<ConnectionResults, string>(ConnectionResults.languageNotSupported, "Supplied language not supported");
                }
                else
                {
                    return new Tuple<ConnectionResults, string>(ConnectionResults.serviceTrouble, "Service Trouble - Error : "
                       + keyPhrasesResultJson.errorsKeyPhrases[0].id + " - Message : "
                       + keyPhrasesResultJson.errorsKeyPhrases[0].message);
                }                
            }

            // Get Key Phrases
            try
            {
                textAnalyticsResults.keyPhrases = keyPhrasesResultJson.documentsKeyPhrases[0].keyPhrases;

                return new Tuple<ConnectionResults, string>(ConnectionResults.success, "");
            }
            catch (Exception)
            {
                return new Tuple<ConnectionResults, string>(ConnectionResults.serviceTrouble, "Service Trouble");
            }
        }

        /// <summary>
        /// To detect sentiment of the text to analyse with language precision and get connection result
        /// </summary>
        /// <param name="webclient">HTTP Client</param>
        /// <param name="textByte">Text to analyse transformed to byte</param>
        /// <param name="language">Language detected before</param>
        /// <returns></returns>
        async Task<Tuple<ConnectionResults, String>> DetectSentiment(HttpClient webclient, byte[] textByte, string language)
        {
            // Call language detection API
            string sentimentResult = await CallSentimentAPI(webclient, textByte);

            TextAnalyticsSentimentResults sentimentResultJson = new TextAnalyticsSentimentResults();

            // Test Sentiment detection results
            // Detect connection trouble
            if (sentimentResult == "")
            {
                return new Tuple<ConnectionResults, string>(ConnectionResults.networkTrouble, "Probably network trouble");
            }

            // Detect API service trouble (code error)        
            // From exception
            try
            {
                sentimentResultJson = JsonConvert.DeserializeObject<TextAnalyticsSentimentResults>(sentimentResult);
            }
            catch (Exception)
            {
                return new Tuple<ConnectionResults, string>(ConnectionResults.serviceTrouble, "Service Trouble");
            }

            // Language not supported or others errors indicated by API
            if (sentimentResultJson.errorsSentiment.Count != 0)
            {
                bool languageNotSupported = false;

                foreach (var errorMessage in sentimentResultJson.errorsSentiment)
                {
                    if (errorMessage.message.Contains("Supplied language not supported"))
                    {
                        languageNotSupported = true;
                    }
                }

                if (languageNotSupported)
                {
                    return new Tuple<ConnectionResults, string>(ConnectionResults.languageNotSupported, "Supplied language not supported");
                }
                else
                {
                    return new Tuple<ConnectionResults, string>(ConnectionResults.serviceTrouble, "Service Trouble - Error : "
                       + sentimentResultJson.errorsSentiment[0].id + " - Message : "
                       + sentimentResultJson.errorsSentiment[0].message);
                }
            }

            // Get Sentiment
            try
            {
                textAnalyticsResults.sentimentScore = sentimentResultJson.documentsSentiment[0].score;

                return new Tuple<ConnectionResults, string>(ConnectionResults.success, "");
            }
            catch (Exception)
            {
                return new Tuple<ConnectionResults, string>(ConnectionResults.serviceTrouble, "Service Trouble");
            }
        }

        #endregion

        #region Transform to Byte

        /// <summary>
        /// Transform Language request to byte with Language request json format
        /// </summary>
        /// <param name="textAnalyse">Text to analyse</param>
        /// <returns>Formatted byte request</returns>
        byte[] LanguageRequestFormat(string textAnalyse)
        {
            TextAnalyticsJsonFormatLanguage languageRequestByte = new TextAnalyticsJsonFormatLanguage()
            {
                documentsLanguages = new List<TextAnalyticsLanguagesDocuments>()
                {
                    new TextAnalyticsLanguagesDocuments
                    {
                        id = "1",
                        text = textAnalyse
                    }
                }
            };

            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(languageRequestByte));
        }

        /// <summary>
        /// Transform Key Phrase & Sentiment request to byte with Key Phrase & Sentiment request json format
        /// </summary>
        /// <param name="textAnalyse">Text to analyse</param>
        /// <param name="textLanguage">Language of the text to analyse</param>
        /// <returns>Formatted byte request</returns>
        byte[] KeyPhrasesSentimentRequestFormat(string textAnalyse, string textLanguage)
        {
            TextAnalyticsJsonFormatKeyPhrasesSentiment KeyPhrasesSentimentRequestByte = new TextAnalyticsJsonFormatKeyPhrasesSentiment()
            {
                documentsKeyPhrasesSentiment = new List<TextAnalyticsKeyPhrasesSentimentDocuments>()
                {
                    new TextAnalyticsKeyPhrasesSentimentDocuments
                    {
                        id = "1",
                        text = textAnalyse,
                        language = textLanguage
                    }
                }
            };

            return Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(KeyPhrasesSentimentRequestByte));
        }

        #endregion

        #region Update Global Stats

        /// <summary>
        /// Send Text Analysis Call Results to Global Stats
        /// </summary>
        /// <param name="textAnalysisResults">TextAnalysis Results from Call</param>
        public void UpdateTextAnalysisResultsToStats(TextAnalyticsResults textAnalysisResults)
        {
            // Unique ID with DateTime Ticks in seconds
            textAnalysisConnectStats.idTextAnalysisCall = Convert.ToInt32(DateTime.Now.Ticks / 1000000000);

            // Language detected
            textAnalysisConnectStats.languageDetected = textAnalysisResults.languageDetected;

            // Score of sentiment detected
            textAnalysisConnectStats.sentimentScore = textAnalysisResults.sentimentScore;

            // DateTime of the call
            textAnalysisConnectStats.callTextAnalyticsDate = DateTime.Now;

            // Update Global Emotion Stats 
            Statistics.TextAnalysisStats.Add(textAnalysisConnectStats);
        }

        #endregion

    }
}
