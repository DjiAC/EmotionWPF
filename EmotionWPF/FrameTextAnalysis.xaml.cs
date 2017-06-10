using Emotion.Core;
using System.Windows.Controls;

namespace EmotionWPF
{
    /// <summary>
    /// Interaction logic for FrameTextAnalysis.xaml
    /// </summary>
    public partial class FrameTextAnalysis : Page
    {       
        /// <summary>
        /// Constructor
        /// </summary>
        public FrameTextAnalysis()
        {
            InitializeComponent();

            textAnalyticsAction = new TextAnalyticsConnect();
        }         
    }
}
