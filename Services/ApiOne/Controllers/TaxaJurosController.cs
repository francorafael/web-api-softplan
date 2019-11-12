using Microsoft.AspNetCore.Mvc;

namespace ApiOne.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("0,01");
        }
    }
}