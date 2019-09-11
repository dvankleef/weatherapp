using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Hosting;
using Microsoft.Extensions.DependencyInjection;

[assembly: WebJobsStartup(typeof(WeatherFunction.Startup))]

namespace WeatherFunction
{
    public class Startup : IWebJobsStartup
    {
        public void Configure(IWebJobsBuilder builder)
        {
            var apiKey = Environment.GetEnvironmentVariable("openWeatherApiKey", EnvironmentVariableTarget.Process);

            builder.Services.AddSingleton(new CurrentWeather(apiKey));

        }
    }
}