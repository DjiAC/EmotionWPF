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
            Assert.IsTrue(myBytes.Length >= str.Length+36);// 36 est le nombre de bytes que le tableau fait quant'il est vide
        }
		[Test()]
		public void TestKeyPhrasesSentimentRequestFormat()
		{
			TextAnalyticsConnect TAConnect = new TextAnalyticsConnect();
			string str = "La petite abeille est contente car elle à trouver du bon pollen dans une fleur. Elle l'a ramené à sa ruche.";
            string lang = "french";
            byte[] myBytes = TAConnect.KeyPhrasesSentimentRequestFormat(str, lang);

            Assert.IsTrue(myBytes.Length >= str.Length +lang.Length+ 50); // 50 bytes pour une requète vide
		}
		


    }
}
