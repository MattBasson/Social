using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.ToneAnalyzer.v3;
using IBM.Watson.ToneAnalyzer.v3.Model;
using Social.Watson.Domain.Tone;

namespace Social.Watson.Infrastructure.Services
{
    public class ToneService: IToneService
    {

        private IamAuthenticator _authenticator;
        private ToneAnalyzerService _toneAnalyzer;

        public ToneService()
        {
            //Todo: Refactor this out into a service contract
            //Todo: This key needs to be injected by the build or inject by Ioc
            _authenticator = new IamAuthenticator(
                apikey: "api_key"
            );
            _toneAnalyzer = new ToneAnalyzerService("2017-09-21", _authenticator);

            //Todo: This key needs to be injected by the build or inject by Ioc
            _toneAnalyzer.SetServiceUrl("https://watson-api-explorer.mybluemix.net/apis/tone-analyzer-v3#!/tone/GetTone");
        }

        internal ToneResponse AnalyzeInternal(ToneSubmission submission)
        {

            var result = _toneAnalyzer.Tone(
                toneInput: new ToneInput()
                {
                    Text = submission.Message
                }
            );
            return new ToneResponse()
            {
                Moods = result.Result.DocumentTone.Tones.ConvertEnumerableToEnumEnumerable<ToneMood,ToneScore>(input => input.ToneId.ParseEnum<ToneMood>() ).ToList(),
                StatusCode =  result.StatusCode,
                Success = result.StatusCode != 200

            };
        }

        public ToneResponse Analyze(ToneSubmission submission)
        {
            return AnalyzeInternal(submission);
        }

        public async Task<ToneResponse> AnalyzeAsync(ToneSubmission submission)
        {
            return await Task.FromResult(AnalyzeInternal(submission));
        }
    }
}
