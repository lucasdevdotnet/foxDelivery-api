using FoxDelivery.Api.ModelViews;
using FoxDelivery.Api.RequestDto;
using FoxDelivery.Dominio.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Net;

namespace FoxDelivery.Api.Application.v1.Empresa
{
    [ApiVersion("1.0")]
    [Route("v{version:apiVersion}/api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
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

                var payload = new
                {
                    qrCode = new
                    {
                        value = 1.00, // Valor a ser pago
                        description = "Pagamento de teste", // Descrição do pagamento
                        scheduleDate = "2025-01-25" // Data de agendamento (se aplicável)
                    }
                };


                var options = new RestClientOptions("https://api.asaas.com/v3/transfers");
                var client = new RestClient(options);
                var request = new RestRequest(payload.ToString());
                request.AddHeader("accept", "application/json");
                request.AddHeader("content-type", "application/json");
                request.AddHeader("User-Agent", "2dd9c8c5-550c-495e-a4e8-c398a7f245ba");
                request.AddHeader("access_token", "$aact_MzkwODA2MWY2OGM3MWRlMDU2NWM3MzJlNzZmNGZhZGY6OjhmZTAyMjViLTg0YzAtNGRlOS1hN2VhLWM1NTNhODAxYWEzNTo6JGFhY2hfZDcwNDE4MjItZWEzMC00MmRhLWI5YzItYjlmNWRlY2ZkMDU1");

        


                var response = await client.PostAsync(request);

                Console.WriteLine("{0}", response.Content);


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
    }
}
