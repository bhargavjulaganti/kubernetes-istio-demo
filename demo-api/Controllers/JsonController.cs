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
        public async Task<IActionResult> Get()
        {
            // Send a GET request to the external service
            using (HttpResponseMessage response = await _jsonWebServerClient.GetAsync("/posts/1"))
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
