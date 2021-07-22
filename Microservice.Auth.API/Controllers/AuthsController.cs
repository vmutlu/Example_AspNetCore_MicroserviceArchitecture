using Microservice.Auth.API.Token;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Microservice.Auth.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthsController : ControllerBase
    {
        IConfiguration _configuration;
        public AuthsController(IConfiguration configuration) => _configuration = configuration;

        [HttpGet]
        public IActionResult Login(string userName, string password)
        {
            TokenHandler._configuration = _configuration;
            return Ok(userName == "mutlu" && password == "123456" ? TokenHandler.CreateAccessToken() : new UnauthorizedResult());
        }
    }
}
