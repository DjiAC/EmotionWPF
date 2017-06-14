using NUnit.Framework;
using System;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace NUnitTests
{
    [TestFixture()]
    public class TestStatistics
    {
        [Test()]
        public void TestGetEmotionStats()
        {
            Statistics statControl = new Statistics();
            var stats = statControl.GetEmotionStats();
            Assert.IsNotEmpty(stats);
            var json = System.IO.File.ReadAllText(@"/Users/nicolas/Projects/DjiAC/EmotionWPF/DjiAC/EmotionWPF.git/branches/dev/NUnitTests/Statistics/EmotionStats.json");
            var test = JsonConvert.DeserializeObject<List<EmotionStatistics>>(json);
            for (int i = 0; i < test.Count; i++){
                Assert.IsTrue(stats[i].idEmotionCall == test[i].idEmotionCall);
				Assert.IsTrue(stats[i].faceDetected == test[i].faceDetected);
                Assert.IsTrue(stats[i].callEmotionDate == test[i].callEmotionDate);
			}

        }

		[Test()]
		public void TestGetTextAnalysisStats()
        {
            Statistics statControl = new Statistics();
			var stats = statControl.GetTextAnalysisStats();
			Assert.IsNotEmpty(stats);
	        var json = System.IO.File.ReadAllText(@"/Users/nicolas/Projects/DjiAC/EmotionWPF/DjiAC/EmotionWPF.git/branches/dev/NUnitTests/Statistics/TextAnalysisStats.json");
			var test = JsonConvert.DeserializeObject<List<TextAnalysisStatistics>>(json);
            for (int i = 0; i<test.Count; i++){
                Assert.IsTrue(stats[i].idTextAnalysisCall == test[i].idTextAnalysisCall);
                Assert.IsTrue(stats[i].languageDetected == test[i].languageDetected);
				Assert.IsTrue(stats[i].sentimentScore == test[i].sentimentScore);
				Assert.IsTrue(stats[i].callTextAnalyticsDate == test[i].callTextAnalyticsDate);
            }
        }

		[Test()]
		public void TestCalculEmotionStats()
		{
			var json = System.IO.File.ReadAllText(@"/Users/nicolas/Projects/DjiAC/EmotionWPF/DjiAC/EmotionWPF.git/branches/dev/NUnitTests/Statistics/EmotionStats.json");

			Statistics statControl = new Statistics();
			JsonSerializer serializer = new JsonSerializer();
			var test = JsonConvert.DeserializeObject<List<EmotionStatistics>>(json);

			statControl.CalculEmotionStats((List<EmotionStatistics>)test);

            //statControl.CalculEmotionStats((EmotionStatistics)serializer.SerializeObject(json));

            Console.WriteLine(statControl.facesPerEmotion["Contempt"]);
            Assert.IsNotEmpty(statControl.facesPerEmotion);
            //Assert.IsTrue(statControl.facesPerEmotion["Anger"] == );
            //Assert.Fail();
		}

		[Test()]
		public void TestTextAnalysisStats()
		{
			var json = System.IO.File.ReadAllText(@"/Users/nicolas/Projects/DjiAC/EmotionWPF/DjiAC/EmotionWPF.git/branches/dev/NUnitTests/Statistics/TextAnalysisStats.json");

			Statistics statControl = new Statistics();
			JsonSerializer serializer = new JsonSerializer();
			var test = JsonConvert.DeserializeObject<List<TextAnalysisStatistics>>(json);

            statControl.CalculTextAnalysisStats((List<TextAnalysisStatistics>)test);

            Assert.IsTrue(statControl.score0To30 > 0);
			Assert.IsTrue(statControl.score31To60 > 0);
			Assert.IsTrue(statControl.score61To100 > 0);
		}

		[Test()]
		public void TestUpdateEmotionJSONStats()
		{
			Statistics statControl = new Statistics();
			JsonSerializer serializer = new JsonSerializer();
			
            var stats = JsonConvert.SerializeObject(statControl.EmotionStats);
			statControl.UpdateEmotionJSONStats();

			var json = System.IO.File.ReadAllText(@"/Users/nicolas/Projects/DjiAC/EmotionWPF/DjiAC/EmotionWPF.git/branches/dev/NUnitTests/Statistics/EmotionStats.json");
			var test = JsonConvert.DeserializeObject<List<TextAnalysisStatistics>>(json);
            Assert.IsNotEmpty(stats);
            Assert.IsTrue(stats == json);
        }
		[Test()]
		public void TestUpdateTextAnalysisJSONStats()
		{
			Statistics statControl = new Statistics();
			JsonSerializer serializer = new JsonSerializer();

			var stats = JsonConvert.SerializeObject(statControl.TextAnalysisStats);
			statControl.UpdateTextAnalysisJSONStats();

			var json = System.IO.File.ReadAllText(@"/Users/nicolas/Projects/DjiAC/EmotionWPF/DjiAC/EmotionWPF.git/branches/dev/NUnitTests/Statistics/TextAnalysisStats.json");
			var test = JsonConvert.DeserializeObject<List<TextAnalysisStatistics>>(json);
			Assert.IsNotEmpty(stats);
			json = System.IO.File.ReadAllText(@"/Users/nicolas/Projects/DjiAC/EmotionWPF/DjiAC/EmotionWPF.git/branches/dev/NUnitTests/Statistics/TextAnalysisStats.json");


			Assert.IsTrue(stats == json);
		}
    }
}

