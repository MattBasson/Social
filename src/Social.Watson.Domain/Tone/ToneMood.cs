using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Social.Watson.Domain.Tone
{
    public enum ToneMood
    {
        [Description("anger")]
        Anger,
        [Description("disgust")]
        Disgust,
        [Description("fear")]
        Fear,
        [Description("joy")]
        Joy,
        [Description("sadness")]
        Sadness,
        [Description("analytical")]
        Analytical,
        [Description("confident")]
        Confident,
        [Description("tentative")]
        Tentative
    }
}
