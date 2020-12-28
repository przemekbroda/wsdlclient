using EbiAcServiceReference;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ServiceReference1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

namespace wsdlclient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var bindings = new BasicHttpBinding(BasicHttpSecurityMode.None);

            var factory = new ChannelFactory<CalculatorSoap>(bindings, new EndpointAddress("http://www.dneonline.com/calculator.asmx"));
            factory.Endpoint.EndpointBehaviors.Add(new CustomBehavior());
            var result = await factory.CreateChannel().AddAsync(1, 2);
            return Ok(result);
        }
    }
}
