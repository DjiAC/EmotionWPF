using System;
using System.Collections.Generic;
using System.Text;

namespace Emotion.Core
{
    /// <summary>
    /// Class for faceRectangles attributes
    /// </summary>
    public class EmotionResultsFaces
    {
        /// <summary>
        /// Position from top
        /// </summary>
        public double top { get; set; }

        /// <summary>
        /// Position from Left
        /// </summary>
        public double left { get; set; }        

        /// <summary>
        /// Width of faceRectangles
        /// </summary>
        public double width { get; set; }

        /// <summary>
        /// Height of faceRectangles
        /// </summary>
        public double height { get; set; }
    }
}
