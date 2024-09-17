using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace Demo.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JsonWebServerController : ControllerBase
    {
        private readonly HttpClient _jsonWebServerClient;

        public JsonWebServerController(IHttpClientFactory httpClientFactory)
        {
            _jsonWebServerClient = httpClientFactory.CreateClient("Sample");
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] string appId)
        {
            // Send a GET request to the external service
            using (var requestMessage = new HttpRequestMessage(HttpMethod.Get, "/posts/1"))
            {
                Console.WriteLine($"The appId is **********************************" + appId);
                // Add the x-appiid header
                requestMessage.Headers.Add("X-Custom-Header", appId);

                // Send the request
                using (HttpResponseMessage response = await _jsonWebServerClient.SendAsync(requestMessage))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the content of the response
                        var content = await response.Content.ReadAsStringAsync();
                        return Ok(content);  // Return the content as the response
                    }
                    else
                    {
                        // Handle unsuccessful responses
                        return StatusCode((int)response.StatusCode, "Error fetching data from external service.");
                    }
                }
            }

        }
    }
}
