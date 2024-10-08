using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interfaces
{
    public interface IClientesRepository
    {
        Task<IEnumerable<Clientes>> GetAllAsync();
    }
}
