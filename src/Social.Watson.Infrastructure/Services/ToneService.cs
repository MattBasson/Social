using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.ToneAnalyzer.v3;
using IBM.Watson.ToneAnalyzer.v3.Model;
using Microsoft.Extensions.Configuration;
using Social.Watson.Domain.Tone;

namespace Social.Watson.Infrastructure.Services
{
    public class ToneService: IToneService
    {

        private readonly IamAuthenticator _authenticator;
        private readonly ToneAnalyzerService _toneAnalyzer;
        

        public ToneService(IConfiguration configuration)
        {
            
            _authenticator = new IamAuthenticator(
                apikey: configuration["Watson:ApiKey"]
            );
            _toneAnalyzer = new ToneAnalyzerService("2017-09-21", _authenticator);

            _toneAnalyzer.SetServiceUrl(configuration["Watson:ApiUrl"]);
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
