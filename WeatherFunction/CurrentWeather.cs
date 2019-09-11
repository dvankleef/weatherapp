using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;

namespace WeatherFunction
{
    public class CurrentWeather
    {
        [FunctionName("CurrentWeather")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]
            HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept
                .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            var responseMsg = client.GetAsync(string.Format("http://api.openweathermap.org/data/2.5/weather?q=London,uk&APPID=e92050a9ce9325edfca785d38239fe85")).Result;

            return responseMsg != null
                ? (ActionResult) new OkObjectResult(responseMsg)
                : new BadRequestObjectResult("Please pass a name on the query string or in the request body");
        }
    }
}