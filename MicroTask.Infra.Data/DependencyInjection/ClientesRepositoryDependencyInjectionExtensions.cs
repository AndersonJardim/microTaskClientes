using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MicroTask.Domain.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace MicroTask.Infra.Data.DependencyInjection
{
    public static class ClientesRepositoryDependencyInjectionExtensions
    {
        public static IServiceCollection AddInfraData(
            this IServiceCollection service,
            IConfiguration configuration)
        {
            ArgumentNullException.ThrowIfNull(nameof(service));
            ArgumentNullException.ThrowIfNull(nameof(configuration));

            service.AddScoped<IDbConnection>(db => 
                new SqlConnection(configuration.GetConnectionString("UrlBase")));

            service.AddTransient<IClientesRepository, ClientesRepository>();

            return service;
        }
    }
}
