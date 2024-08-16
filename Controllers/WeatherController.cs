using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Threading.Tasks;

namespace MyBlazorApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        private readonly HttpClient _httpClient;

        public WeatherController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpGet("forecast")]
        public async Task<IActionResult> GetWeather([FromQuery] double lat, [FromQuery] double lon)
        {
            // Construct the URL with the provided latitude and longitude
            var apiKey = "98f72dc80cc8da714dbc55f1a67db8b0"; // Replace with your actual API key
            var url = $"https://api.openweathermap.org/data/3.0/onecall?lat={lat}&lon={lon}&exclude=minutely,hourly,alerts&appid={apiKey}";

            // Make the HTTP request to the external API
            var response = await _httpClient.GetStringAsync(url);

            // Return the response from the external API
            return Ok(response);
        }
    }
}
