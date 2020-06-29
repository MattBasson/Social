using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Social.Watson.Api.Controllers;
using Social.Watson.Domain.Service;

namespace Social.Watson.Api
{
    public static class IoC
    {
        public static IContainer Instance { get; set; }

        public static void Builder(ref ContainerBuilder builder)
        {


            //register data types
            builder.RegisterAssemblyTypes(typeof(IWatsonService).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(Infrastructure.IoC).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(ToneController).Assembly).AsImplementedInterfaces();

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
