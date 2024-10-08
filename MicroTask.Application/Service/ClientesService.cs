using MicroTask.Domain.Interfaces;
using MicroTask.Domain.Models;

namespace MicroTask.Application.Service
{
    public class ClientesService(
        IClientesRepository clientesRepository) : IClientesService
    {
        private readonly IClientesRepository clientesRepository = clientesRepository;

        public async Task<IEnumerable<Clientes>> GetAllAsync() =>
            await clientesRepository.GetAllAsync();
    }
}
