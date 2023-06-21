using BlzChart.Shared;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BlzChart.Api.Controllers
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

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("GetChartData")]
        public IEnumerable<ChartData> GetChartData()
        {
            string json = "[{\"Funded\":20.000000,\"RemainingBalance\":20.000000,\"PendingApproval\":20.000000,\"Commited\":20.000000,\"Invoiced\":20.000000,\"Program\":\"Program 17\",\"TaskOrder\":\"E7127460-C6B6-4097-AB8D-8607D3B6B0E0\",\"CLIN\":\"9382B0E0-8A5A-43A9-B9ED-E0FBA262B6A0\"},{\"Funded\":1000.000000,\"RemainingBalance\":500.000000,\"PendingApproval\":500.000000,\"Commited\":1000.000000,\"Invoiced\":1000.000000,\"Program\":\"Program 7\",\"TaskOrder\":\"E1160DC3-B2C9-47A2-9A45-B30CABB4C68C\",\"CLIN\":\"25511846-0EBF-4A45-AED4-ED58A3E1C262\"},{\"Funded\":10.000000,\"RemainingBalance\":11.000000,\"PendingApproval\":11.000000,\"Commited\":11.000000,\"Invoiced\":11.000000,\"Program\":\"Program 1\",\"TaskOrder\":\"E7127460-C6B6-4097-AB8D-8607D3B6B0E0\",\"CLIN\":\"25511846-0EBF-4A45-AED4-ED58A3E1C262\"},{\"TaskOrder\":\"E7127460-C6B6-4097-AB8D-8607D3B6B0E0\",\"CLIN\":\"9382B0E0-8A5A-43A9-B9ED-E0FBA262B6A0\"},{\"TaskOrder\":\"E7127460-C6B6-4097-AB8D-8607D3B6B0E0\",\"CLIN\":\"25511846-0EBF-4A45-AED4-ED58A3E1C262\"},{\"TaskOrder\":\"E7127460-C6B6-4097-AB8D-8607D3B6B0E0\",\"CLIN\":\"25511846-0EBF-4A45-AED4-ED58A3E1C262\"}]";
            //convert this json string to object
            var data = JsonConvert.DeserializeObject<List<ChartData>>(json);
            //return this object as json
            return data;
        }


    }
}

