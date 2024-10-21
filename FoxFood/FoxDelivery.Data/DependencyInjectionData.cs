using FoxDelivery.Data.Repositories;
using FoxDelivery.Dominio.Repositories.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FoxDelivery.Data
{
    public static class DependencyInjectionData
    {
        public static void RegisterData(this IServiceCollection services)
        {
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        }
    }
}
