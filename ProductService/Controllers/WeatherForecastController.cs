using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching", "Unknown"
        };
        public static List<WeatherForecast> weatehrs = new List<WeatherForecast>();                
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            //weatehrs.Add(new WeatherForecast() { Date = DateTime.Now, Summary = "Sweltering", TemperatureC = 1 });
        }

        [HttpGet]
        public IActionResult Get()
        {
            //var rng = new Random();
            //WeatherForecast[] result = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            //{
            //    Date = DateTime.Now.AddDays(index),
            //    TemperatureC = rng.Next(-20, 55),
            //    Summary = Summaries[rng.Next(Summaries.Length)]
            //})
            //.ToArray();
            return Ok(weatehrs.ToArray());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            if (weatehrs.ElementAtOrDefault(id) != null)
            {
                return Ok(weatehrs[id]);
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Post(WeatherForecast wfcCreate)
        {
            wfcCreate.Date = DateTime.Now;
            weatehrs.Add(wfcCreate);
            int index = weatehrs.Count;
            return Created($"/{index -1}",wfcCreate);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, WeatherForecast wfcModifi)
        {
            if(weatehrs.ElementAtOrDefault(id) != null)
            {
                weatehrs[id] = wfcModifi;
                return Ok(weatehrs[id]);
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (weatehrs.ElementAtOrDefault(id) != null)
            {
                weatehrs.RemoveAt(id);
                return Ok();
            }
            return NotFound();
        }
    }
}
