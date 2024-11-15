using FoxDelivery.Api.ModelViews;
using FoxDelivery.Api.RequestDto;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FoxDelivery.Api.Application.v1.Empresa
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<EmpresaController> _logger;

        public EmpresaController(ILogger<EmpresaController> logger)
        {
            _logger = logger;
        }


        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(EmpresaModelView))]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<EmpresaModelView>> Post([FromBody] EmpresaRequestDto empresaRquestDto)
        {
            try
            {
                if (empresaRquestDto == null)
                    return BadRequest("É necessário preecher empresa");

                return Ok(empresaRquestDto);
            }
   
            catch (Exception ex)
            {
                _logger.LogError($"Error serviços de Peticionamento: {ex.Message}", DateTime.Now);

                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }


        }


        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
