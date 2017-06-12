using System.Windows.Shapes;
using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Specialized;

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

        // List of Face Rectangle for drawing
        List<Rectangle> faceRectangles { get; set; }

        // Instance of Start Button
        static Image start { get; set; }

        // Instance of Loading
        static Image loading { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public FrameEmotion()
        {
            InitializeComponent();

            emotionAction = new EmotionConnect();
            faceRectangles = new List<Rectangle>();

            start = startButton;
            loading = loadingLogo;
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
            DeleteFaceRectangles();

            // Allow only compatible image format
            imageChoice.Filter = "Image Files(*.PNG; *.JPG;*.BMP; *.GIF; *.JPEG)|*.PNG; *.JPG;*.BMP; *.GIF; *.JPEG";

            // When dialog box open
            if(imageChoice.ShowDialog() == true)
            {
                // Save seleted image path
                imagePath = imageChoice.FileName;

                // Transform Image to Bitmap format to display it
                imageBitmap = new BitmapImage(new Uri(imageChoice.FileName, UriKind.Absolute));
                ImageSource displayImage = imageBitmap;
                emotionImage.Source = displayImage;
                emotionErrors.Content = "";
            }
        }

        /// <summary>
        /// Start analysis of the image selected in imagePath
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void startEmotion(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            start.Visibility = Visibility.Hidden;
            loading.Visibility = Visibility.Visible;

            // Check if an image was selected
            if (imagePath != "")
            {
                // Empty Text Analysis Results Blocks
                EmptyEmotionResultsBox();
               
                DeleteFaceRectangles();

                // Call Emotion API Service
                EmotionConnect.ConnectionResults emotionConnectionResults = await emotionAction.CallService(imagePath);
                // If everything went fine 
                if (emotionConnectionResults == EmotionConnect.ConnectionResults.success)
                {
                    // Display Emotion Results for the first face rectangle
                    DisplayEmotionResults(0);
                    DisplayFaceRectangles();
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

            start.Visibility = Visibility.Visible;
            loading.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// To display the results from Emotion for given Face Rectangle
        /// </summary>
        /// <param name="faceIndex">index of the Face Rectangle</param>
        void DisplayEmotionResults(int faceIndex)
        {
            emotionErrors.Content = "";

            // Display Emotion Detected for given face rectangle
            resultAnger.Text = emotionAction.emotionResults[faceIndex].Scores.anger.ToString();
            resultContempt.Text = emotionAction.emotionResults[faceIndex].Scores.contempt.ToString();
            resultDisgust.Text = emotionAction.emotionResults[faceIndex].Scores.disgust.ToString();
            resultFear.Text = emotionAction.emotionResults[faceIndex].Scores.fear.ToString();
            resultHappiness.Text = emotionAction.emotionResults[faceIndex].Scores.happiness.ToString();
            resultNeutral.Text = emotionAction.emotionResults[faceIndex].Scores.neutral.ToString();
            resultSadness.Text = emotionAction.emotionResults[faceIndex].Scores.sadness.ToString();
            resultSurprise.Text = emotionAction.emotionResults[faceIndex].Scores.surprise.ToString();

            // Determine Main Emotion for Selected Rectangle
            Dictionary<String, float> emotionScores = new Dictionary<String, float>();
            emotionScores.Add("Anger", float.Parse(resultAnger.Text));
            emotionScores.Add("Contempt", float.Parse(resultContempt.Text));
            emotionScores.Add("Disgust", float.Parse(resultDisgust.Text));
            emotionScores.Add("Fear",float.Parse(resultFear.Text));
            emotionScores.Add("Happiness", float.Parse(resultHappiness.Text));
            emotionScores.Add("Neutral", float.Parse(resultNeutral.Text));
            emotionScores.Add("Sadness", float.Parse(resultSadness.Text));
            emotionScores.Add("Surprise", float.Parse(resultSurprise.Text));
            
            mainEmotion.Content = "This person main Emotion seems to be : " + emotionScores.Last(x => x.Value == emotionScores.Values.Max()).Key;        
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
                emotionErrors.Content = "No Face were detected on this image";
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

        /// <summary>
        /// To display all the face rectangle detected by the service on the image
        /// </summary>
        void DisplayFaceRectangles()
        {
            int faceIndex = 0;

            // Foreach list of Face detected
            foreach (EmotionResults face in emotionAction.emotionResults)
            {
                // Calcul size ratio between original and displayed image
                double ratio = imageBitmap.PixelHeight / emotionImage.ActualHeight;

                // Calcul Margin between Grid and Image displayed
                Thickness marginGridImage = new Thickness(emotionImage.Margin.Left + (face.FaceRectangle.left / ratio),
                                                          emotionImage.Margin.Top + (face.FaceRectangle.top / ratio),
                                                          0,
                                                          0);

                // Detect if photo is in Portrait or Landscape mode
                if(emotionImage.ActualHeight < emotionImage.ActualWidth)
                {
                    marginGridImage.Top += ((GridImage.ActualHeight - emotionImage.ActualHeight) / 2);
                }
                else if (emotionImage.ActualHeight > emotionImage.ActualWidth)
                {
                    marginGridImage.Left += ((GridImage.ActualWidth - emotionImage.ActualWidth) / 2);
                }
                else
                {
                    marginGridImage.Top += ((GridImage.ActualHeight - emotionImage.ActualHeight) / 2);
                    marginGridImage.Left += ((GridImage.ActualWidth - emotionImage.ActualWidth) / 2);
                }                

                // Create Rectangle for face with coordinates & dimensions calculated
                Rectangle faceRectangle = new Rectangle()
                {
                    // Design
                    Stroke = new SolidColorBrush(Color.FromRgb(50, 137, 199)),
                    StrokeThickness = 2,
                    Cursor = Cursors.Cross,
                    Fill = new SolidColorBrush(Color.FromArgb(0,0,0,0)),

                    // Placement
                    Height = face.FaceRectangle.height / ratio,
                    Width = face.FaceRectangle.width / ratio,
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Top,
                    Margin = marginGridImage,

                    // Individual ID to find it - Name Property impossible with "0"
                    Uid = faceIndex.ToString()

                };

                // Display Face Rectangle on image
                GridEmotion.Children.Add(faceRectangle);

                // Add it to the list of Face Rectangle
                faceRectangles.Add(faceRectangle);

                // Add MouseUp Detection method
                faceRectangle.MouseUp += (sender, e) => faceRectangle_Click(sender, e, faceRectangle.Uid);

                // Increment faceIndex
                faceIndex += 1;
            }

            //Hightlight first Face Rectangle Detected
            HighlightFaceRectangleSelected(0);
        }

        /// <summary>
        /// To delete the previous Face Rectangles drawed
        /// </summary>
        void DeleteFaceRectangles()
        {
            // Clear all Rectangles
            // From display
            foreach(Rectangle faceRectangle in faceRectangles)
            {
                GridEmotion.Children.Remove(faceRectangle);
            }

            // From List
            faceRectangles.Clear();

            mainEmotion.Content = "";
        }

        /// <summary>
        /// To display the face rectangle selected associated to results
        /// </summary>
        void HighlightFaceRectangleSelected(int faceIndex)
        {
            // Put selected rectangle in red
            faceRectangles[faceIndex].Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0));
        }

        /// <summary>
        /// Detect click on Face Rectangle
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="e">Unique Name ID of the rectangle</param>
        private void faceRectangle_Click(object sender, MouseButtonEventArgs e, string Uid)
        {
            // Set all Rectangle to basic color
            foreach (Rectangle faceRectangle in faceRectangles)
            {
                faceRectangle.Stroke = new SolidColorBrush(Color.FromRgb(50, 137, 199));
            }

            // Display correct Results & HighLight the selected Rectangle
            DisplayEmotionResults(int.Parse(Uid));
            HighlightFaceRectangleSelected(int.Parse(Uid));
        }
    }
}
