using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using My_OPR.Data;

namespace My_OPR.Controllers
{
    // [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ApplicationDBContext _context;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, ApplicationDBContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        // [Route("Index")]
        public IActionResult Get()
        {

            var weather = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC=Random.Shared.Next(-20,55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            });
            try
            {
            var user = _context.Accounts.ToList();
                return Ok(new
                {
                    WeatherForecasts = weather,
                    User = user
                });

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
            
        }
    }
}