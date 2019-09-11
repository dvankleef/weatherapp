using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
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
            var function = new CurrentWeather("e92050a9ce9325edfca785d38239fe85");
            var rootObject = await function.Run(request.Object, logger.Object, "soest");

            //Assert
            Assert.NotNull(rootObject);
        }
    }
}