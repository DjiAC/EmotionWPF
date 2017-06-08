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
    /// Connection to Cognitive Services Microsoft API - EMOTION
    /// </summary>
    public class EmotionConnect
    {
        #region Var/Properties/Constructor

        /// <summary>
        /// Differents Connection Response Status
        /// </summary>
        public enum ConnectionResults {
            success,
            networkTrouble,
            noFace,
            serviceTrouble
        }

        /// <summary>
        /// List of Emotions Response - EmotionResult format
        /// </summary>
        public List<EmotionResults> emotionResults { get; set; }

        /// <summary>
        /// Emotion Statistics
        /// </summary>
        public EmotionStatistics emotionConnectStats { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public EmotionConnect()
        {
            emotionResults = new List<EmotionResults>();

            emotionConnectStats = new EmotionStatistics();
        }

        #endregion

        #region Call Web Service

        /// <summary>
        /// Cognitives Emotion Service call
        /// </summary>
        /// <param name="imagePath">Tested image path</param>
        /// <returns></returns>
        public async Task<ConnectionResults> CallService(string imagePath)
        {
            var webclient = new HttpClient();

            // Request Headers
            webclient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "b80ed666c80c493999bc69f957694206");

            string uri = "https://westus.api.cognitive.microsoft.com/emotion/v1.0/recognize?";
            HttpResponseMessage response;
            string responseContent = "";

            // Request body
            byte[] byteData = GetImageAsByteArray(imagePath);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
                // Try HTTP Request
                try
                {
                    response = await webclient.PostAsync(uri, content);
                    responseContent = await response.Content.ReadAsStringAsync();
                }
                // Catch HTTP Request Exceptions
                catch (HttpRequestException)
                {
                    return ConnectionResults.networkTrouble;
                }
            }

            // Check deserializedResult to see if there is issues
            // Try Deserialize response
            try
            {
                emotionResults = JsonConvert.DeserializeObject<List<EmotionResults>>(responseContent);

            }
            // Catch Deserialize problem -> means the json returned a json is state an error
            catch (Exception)
            {
                return ConnectionResults.serviceTrouble;
            }

            // Check if Face Rectangle found
            if (emotionResults.Count != 0)
            {
                // Update Results to the Statistics 
                UpdateEmotionResultsToStats(emotionResults);

                // Return a success
                return ConnectionResults.success;
            }
            else
            {
                // If no Face found on image
                return ConnectionResults.noFace;
            }            
        }

        #endregion

        #region Transform to Byte

        /// <summary>
        /// Transform Image to Analyse in Byte Array
        /// </summary>
        /// <param name="imagePath">Tested image path</param>
        /// <returns></returns>
        public byte[] GetImageAsByteArray(string imagePath)
        {
            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            BinaryReader binaryReader = new BinaryReader(fileStream);
            return binaryReader.ReadBytes((int)fileStream.Length);
        }

        #endregion

        #region Update Global Stats

        /// <summary>
        /// Send Emotion Call Results to Global Stats
        /// </summary>
        /// <param name="emotionResults">Emotion Results from Call</param>
        public void UpdateEmotionResultsToStats (List<EmotionResults> emotionResults)
        {
            // Unique ID with DateTime Ticks in seconds
            emotionConnectStats.idEmotionCall = Convert.ToInt32(DateTime.Now.Ticks / 1000000000);

            // Number of Face Detected
            emotionConnectStats.faceDetected = emotionResults.Count;

            int idFace = 1;

            // List of Face & main Emotion Detected
            foreach (EmotionResults emotionFace in emotionResults)
            {
                EmotionResultsScores emotionFaceScores = emotionFace.Scores;

                // Initiate Scores and Name of main Emotion
                float emotionFaceScoresMain = emotionFace.Scores.anger;
                string emotionFaceScoresNameMain = "Anger";

                // Detect main Emotion
                if (emotionFace.Scores.contempt > emotionFaceScoresMain)
                {
                    emotionFaceScoresMain = emotionFace.Scores.contempt;
                    emotionFaceScoresNameMain = "Contempt";
                }
                else if (emotionFace.Scores.disgust > emotionFaceScoresMain)
                {
                    emotionFaceScoresMain = emotionFace.Scores.disgust;
                    emotionFaceScoresNameMain = "Disgust";
                }
                else if (emotionFace.Scores.fear > emotionFaceScoresMain)
                {
                    emotionFaceScoresMain = emotionFace.Scores.fear;
                    emotionFaceScoresNameMain = "Fear";
                }
                else if (emotionFace.Scores.happiness > emotionFaceScoresMain)
                {
                    emotionFaceScoresMain = emotionFace.Scores.happiness;
                    emotionFaceScoresNameMain = "Happiness";
                }
                else if (emotionFace.Scores.neutral > emotionFaceScoresMain)
                {
                    emotionFaceScoresMain = emotionFace.Scores.neutral;
                    emotionFaceScoresNameMain = "Neutral";
                }
                else if (emotionFace.Scores.sadness > emotionFaceScoresMain)
                {
                    emotionFaceScoresMain = emotionFace.Scores.sadness;
                    emotionFaceScoresNameMain = "Sadness";
                }
                else if (emotionFace.Scores.surprise > emotionFaceScoresMain)
                {
                    emotionFaceScoresMain = emotionFace.Scores.surprise;
                    emotionFaceScoresNameMain = "Surprise";
                }
                
                emotionConnectStats.faceEmotion.Add(new Tuple<int, String>(idFace, emotionFaceScoresNameMain));

                idFace += 1;
            }            

            // DateTime of the call
            emotionConnectStats.callEmotionDate = DateTime.Now;

            // Update Global Emotion Stats 
            Statistics.EmotionStats.Add(emotionConnectStats); 
        }

        #endregion
    }
}
