using DoctorAppointmentHaining.Controllers.Dtos;
using DoctorAppointmentHaining.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Text.Json;

namespace DoctorAppointmentHaining.Controllers
{
    [Controller]
    [Route("/Patient")]
    public class PatientController : ControllerBase
    {
        private IWebHostEnvironment _environment;
        private IConfiguration _configuration;
        private TimeAppointDb _db;

        public PatientController(TimeAppointDb db, IWebHostEnvironment environment, IConfiguration configuration)
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
                var timeslot = await _db.Products.Where(item => item.IsReserved == false).ToListAsync();

                if ((string.IsNullOrEmpty(name)) && (timeslot.Count != 0))
                {
                    return Ok(timeslot);
                }

                if (timeslot.Count == 0)
                {
                    return Ok("Appointment Slot Not Found!");
                }


                return Ok(timeslot);
            }
            else
                return Ok("Not Allowed");
        }
        [HttpPost("postslots")]
        public async Task<IActionResult> PostAsync([FromBody] PatientAppointSlot appointslot)
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

            var appointmentSlot = await _db.Products.FindAsync(appointslot.SlotId);

            if (appointmentSlot == null)
            {
                return NotFound();
            }

            appointmentSlot.PatientName = appointslot.PatientName;
            appointmentSlot.PatientId = appointslot.PatientId;
            appointmentSlot.IsReserved = true;

            _db.Products.Update(appointmentSlot);
            await _db.SaveChangesAsync();

            return Ok("Appointment Succeful!");
        }
    }
}
