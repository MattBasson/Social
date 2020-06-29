using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.PortableExecutable;
using System.Runtime.InteropServices.ComTypes;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.ToneAnalyzer.v3;
using IBM.Watson.ToneAnalyzer.v3.Model;
using NuGet.Frameworks;
using NUnit.Framework;
using Social.Watson.Domain.Tone;

namespace Social.Watson.Tests.Integration
{
    public class ToneTests
    {
        private IamAuthenticator _authenticator;
        private ToneAnalyzerService _toneAnalyzer;
        
        [SetUp]
        public void Setup()
        {
            //Todo: Refactor this out into a service contract
            //Todo: This key needs to be injected by the build or inject by Ioc
            _authenticator = new IamAuthenticator(
                apikey: "key"
            );
            _toneAnalyzer = new ToneAnalyzerService("2017-09-21", _authenticator);

            //Todo: This key needs to be injected by the build or inject by Ioc
            _toneAnalyzer.SetServiceUrl("https://watson-api-explorer.mybluemix.net/apis/tone-analyzer-v3#!/tone/GetTone");

        }

        [Test]
        public void Tone_Returns_200_OK()
        {
            //Arrange
            var toneInput = new ToneInput()
            {
                Text = "Wahey!"
            };

            //Act
            var result = _toneAnalyzer.Tone(
                toneInput: toneInput
            );

            //Assert
            Assert.AreEqual(result.StatusCode,200);
        }


        [TestCase("Team, I know that times are tough! Product sales have been disappointing for the past three quarters. We have a competitive product, but we need to do a better job of selling it!", ToneMood.Sadness)]
        [TestCase("I am soo sad I really am and so disappointed", ToneMood.Sadness)]
        [TestCase("Success Team, this is great news, I am soo excited", ToneMood.Joy)]
        public void Tone_Returns_Appropriate_Mood(string message, ToneMood mood)
        {
            //Arrange
            var toneInput = new ToneInput()
            {
                Text = message
            };

            //Act
            var result = _toneAnalyzer.Tone(
                toneInput: toneInput
            );
            var analysis = result.Result.DocumentTone.Tones.FirstOrDefault(w=>w.ToneId == mood.ToString());


            //Assert
            Assert.IsNotNull(analysis);
            Assert.AreEqual(mood,analysis.ToneId.ParseEnum<ToneMood>());

        }
    }
}