using MicroTask.Domain.Models;

namespace MicroTask.Domain.Interfaces
{
    public interface IClientesService
    {
        Task<IEnumerable<Clientes>> GetAllAsync();
    }
}
