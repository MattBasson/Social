using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Watson.ToneAnalyzer.v3;
using Social.Watson.Domain.Tone;

namespace Social.Watson.Infrastructure.Services
{
    public class ToneService: IToneService
    {

        private IamAuthenticator _authenticator;
        private ToneAnalyzerService _toneAnalyzer;
        
        

        public ToneResponse Analyze(ToneSubmission submission)
        {
            throw new NotImplementedException();
        }

        public async Task<ToneResponse> AnalyzeAsync(ToneSubmission submission)
        {
            return await Task.FromResult(new ToneResponse());
        }
    }
}
