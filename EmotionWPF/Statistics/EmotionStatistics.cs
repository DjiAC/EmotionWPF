using System;
using System.Collections.Generic;
using System.Text;

namespace EmotionWPF
{
    /// <summary>
    /// Class for Emotion Statistics
    /// </summary>
    public class EmotionStatistics
    {
        /// <summary>
        /// Unique ID of Emotion Call
        /// </summary>
        public string idEmotionCall { get; set; }

        /// <summary>
        /// Number of Face detected
        /// </summary>
        public int faceDetected { get; set; }

        /// <summary>
        /// List of Face with main emotion
        /// </summary>
        public List<faceEmotions> faceEmotion { get; set; }

        /// <summary>
        /// Date of Emotion Call
        /// </summary>
        public DateTime callEmotionDate { get; set; }
    }

    /// <summary>
    /// Class for face Emotions
    /// </summary>
    public class faceEmotions
    {
        /// <summary>
        /// Unique ID of face Emotions
        /// </summary>
        public int faceId { get; set; }

        /// <summary>
        /// Main Emotion of the face
        /// </summary>
        public string faceMainEmotion { get; set; }
    }
}
