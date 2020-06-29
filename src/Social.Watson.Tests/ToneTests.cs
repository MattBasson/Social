using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices.ComTypes;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.ToneAnalyzer.v3;
using IBM.Watson.ToneAnalyzer.v3.Model;
using NuGet.Frameworks;
using NUnit.Framework;

namespace Social.Watson.Tests
{
    public class ToneTests
    {
        private IamAuthenticator _authenticator;
        private ToneAnalyzerService _toneAnalyzer;
        
        [SetUp]
        public void Setup()
        {
            //Todo: This key needs to be injected by the build
            _authenticator = new IamAuthenticator(
                apikey: "{apikey}"
            );
            _toneAnalyzer = new ToneAnalyzerService("2017-09-21", _authenticator);
            
            //Todo: This key needs to be injected by the build
            _toneAnalyzer.SetServiceUrl("{url}");

        }

        [Test]
        public void Tone_Returns_200_OK()
        {

            var toneInput = new ToneInput()
            {
                Text = "Wahey!"
            };

            var result = _toneAnalyzer.Tone(
                toneInput: toneInput
            );

            Assert.AreEqual(result.StatusCode,200);
        }


        [TestCase("","")]
        public void Tone_Returns_Appropriate_Mood(string message, string mood)
        {
            var toneInput = new ToneInput()
            {
                Text = "Wahey!"
            };

            var result = _toneAnalyzer.Tone(
                toneInput: toneInput
            );

            Assert.AreEqual(result.StatusCode, 200);
        }
    }
}