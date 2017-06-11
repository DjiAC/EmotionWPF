using Microsoft.Win32;
using System;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace EmotionWPF
{
    /// <summary>
    /// Interaction logic for FrameEmotion.xaml
    /// </summary>
    public partial class FrameEmotion : Page
    {
        // Instance of TextAnalyticsConnect
        public static EmotionConnect emotionAction { get; set; }
        
        // Path Selected Image
        string imagePath = "";

        // Image Bitmap Format
        BitmapImage imageBitmap;

        /// <summary>
        /// Constructor
        /// </summary>
        public FrameEmotion()
        {
            InitializeComponent();

            emotionAction = new EmotionConnect();
        }

        /// <summary>
        /// To add and select the image to analyse
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addImage(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Open dialog box to choose image
            OpenFileDialog imageChoice = new OpenFileDialog();

            // Allow only compatible image format
            imageChoice.Filter = "Image Files(*.PNG; *.JPG;*.BMP; *.GIF)|*.PNG; *.JPG;*.BMP; *.GIF";

            // When dialog box open
            if(imageChoice.ShowDialog() == true)
            {
                // Save seleted image path
                imagePath = imageChoice.FileName;

                // Transform Image to Bitmap format to display it
                imageBitmap = new BitmapImage(new Uri(imageChoice.FileName, UriKind.Absolute));
                ImageSource displayImage = imageBitmap;
                emotionImage.Source = displayImage;                 
            }
        }

        /// <summary>
        /// Start analysis of the image selected in imagePath
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void startEmotion(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Check if an image was selected
            if (imagePath != "")
            {
                // Empty Text Analysis Results Blocks
                EmptyEmotionResultsBox();

                // Call Emotion API Service
                EmotionConnect.ConnectionResults emotionConnectionResults = await emotionAction.CallService(imagePath);
                // If everything went fine 
                if (emotionConnectionResults == EmotionConnect.ConnectionResults.success)
                {
                    // Display Emotion Results for the first face rectangle
                    DisplayEmotionResults(0);
                }
                else
                { 
                    // Display Emotion Errors
                    DisplayEmotionErrors(emotionConnectionResults);
                }
            }
            // Warn User
            else
            {
                emotionErrors.Content = "You didn't choose your image";
            }
        }

        /// <summary>
        /// To display the results from Emotion for given Face Rectangle
        /// </summary>
        /// <param name="faceIndex">index of the Face Rectangle</param>
        void DisplayEmotionResults(int faceIndex)
        {
            // Display Emotion Detected for given face rectangle
            resultAnger.Text = emotionAction.emotionResults[faceIndex].Scores.anger.ToString();
            resultContempt.Text = emotionAction.emotionResults[faceIndex].Scores.contempt.ToString();
            resultDisgust.Text = emotionAction.emotionResults[faceIndex].Scores.disgust.ToString();
            resultFear.Text = emotionAction.emotionResults[faceIndex].Scores.fear.ToString();
            resultHappiness.Text = emotionAction.emotionResults[faceIndex].Scores.happiness.ToString();
            resultNeutral.Text = emotionAction.emotionResults[faceIndex].Scores.neutral.ToString();
            resultSadness.Text = emotionAction.emotionResults[faceIndex].Scores.sadness.ToString();
            resultSurprise.Text = emotionAction.emotionResults[faceIndex].Scores.surprise.ToString();
        }

        
        /// <summary>
        /// To display the errors from Text Analysis Service
        /// </summary>
        /// <param name="textAnalysisResult">Text Analysis Connection Results</param>
        void DisplayEmotionErrors(EmotionConnect.ConnectionResults emotionConnectionResults)
        {
            // No Face Found
            if (emotionConnectionResults == EmotionConnect.ConnectionResults.noFace)
            {
                emotionErrors.Content = "No Face were found on this image";
            }
            // Network Trouble
            else if (emotionConnectionResults == EmotionConnect.ConnectionResults.networkTrouble)
            {
                emotionErrors.Content = "It seems you have network trouble - Check your internet connection";
            }
            // Service Trouble
            else if (emotionConnectionResults == EmotionConnect.ConnectionResults.serviceTrouble)
            {
                emotionErrors.Content = "The Cognitive Service returned an error";
            }
        }     

        /// <summary>
        /// Empty results text box to "clean"
        /// </summary>
        void EmptyEmotionResultsBox()
        {
            resultAnger.Text = resultContempt.Text = resultDisgust.Text = resultFear.Text = resultHappiness.Text = resultNeutral.Text = resultSadness.Text = resultSurprise.Text = "";
        }
    }
}
