using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Microservice.Customer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomersController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new List<string> {
         "Veysel", "Hüseyin", "MUTLU", "Necati", "Veli", "Muallim", "Muiddin"
      });
    }
}
