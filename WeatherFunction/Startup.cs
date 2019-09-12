using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using WeatherFunction;

[assembly: FunctionsStartup(typeof(Startup))]

namespace WeatherFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            var owmApiKey = Environment.GetEnvironmentVariable("openWeatherApiKey", EnvironmentVariableTarget.Process);

            builder.Services.AddSingleton(new CurrentWeather(owmApiKey));
        }
    }
}