using ApiOne.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var result = _taxaJurosDomainService.ObterTaxaDeJuros();
            return Ok(result);
        }
    }
}