using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Social.Watson.Domain.Tone
{
    public interface IToneService
    {
        ToneResponse Analyze(ToneSubmission submission);

        Task<ToneResponse> AnalyzeAsync(ToneSubmission submission);
    }
}
