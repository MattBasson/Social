using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Social.Watson.Domain.Tone;
using Social.Watson.Infrastructure.Services;

namespace Social.Watson.Infrastructure
{
    public static class IoC
    {
        public static void Builder(ref ContainerBuilder builder)
        {

            builder.RegisterType<IToneService>().As<ToneService>();


        }
    }
}
