using DoctorAppointmentHaining.Controllers.Dtos;
using DoctorAppointmentHaining.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DoctorAppointmentHaining.Controllers
{
    [Controller]
    [Route("/Doctor")]
    public class TimeAppointController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IConfiguration _configuration;
        private TimeAppointDb _db;

        public TimeAppointController(TimeAppointDb db, IWebHostEnvironment environment, IConfiguration configuration)
        {
            _db = db;
            _environment = environment;
            _configuration = configuration;
        }

        [HttpGet("getslots")]
        public async Task<IActionResult> Get([FromHeader] string? name)
        {
            Console.WriteLine("Env: " + _environment.EnvironmentName);
            if (_configuration["ProductsAPIAllowed"] == "False")
            {
                return Ok("Not Allowed");
            }
            if (_environment.IsDevelopment())
            {
                if (string.IsNullOrEmpty(name))
                {
                    return Ok(_db.Products.ToList());
                }

                var product = await _db.Products.Where(item => item.DoctorName == name).ToListAsync();

                if (product == null)
                    return BadRequest("Slot not found!");

                return Ok(product);
            }
            else
                return Ok("Not Allowed");
        }

        [HttpPost("postslots")]
        public async Task<IActionResult> PostAsync([FromBody] DoctorTimeSlot product)
        {
            Console.WriteLine(JsonSerializer.Serialize(HttpContext.Request.Headers));
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values
                    .SelectMany(value => value.Errors)
                    .Select(error => error.ErrorMessage)
                    .ToList();
                return BadRequest(errors);
            }

            _db.Products.Add(product);
            await _db.SaveChangesAsync();
            return Ok("Slot Created!");
        }
    }
}
