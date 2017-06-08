using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    /// <summary>
    /// Class for Emotion Statistics
    /// </summary>
    public class EmotionStatistics
    {
        /// <summary>
        /// Unique ID of Emotion Call
        /// </summary>
        public int idEmotionCall { get; set; }

        /// <summary>
        /// Number of Face detected
        /// </summary>
        public int faceDetected { get; set; }

        /// <summary>
        /// Dictionnary of Face with major emotion
        /// </summary>
        public List<Tuple<int, String>> faceEmotion { get; set; }

        /// <summary>
        /// Date of Emotion Call
        /// </summary>
        public DateTime callEmotionDate { get; set; }
    }
}
