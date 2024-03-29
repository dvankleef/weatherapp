using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace WeatherFunction.Tests
{
    public class CurrentWeatherTests
    {
        [Fact(Skip = "Testen of dep inje werkt")]
        public async Task RunWithCityShouldReturnObject()
        {
            //Arrange
            var request = new Mock<HttpRequest>();
            var logger = new Mock<ILogger>();
            var startup = new Startup();


            //Act
            var function = new CurrentWeather(new EnvironmentConfig());
            var rootObject = await function.Run(request.Object, logger.Object, "soest");

            //Assert
            Assert.NotNull(rootObject);
        }

    }
}