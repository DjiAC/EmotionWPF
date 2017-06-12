using NUnit.Framework;
using System;
namespace NUnitTests
{
    [TestFixture()]
    public class testTextAnalyticsConnect
    {
        [Test()]
        public void TestLanguageRequestFormat()
        {
            TextAnalyticsConnect TAConnect = new TextAnalyticsConnect();
            string str = "La petite abeille est contente car elle à trouver du bon pollen dans une fleur. Elle l'a ramené à sa ruche.";
            byte[] myBytes = TAConnect.LanguageRequestFormat(str);
            Console.WriteLine("str Lenght : "+ myBytes.Length); 
            Assert.IsTrue(myBytes.Length >= str.Length+36);// 36 est le nombre de bytes que le tableau fait quant'il est vide
        }
		[Test()]
		public void TestKeyPhrasesSentimentRequestFormat()
		{
			TextAnalyticsConnect TAConnect = new TextAnalyticsConnect();
			string str = "La petite abeille est contente car elle à trouver du bon pollen dans une fleur. Elle l'a ramené à sa ruche.";
            string lang = "french";
            byte[] myBytes = TAConnect.KeyPhrasesSentimentRequestFormat(str, lang);

            Console.WriteLine("len" + myBytes.Length);
            Assert.IsTrue(myBytes.Length >= str.Length +lang.Length+ 50); // 50 bytes pour une requète vide
		}
		[Test()]
		public void TestUpdateTextAnalysisResultsToStats()
		{
            
			TextAnalyticsConnect TAConnect = new TextAnalyticsConnect();
            TAConnect.UpdateTextAnalysisResultsToStats(new TextAnalyticsResults() = {languageDetected = "french", sentimentScore = , keyPhrases[] = {"Cette version musclée de la Xbox One veut se rapprocher des performances des PC gaming", "A l'occasion de sa conférence Xbox One X, Microsoft a officialisé le nouveau Forza Motorsport 7, attendu pour le mois d'octobre en boutiques."}});

			Console.WriteLine("len" + myBytes.Length);
			Assert.IsTrue(myBytes.Length >= str.Length + lang.Length + 50); // 50 bytes pour une requète vide
		}


    }
}
