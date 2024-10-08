using Microsoft.Extensions.DependencyInjection;
using MicroTask.Application.Service;
using MicroTask.Domain.Interfaces;

namespace MicroTask.Application.DependencyInjection
{
    public static class ClientesApplicationDependencyInjectionExtensions
    {
        public static IServiceCollection AddApplication(
            this IServiceCollection service)
        {
            ArgumentNullException.ThrowIfNull(nameof(service));

            service.AddTransient<IClientesService, ClientesService>();

            return service;
        }
    }
}
