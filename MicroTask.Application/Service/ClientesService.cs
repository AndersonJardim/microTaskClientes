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
        public async Task<Clientes?> GetByIdAsync(int id) =>
            await clientesRepository.GetByIdAsync(id);
        public async Task<Clientes> AddAsync(Clientes cliente) =>
            await clientesRepository.AddAsync(cliente);
        public async Task UpdateAsync(Clientes cliente) =>
            await clientesRepository.UpdateAsync(cliente);
        public async Task<int> DeleteAsync(int id) =>
            await clientesRepository.DeleteAsync(id);
    }
}
