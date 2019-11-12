using ApiOne.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiOne.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaJurosDomainService _taxaJurosDomainService;
        public TaxaJurosController(ITaxaJurosDomainService taxaJurosDomainService)
        {
            _taxaJurosDomainService = taxaJurosDomainService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var result = _taxaJurosDomainService.GetTaxaDeJuros();
            return Ok(result);
        }
    }
}