using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmotionWPF;

namespace UnitTestProject
{
    /// <summary>
    /// EmotionWPF.App Test Class
    /// </summary>
    [TestClass]
    public class EmotionWPFAppUnitTests
    {
        // Create Instances
        public MainWindow mainWindow;
        public FrameHome frameHome;
        public FrameEmotion frameEmotion;
        public FrameTextAnalysis frameTextAnalysis;
        public FrameStatistics frameStatistics;

        /// <summary>
        /// Initialization of instances for the tests
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
            // Init instances
            mainWindow = new MainWindow();
            frameHome = new FrameHome();
            frameEmotion = new FrameEmotion();
            frameTextAnalysis = new FrameTextAnalysis();
            frameStatistics = new FrameStatistics();

        }

        #region MainPage

        /// <summary>
        /// To test MainPage_ChangePage() method
        /// </summary>
        [TestMethod]
        public void MainPage_ChangePage()
        {
            // mainWindow.ChangePage("Emotion");

            // mainWindow.ChangePage("Text Analysis");

            // mainWindow.ChangePage("Statistics");

            // mainWindow.ChangePage("Home");
        }

        /// <summary>
        /// To test MainPage_HomeButton() method
        /// </summary>
        public void MainPage_HomeButton()
        {
            // mainWindow.HomeButton();
        }

        /// <summary>
        /// To test MainPage_EmotionButton() method
        /// </summary>
        public void MainPage_EmotionButton()
        {
            // mainWindow.EmotionButton();
        }

        /// <summary>
        /// To test MainPage_TextAnalysisButton() method
        /// </summary>
        public void MainPage_TextAnalysisButton()
        {
            // mainWindow.TextAnalysisButton();
        }

        /// <summary>
        /// To test MainPage_StatisticsButton() method
        /// </summary>
        public void MainPage_StatisticsButton()
        {
            // mainWindow.StatisticsButton();
        }

        #endregion

        #region FrameHome

        /// <summary>
        /// To test FrameHome_EmotionButton() method
        /// </summary>
        public void FrameHome_EmotionButton()
        {
            // frameHome.EmotionButton()
        }

        /// <summary>
        /// To test FrameHome_TextAnalysisButton() method
        /// </summary>
        public void FrameHome_TextAnalysisButton()
        {
            // frameHome.TextAnalysisButton()
        }

        /// <summary>
        /// To test FrameHome_StatisticsButton() method
        /// </summary>
        public void FrameHome_StatisticsButton()
        {
            // frameHome.StatisticsButton()
        }

        #endregion

        #region FrameEmotion

        /// <summary>
        /// To test FrameEmotion_addImage() method
        /// </summary>
        public void FrameEmotion_addImage()
        {

        }

        /// <summary>
        /// To test FrameEmotion_startEmotion() method
        /// </summary>
        public void FrameEmotion_startEmotion()
        {

        }

        /// <summary>
        /// To test FrameEmotion_DisplayEmotionResults() method
        /// </summary>
        public void FrameEmotion_DisplayEmotionResults()
        {

        }

        /// <summary>
        /// To test FrameEmotion_DisplayEmotionErrors() method
        /// </summary>
        public void FrameEmotion_DisplayEmotionErrors()
        {

        }

        /// <summary>
        /// To test FrameEmotion_EmptyEmotionResultsBox() method
        /// </summary>
        public void FrameEmotion_EmptyEmotionResultsBox()
        {

        }

        /// <summary>
        /// To test FrameEmotion_DisplayFaceRectangles() method
        /// </summary>
        public void FrameEmotion_DisplayFaceRectangles()
        {

        }

        /// <summary>
        /// To test FrameEmotion_DeleteFaceRectangles() method
        /// </summary>
        public void FrameEmotion_DeleteFaceRectangles()
        {

        }

        /// <summary>
        /// To test FrameEmotion_HighlightFaceRectanglesSelected() method
        /// </summary>
        public void FrameEmotion_HighlightFaceRectanglesSelected()
        {

        }

        /// <summary>
        /// To test FrameEmotion_faceRectangle_Click() method
        /// </summary>
        public void FrameEmotion_faceRectangle_Click()
        {

        }

        #endregion

        #region FrameTextAnalysis

        /// <summary>
        /// To test FrameTextAnalysis_EmotionButton() method
        /// </summary>
        public void FrameTextAnalysis_startTextAnalysis()
        {

        }

        /// <summary>
        /// To test FrameTextAnalysis_DisplayTextAnalysisResults() method
        /// </summary>
        public void FrameTextAnalysis_DisplayTextAnalysisResults()
        {

        }

        /// <summary>
        /// To test FrameTextAnalysis_DisplayTextAnalysisErrors() method
        /// </summary>
        public void FrameTextAnalysis_DisplayTextAnalysisErrors()
        {

        }

        /// <summary>
        /// To test FrameTextAnalysis_EmptyTextAnalysisResultsBox() method
        /// </summary>
        public void FrameTextAnalysis_EmptyTextAnalysisResultsBox()
        {

        }

        /// <summary>
        /// To test FrameTextAnalysis_inputFocus() method
        /// </summary>
        public void FrameTextAnalysis_inputFocus()
        {

        }

        #endregion

        #region FrameStatistics

        /// <summary>
        /// To test FrameHome_EmotionButton() method
        /// </summary>
        public void FrameStatistics_InitStats()
        {

        }

        #endregion

    }
}
