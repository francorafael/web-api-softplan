using ApiTwo.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ApiTwo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CodigoGitHubController : ControllerBase
    {
        private readonly ICodigoGitHubDomainService _codigoGitHubDomainService;
        public CodigoGitHubController(ICodigoGitHubDomainService codigoGitHubDomainService)
        {
            _codigoGitHubDomainService = codigoGitHubDomainService;
        }

        [HttpGet("/showmethecode")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public IActionResult Get()
        {
            var result = _codigoGitHubDomainService.ExibirUrlCodigoTesteSoftPlanoGitHub();
            return Ok(result);
        }
    }
}
