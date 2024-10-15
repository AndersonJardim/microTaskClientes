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
            //dbConnection.Open();
            return await dbConnection.QueryAsync<Clientes>("SELECT * FROM Clientes");
        }
        public async Task<int> AddAsync(Clientes cliente)
        {
            var query = "INSERT INTO Clientes (Nome, CpfCnpj) VALUES (@Nome, @CpfCnpj); SELECT CAST(SCOPE_IDENTITY() as int);";
            return await dbConnection.QuerySingleAsync<int>(query, new { cliente.Nome, cliente.CpfCnpj });
        }
        public async Task<Clientes?> GetByIdAsync(int id)
        {
            var query = "SELECT * FROM Clientes WHERE Id = @Id";
            return await dbConnection.QueryFirstOrDefaultAsync<Clientes>(query, new { Id = id });
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
