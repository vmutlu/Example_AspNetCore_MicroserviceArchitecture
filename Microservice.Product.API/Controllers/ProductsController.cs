using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Microservice.Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get() => Ok(new List<string> {
        "Telefon", "Bilgisayar", "Kalem", "Kağıt", "Mouse", "Kağıt"
      });
    }
}
