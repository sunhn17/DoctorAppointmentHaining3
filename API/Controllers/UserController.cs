using DoctorAppointmentHaining.API.Security;
using DoctorAppointmentHaining.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAppointmentHaining.API.Controllers
{
    [Route("/login")]
    public class UserController : ControllerBase
    {
        private readonly JwtCreator _jwtCreator;

        public UserController(JwtCreator jwtCreator)
        {
            _jwtCreator = jwtCreator;
        }

        [HttpPost("password")]
        public async Task<IActionResult> Post([FromBody] LoginRequest request)
        {
            if (request.UserName == "admin")
                return Ok(_jwtCreator.GenerateJsonWebToken("admin"));
            return Unauthorized();
        }
    }
}
