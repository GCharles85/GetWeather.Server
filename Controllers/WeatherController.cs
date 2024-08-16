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

        [HttpGet("{city}")]
        public async Task<IActionResult> GetWeather(string city)
        {
            var url = $"https://www.metaweather.com/api/location/search/?query={city}";
            var response = await _httpClient.GetStringAsync(url);
            return Ok(response);
        }
    }
}
