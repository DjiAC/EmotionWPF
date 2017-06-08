using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    /// <summary>
    /// Class for Emotion analysis results
    /// </summary>
    public class EmotionResults
    {
        /// <summary>
        /// Face Rectangle coordinates
        /// </summary>
        public EmotionResultsFaces FaceRectangle { get; set; }

        /// <summary>
        /// List of the scores
        /// </summary>
        public EmotionResultsScores Scores { get; set; }
    }
}
