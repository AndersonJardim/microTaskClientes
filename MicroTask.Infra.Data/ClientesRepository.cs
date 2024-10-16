using MicroTask.Domain.Interfaces;
using MicroTask.Domain.Models;
using System.Data;
using Dapper;

namespace MicroTask.Infra.Data
{
    public class ClientesRepository(IDbConnection dbConnection) : IClientesRepository
    {
        private readonly IDbConnection dbConnection = dbConnection;

        public async Task<IEnumerable<Clientes>> GetAllAsync()
        {
            return await dbConnection.QueryAsync<Clientes>("SELECT * FROM Clientes");
        }
        public async Task<Clientes?> GetByIdAsync(int id)
        {
            var query = "SELECT TOP 1 FROM Clientes WHERE Id = @Id";
            return await dbConnection.QueryFirstOrDefaultAsync<Clientes>(query, new { Id = id });
        }
        public async Task<Clientes> AddAsync(Clientes cliente)
        {
            var query = "INSERT INTO Clientes (Nome, CpfCnpj) VALUES (@Nome, @CpfCnpj); ";
            await dbConnection.ExecuteAsync(query, new { cliente.Nome, cliente.CpfCnpj });
            return cliente;
        }
        public async Task UpdateAsync(Clientes cliente)
        {
            var query = "UPDATE Clientes SET Nome = @Nome, CpfCnpj = @CpfCnpj WHERE Id = @Id";
            await dbConnection.ExecuteAsync(query, new { cliente.Nome, cliente.CpfCnpj, cliente.Id });
        }
        public async Task<int> DeleteAsync(int id)
        {
            var query = "DELETE FROM Clientes WHERE Id = @Id";
            return await dbConnection.ExecuteAsync(query, new { Id = id });
        }
    }
}
