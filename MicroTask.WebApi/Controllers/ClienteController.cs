using Microsoft.AspNetCore.Mvc;
using MicroTask.Domain.Interfaces;

namespace MicroTask.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ClientesController(
        ILoggerFactory loggerFactory,
        IClientesService clientesService) : ControllerBase
    {
        private readonly ILogger logger = loggerFactory.CreateLogger<ClientesController>()
                ?? throw new ArgumentNullException(nameof(loggerFactory));

        private readonly IClientesService clientesService = clientesService
                ?? throw new ArgumentNullException(nameof(clientesService));

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetAllAsync()
        {
            logger.LogInformation($"Inicio do método {nameof(GetAllAsync)}");

            var clientes = await clientesService.GetAllAsync();

            logger.LogInformation($"Finalizado método {nameof(GetAllAsync)}");

            return Ok(clientes);
        }
    }
}
