using MicroTask.Domain.Interfaces;
using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interfaces
{
    public interface IClientesService
    {
        Task<IEnumerable<Clientes>> GetAllAsync();
        Task<Clientes?> GetByIdAsync(int id);
        Task<int> AddAsync(Clientes cliente);
        Task UpdateAsync(Clientes cliente);
        Task<int> DeleteAsync(int id);
    }
}
