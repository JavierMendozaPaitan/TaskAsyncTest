using Microsoft.AspNetCore.Http.Metadata;
using Microsoft.AspNetCore.Mvc;

namespace WebApiAsyncTest01.Controllers
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
        public async Task<IActionResult> Get()
        {
            var list = await GenerateListWeatherDataAsync();

            return Ok(list);
        }

        [HttpPost]
        public async Task<IActionResult> Post()
        {
            await GenerateWeatherListData();

            return Ok("Hello World");
        }

        private async Task SendToGenerateData()
        {
            Func<List<WeatherForecast>> getData = GetListWeatherData;
            await Task.Factory.StartNew(getData);
        }

        private async Task<List<WeatherForecast>> GenerateListWeatherDataAsync()
        {
            Func<List<WeatherForecast>> getData = GetListWeatherData;
            var list = await Task.Run(getData);

            return list;
        }

        private async Task GenerateWeatherListData()
        {
            Action getData = GetWeatherData;
            await Task.Run(getData);
        }

        private async void GetWeatherData()
        {
            var list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();

            await Task.Run(() => { Thread.Sleep(7000); });
            //Task.Delay(7000);
            //Thread.Sleep(7000);
        }

        private List<WeatherForecast> GetListWeatherData()
        {
            var list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToList();
            
            //Thread.Sleep(7000);
            Task.Delay(20000).Wait();

            return list;
        }
    }
}
