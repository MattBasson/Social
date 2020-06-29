using System;
using System.Collections.Generic;
using System.Text;

namespace Social.Watson.Domain.Tone
{
    public class ToneResponse
    {
        
        public List<ToneMood> Moods { get; set; }
        public long StatusCode { get; set; }

        public bool Success { get; set; }



    }
}
