using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CollegeManagementSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConfigController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("myinfo")]
        public IActionResult GetMyInfo()
        {
            var name = _configuration["MyInfo:Name"];
            var age = _configuration["MyInfo:Age"];
            var address = _configuration["MyInfo:Address"];

            return Ok(new
            {
                Name = name,
                Age = age,
                Address = address
            });
        }
    }
}