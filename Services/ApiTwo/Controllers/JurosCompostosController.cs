using ApiTwo.Application.Base;
using ApiTwo.Application.Interfaces;
using ApiTwo.Application.Services.AppJurosCompostos.Input;
using ApiTwo.Application.Services.AppJurosCompostos.ViewModel;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("calculajuros")]
        [ProducesResponseType(typeof(JsonResultBaseViewModel<JurosCompostosViewModel>), (int)HttpStatusCode.OK)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> PostAsync([FromBody] JurosCompostosFiltroInput input)
        {
            var result = await _jurosCompostosAppService.CalcularJurosCompostos(input.ValorInicial, input.Tempo);

            if (result == null || (result != null && result.Error))
            {
                return BadRequest(result);
            }
            return Ok(result);
        }
    }
}
