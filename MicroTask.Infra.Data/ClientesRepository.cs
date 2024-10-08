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
            dbConnection.Open();

            return await dbConnection.QueryAsync<Clientes>("SELECT * FROM Clientes");
        }
    }
}
