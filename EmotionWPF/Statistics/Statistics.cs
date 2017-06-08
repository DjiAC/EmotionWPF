using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.Linq;
using System.Collections.Specialized;

namespace Emotion.Core
{ 
    /// <summary>
    /// 
    /// </summary>
    public static class Statistics
    {
        #region Variables 

        public static List<EmotionStatistics> EmotionStats = new List<EmotionStatistics>();

        public static List<TextAnalysisStatistics> TextAnalysisStats = new List<TextAnalysisStatistics>();

        #endregion

        #region Get Stats

        /// <summary>
        /// Get Emotion Call Statistics from local JSON File
        /// </summary>
        public static List<EmotionStatistics> GetEmotionStats()
        {
            EmotionStats = JsonConvert.DeserializeObject<List<EmotionStatistics>>(System.IO.File.ReadAllText(@"EmotionStats.json"));

            return EmotionStats;
        }

        /// <summary>
        /// Get TextAnalysis Call Statistics from local JSON File
        /// </summary>
        public static List<TextAnalysisStatistics> GetTextAnalysisStats()
        {
            TextAnalysisStats = JsonConvert.DeserializeObject<List<TextAnalysisStatistics>>(System.IO.File.ReadAllText(@"TextAnalysisStats.json"));

            return TextAnalysisStats;
        }

        #endregion

        #region Update JSON Stats  

        /// <summary>
        /// Update Emotion Call JSON Statistics to local JSON File
        /// </summary>
        public static void UpdateEmotionJSONStats()
        {
            System.IO.File.WriteAllText(@"EmotionStats.json", JsonConvert.SerializeObject(EmotionStats));
        }        

        /// <summary>
        /// Update TextAnalysis Call JSON Statistics to local JSON File
        /// </summary>
        public static void UpdateTextAnalysisJSONStats()
        {
            System.IO.File.WriteAllText(@"TextAnalysisStats.json", JsonConvert.SerializeObject(TextAnalysisStats));
        }

        #endregion

        #region Calculs

        /// <summary>
        /// Calcul for different showed Emotion Call Statistics
        /// </summary>
        /// <param name="EmotionStats">List of all Emotion Call Statistics</param>
        public static void CalculEmotionStats(List<EmotionStatistics> EmotionStats)
        {
            // Variables for calculs 

            // Date
            int nbEmotionCall = 0;
            int nbEmotionDay = 0;
            DateTime dateEmotionCall = new DateTime(2000, 1, 1);

            // Faces
            int nbFaces = 0;

            // Faces per Emotion
            Dictionary<String, int> facesPerEmotion = new Dictionary<String, int>();
            facesPerEmotion.Add("Anger", 0);
            facesPerEmotion.Add("Contempt", 0);
            facesPerEmotion.Add("Disgust", 0);
            facesPerEmotion.Add("Fear", 0);
            facesPerEmotion.Add("Happiness", 0);
            facesPerEmotion.Add("Neutral", 0);
            facesPerEmotion.Add("Sadness", 0);
            facesPerEmotion.Add("Surprise", 0);

            // Foreach though all Emotion Call Statistics
            foreach (EmotionStatistics emotionCallStatistic in EmotionStats)
            {
                // Calcul Total Number of Call
                nbEmotionCall += 1;

                // Calcul Total Number of day with a call
                if(dateEmotionCall != emotionCallStatistic.callEmotionDate.Date)
                {
                    dateEmotionCall = emotionCallStatistic.callEmotionDate.Date;
                    nbEmotionDay += 1;
                }

                // Calcul Total Number of Faces
                nbFaces += emotionCallStatistic.faceDetected;

                // Calcul Faces per Emotion
                foreach(Tuple<int, String> emotionCallMainStatistic in emotionCallStatistic.faceEmotion)
                {
                    if(emotionCallMainStatistic.Item2 == "Anger")
                    {
                        facesPerEmotion["Anger"] += 1;
                    }
                    else if (emotionCallMainStatistic.Item2 == "Contempt")
                    {
                        facesPerEmotion["Contempt"] += 1;
                    }
                    else if (emotionCallMainStatistic.Item2 == "Disgust")
                    {
                        facesPerEmotion["Disgust"] += 1;
                    }
                    else if (emotionCallMainStatistic.Item2 == "Fear")
                    {
                        facesPerEmotion["Fear"] += 1;
                    }
                    else if (emotionCallMainStatistic.Item2 == "Happiness")
                    {
                        facesPerEmotion["Happiness"] += 1;
                    }
                    else if (emotionCallMainStatistic.Item2 == "Neutral")
                    {
                        facesPerEmotion["Neutral"] += 1;
                    }
                    else if (emotionCallMainStatistic.Item2 == "Sadness")
                    {
                        facesPerEmotion["Sadness"] += 1;
                    }
                    else if (emotionCallMainStatistic.Item2 == "Surprise")
                    {
                        facesPerEmotion["Surprise"] += 1;
                    }
                }
                
            }

            // Total number of call by Total number of day with a call
            float callPerDay = nbEmotionCall / nbEmotionDay;
                                                         
            // Mean number of Faces detected per Call
            float nbMeanFaces = nbFaces / nbEmotionCall;
        }

