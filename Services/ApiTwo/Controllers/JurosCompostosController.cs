using ApiTwo.Application.Base;
using ApiTwo.Application.Interfaces;
using ApiTwo.Application.Services.AppJurosCompostos.Input;
using ApiTwo.Application.Services.AppJurosCompostos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Threading.Tasks;

namespace ApiTwo.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class JurosCompostosController : ControllerBase
    {
        private readonly IJurosCompostosAppService _jurosCompostosAppService;

        public JurosCompostosController(IJurosCompostosAppService jurosCompostosAppService)
        {
            _jurosCompostosAppService = jurosCompostosAppService;
        }

        [HttpGet("calculajuros")]
        [ProducesResponseType(typeof(JsonResultBase<JurosCompostosViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetAsync([FromQuery] JurosCompostosInput input)
        {
            var result = await _jurosCompostosAppService.CalcularJurosCompostosAsync(input);

            if (result == null || (result != null && result.Error))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
