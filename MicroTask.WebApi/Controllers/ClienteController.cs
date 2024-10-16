using Microsoft.AspNetCore.Mvc;
using MicroTask.Domain.Interfaces;
using MicroTask.Domain.Models;

namespace MicroTask.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ClientesController : ControllerBase
    {
        private readonly ILogger<ClientesController> logger;
        private readonly IClientesService clientesService;

        public ClientesController(ILoggerFactory loggerFactory, IClientesService clientesService)
        {
            logger = loggerFactory.CreateLogger<ClientesController>()
                ?? throw new ArgumentNullException(nameof(loggerFactory));
            this.clientesService = clientesService
                ?? throw new ArgumentNullException(nameof(clientesService));
        }

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

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            logger.LogInformation($"Inicio do método {nameof(GetByIdAsync)}. Id da consulta {id}.");

            var cliente = await clientesService.GetByIdAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            logger.LogInformation($"Finalizado método {nameof(GetByIdAsync)}");

            return Ok(cliente);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody] Clientes cliente)
        {
            var result = await clientesService.AddAsync(cliente);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAsync([FromBody] Clientes cliente)
        {
            await clientesService.UpdateAsync(cliente);
            return NoContent();
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await clientesService.DeleteAsync(id);
            return NoContent();
        }
    }
}
