﻿using System;
using System.Collections.Generic;
using System.Text;
using Autofac;
using Microsoft.Extensions.Configuration;
using NSubstitute;
using NUnit.Framework;
using Social.Watson.Api;
using Social.Watson.Domain.Tone;
using Social.Watson.Infrastructure;
using Social.Watson.Infrastructure.Services;

namespace Social.Watson.Tests.Unit
{
    [TestFixture]
    public class IocTests
    {
        
        [SetUp]
        public void Setup()
        {
           IoC.TestSetup();
        }


        [Test]
        public void ShouldHaveMappingForIToneService()
        {
            AssertContains<IToneService, ToneService>();
        }





        //Todo:refactor this out of here, make more generic in the solution infrastructure project, as this would be used across multiple IoC initializer
        private void AssertContains<TSource, TDest>()
        {
            var obj = IoC.Instance.Resolve<TSource>();
            Assert.IsInstanceOf<TDest>(obj);
        }
    }
}
