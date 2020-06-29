using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Microsoft.Extensions.Configuration;
using Social.Watson.Api.Controllers;
using Social.Watson.Domain.Service;
using Social.Watson.Infrastructure.Services;

namespace Social.Watson.Api
{
    public static class IoC
    {
        public static IContainer Instance { get; set; }

        public static void Build(ref ContainerBuilder builder)
        {


            //register data types
            builder.RegisterAssemblyTypes(typeof(IWatsonService).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(ToneService).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(ToneController).Assembly).AsImplementedInterfaces();


        }


        public static IContainer TestSetup()
        {
            var builder = new ContainerBuilder();
            
            Build(ref builder);

            Instance = builder.Build();
            return Instance;
        }
    }
}
