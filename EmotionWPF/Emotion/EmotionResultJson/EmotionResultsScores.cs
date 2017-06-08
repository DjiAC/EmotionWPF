using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    /// <summary>
    /// Class for scores
    /// </summary>
    public class EmotionResultsScores
    {
        /// <summary>
        /// Anger scores
        /// </summary>
        public float anger { get; set; }

        /// <summary>
        /// Contempt scores
        /// </summary>
        public float contempt { get; set; }

        /// <summary>
        /// Disgust scores
        /// </summary>
        public float disgust { get; set; }

        /// <summary>
        /// Fear scores
        /// </summary>
        public float fear { get; set; }

        /// <summary>
        /// Happiness scores
        /// </summary>
        public float happiness { get; set; }

        /// <summary>
        /// Neutral scores
        /// </summary>
        public float neutral { get; set; }

        /// <summary>
        /// Sadness scores
        /// </summary>
        public float sadness { get; set; }

        /// <summary>
        /// Surprise scores
        /// </summary>
        public float surprise { get; set; }
    }
}
