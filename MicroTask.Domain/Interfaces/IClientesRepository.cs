using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interfaces
{
    public interface IClientesRepository
    {
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<Clientes?> GetByIdAsync(int id);
        Task<int> AddAsync(Clientes venda);
        Task UpdateAsync(Clientes venda);
        Task<int> DeleteAsync(int id);
    }
}