        /// <summary>
        /// Calcul for different showed Text Analysis Call Statistics
        /// </summary>
        /// <param name="TextAnalysisStats">List of all Text Analysis Call Statistics</param>
        public static void CalculTextAnalysisStats(List<TextAnalysisStatistics> TextAnalysisStats)
        {
            // Variables for calculs 

            // Date
            int nbTextAnalysisCall = 0;
            int nbTextAnalysisDay = 0;
            DateTime dateTextAnalysisCall = new DateTime(2000, 1, 1);

            // Languages
            ListDictionary callPerLanguage = new ListDictionary();
            //List<Dictionary<String, int>> callPerLanguage = new List<Dictionary<String, int>>();
            callPerLanguage.Add("English", 0);
            callPerLanguage.Add("French", 0);
            callPerLanguage.Add("Spanish", 0);
            callPerLanguage.Add("Italian", 0);
            callPerLanguage.Add("German", 0);
            callPerLanguage.Add("Japanese", 0);

            // Sentiment Scores
            int score0To30 = 0;
            int score31To60 = 0;
            int score61To100 = 0;

            // Foreach though all Emotion Call Statistics
            foreach (TextAnalysisStatistics textAnalyticsCallStatistic in TextAnalysisStats)
            {
                // Calcul Total Number of Call
                nbTextAnalysisCall += 1;

                // Calcul Total Number of day with a call
                if (dateTextAnalysisCall != textAnalyticsCallStatistic.callTextAnalyticsDate.Date)
                {
                    dateTextAnalysisCall = textAnalyticsCallStatistic.callTextAnalyticsDate.Date;
                    nbTextAnalysisDay += 1;
                }

                // Calcul Total Number of Call per Language
                if (callPerLanguage.Contains(textAnalyticsCallStatistic.languageDetected))
                {
                    callPerLanguage[textAnalyticsCallStatistic.languageDetected] = + 1;
                }
                else
                {
                    callPerLanguage.Add(textAnalyticsCallStatistic.languageDetected, 1);
                }

                // Calcul Total Number of Call per Score 
                if(textAnalyticsCallStatistic.sentimentScore <= 0.3)
                {
                    score0To30 += 1;
                }
                else if(textAnalyticsCallStatistic.sentimentScore <= 0.6)
                {
                    score31To60 += 1;
                }
                else
                {
                    score61To100 += 1;
                }

            }

            // Total number of call by Total number of day with a call
            float callPerDay = nbTextAnalysisCall / nbTextAnalysisDay;

            // Mean number of language detected per Call
            Dictionary<String, float> callPerLanguagePercentage = new Dictionary<String, float>();
            
            // Foreach List of Languages detected and calcul percentage of repartition
            foreach(Tuple<String, int> languageNumber in callPerLanguage)
            {
                callPerLanguagePercentage.Add(languageNumber.Item1, (languageNumber.Item2 / nbTextAnalysisCall) * 100);
            }   
        }

        #endregion
    }
}
