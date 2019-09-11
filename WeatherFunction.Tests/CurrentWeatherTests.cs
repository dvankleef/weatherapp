using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace WeatherFunction.Tests
{
    public class CurrentWeatherTests
    {
        [Fact]
        public async Task Test()
        {
            //Arrange
            var request = new Mock<HttpRequest>();
            var logger = new Mock<ILogger>();

            //Act
            var function = new CurrentWeather();
            var rootObject = await function.Run(request.Object, logger.Object, "soest");

            //Assert
            Assert.NotNull(rootObject);
        }
    }
}