using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmotionWPF;

namespace UnitTestProject
{
    // Not used - Need mock

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
        /// Initialization of test with instances
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
        public void UnitTest_MainPage_ChangePage()
        {
            // mainWindow.ChangePage("Emotion");

            // mainWindow.ChangePage("Text Analysis");

            // mainWindow.ChangePage("Statistics");

            // mainWindow.ChangePage("Home");
        }

        /// <summary>
        /// To test MainPage_HomeButton() method
        /// </summary>
        public void UnitTest_MainPage_HomeButton()
        {
            // mainWindow.HomeButton();
        }

        /// <summary>
        /// To test MainPage_EmotionButton() method
        /// </summary>
        public void UnitTest_MainPage_EmotionButton()
        {
            // mainWindow.EmotionButton();
        }

        /// <summary>
        /// To test MainPage_TextAnalysisButton() method
        /// </summary>
        public void UnitTest_MainPage_TextAnalysisButton()
        {
            // mainWindow.TextAnalysisButton();
        }

        /// <summary>
        /// To test MainPage_StatisticsButton() method
        /// </summary>
        public void UnitTest_MainPage_StatisticsButton()
        {
            // mainWindow.StatisticsButton();
        }

        #endregion

        #region FrameHome

        /// <summary>
        /// To test FrameHome_EmotionButton() method
        /// </summary>
        public void UnitTest_FrameHome_EmotionButton()
        {
            // frameHome.EmotionButton()
        }

        /// <summary>
        /// To test FrameHome_TextAnalysisButton() method
        /// </summary>
        public void UnitTest_FrameHome_TextAnalysisButton()
        {
            // frameHome.TextAnalysisButton()
        }

        /// <summary>
        /// To test FrameHome_StatisticsButton() method
        /// </summary>
        public void UnitTest_FrameHome_StatisticsButton()
        {
            // frameHome.StatisticsButton()
        }

        #endregion

        #region FrameEmotion

        /// <summary>
        /// To test FrameEmotion_addImage() method
        /// </summary>
        public void UnitTest_FrameEmotion_addImage()
        {

        }

        /// <summary>
        /// To test FrameEmotion_startEmotion() method
        /// </summary>
        public void UnitTest_FrameEmotion_startEmotion()
        {

        }

        /// <summary>
        /// To test FrameEmotion_DisplayEmotionResults() method
        /// </summary>
        public void UnitTest_FrameEmotion_DisplayEmotionResults()
        {

        }

        /// <summary>
        /// To test FrameEmotion_DisplayEmotionErrors() method
        /// </summary>
        public void UnitTest_FrameEmotion_DisplayEmotionErrors()
        {

        }

        /// <summary>
        /// To test FrameEmotion_EmptyEmotionResultsBox() method
        /// </summary>
        public void UnitTest_FrameEmotion_EmptyEmotionResultsBox()
        {

        }

        /// <summary>
        /// To test FrameEmotion_DisplayFaceRectangles() method
        /// </summary>
        public void UnitTest_FrameEmotion_DisplayFaceRectangles()
        {

        }

        /// <summary>
        /// To test FrameEmotion_DeleteFaceRectangles() method
        /// </summary>
        public void UnitTest_FrameEmotion_DeleteFaceRectangles()
        {

        }

        /// <summary>
        /// To test FrameEmotion_HighlightFaceRectanglesSelected() method
        /// </summary>
        public void UnitTest_FrameEmotion_HighlightFaceRectanglesSelected()
        {

        }

        /// <summary>
        /// To test FrameEmotion_faceRectangle_Click() method
        /// </summary>
        public void UnitTest_FrameEmotion_faceRectangle_Click()
        {

        }

        #endregion

        #region FrameTextAnalysis

        /// <summary>
        /// To test FrameTextAnalysis_EmotionButton() method
        /// </summary>
        public void UnitTest_FrameTextAnalysis_startTextAnalysis()
        {

        }

        /// <summary>
        /// To test FrameTextAnalysis_DisplayTextAnalysisResults() method
        /// </summary>
        public void UnitTest_FrameTextAnalysis_DisplayTextAnalysisResults()
        {

        }

        /// <summary>
        /// To test FrameTextAnalysis_DisplayTextAnalysisErrors() method
        /// </summary>
        public void UnitTest_FrameTextAnalysis_DisplayTextAnalysisErrors()
        {

        }

        /// <summary>
        /// To test FrameTextAnalysis_EmptyTextAnalysisResultsBox() method
        /// </summary>
        public void UnitTest_FrameTextAnalysis_EmptyTextAnalysisResultsBox()
        {

        }

        /// <summary>
        /// To test FrameTextAnalysis_inputFocus() method
        /// </summary>
        public void UnitTest_FrameTextAnalysis_inputFocus()
        {

        }

        #endregion

        #region FrameStatistics

        /// <summary>
        /// To test FrameHome_EmotionButton() method
        /// </summary>
        public void UnitTest_FrameStatistics_InitStats()
        {

        }

        #endregion

    }
}
