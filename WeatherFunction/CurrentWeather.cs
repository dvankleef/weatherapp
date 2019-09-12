using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WeatherFunction.Model;

namespace WeatherFunction
{
    public class CurrentWeather
    {

        private readonly EnvironmentConfig _config;
        public CurrentWeather(EnvironmentConfig config)
        {
            _config = config;
        }

        [FunctionName("CurrentWeather")]
        public async Task<WeatherRootObject> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "{city}")]
            HttpRequest req,
            ILogger log, string city)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var client = new HttpClient();

            var content = await client.GetStringAsync($"http://api.openweathermap.org/data/2.5/weather?q={city},nl&APPID={_config.OwmApiKey}");
            return JsonConvert.DeserializeObject<WeatherRootObject>(content);
        }
    }
}