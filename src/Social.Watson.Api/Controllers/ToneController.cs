﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Social.Watson.Domain.Tone;

namespace Social.Watson.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToneController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<ToneController> _logger;
        private readonly IToneService _toneService;

        public ToneController(ILogger<ToneController> logger, IToneService toneService)
        {
            _logger = logger;
            _toneService = toneService;
        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> GetAsync()
        {
            var rng = new Random();
            var result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            });
            return await Task.FromResult(result.ToArray());
        }
    }
}
