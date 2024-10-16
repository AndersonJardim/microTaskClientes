using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interfaces
{
    public interface IClientesRepository
    {
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<Clientes?> GetByIdAsync(int id);
        Task<Clientes> AddAsync(Clientes venda);
        Task UpdateAsync(Clientes venda);
        Task<int> DeleteAsync(int id);
    }
}
