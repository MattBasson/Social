using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Autofac;
using Social.Watson.Domain.Service;
using Social.Watson.Domain.Tone;
using Social.Watson.Infrastructure.Services;

namespace Social.Watson.Infrastructure
{
    public static class IoC
    {
        public static IContainer Instance { get; set; }

        public static void Builder(ref ContainerBuilder builder)
        {
            

            //register data types
            builder.RegisterAssemblyTypes(typeof(IWatsonService).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(IoC).Assembly).AsImplementedInterfaces();
            
        }


        public static IContainer Setup()
        {
            var builder = new ContainerBuilder();

            Builder(ref builder);

            Instance = builder.Build();
            return Instance;
        }
    }
}
