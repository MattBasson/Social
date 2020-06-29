using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Social.Watson.Domain.Tone;

namespace Social.Watson.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ToneController : ControllerBase
    {
        

        private readonly ILogger<ToneController> _logger;
        private readonly IToneService _toneService;
        private readonly IConfiguration _configuration;

        public ToneController(ILogger<ToneController> logger, IToneService toneService)
        {
            _logger = logger;
            _toneService = toneService;
        }

        /// <summary>
        /// Analyzes tone from a string.
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     Get /Tone
        ///     {
        ///        message:"The message you want to anaylyze"
        ///     }
        ///
        /// </remarks>
        /// <param name="message"></param>
        /// <returns>Response</returns>
        [HttpGet]
        public async Task<IActionResult> AnalyzeAsync(string message)
        {
            var result = await _toneService.AnalyzeAsync(new ToneSubmission() {Message = message});

            //Todo: Should we really be returning status codes and success messages on failure, they expose information to the end user.
            return Ok(result);
        }
    }
}
