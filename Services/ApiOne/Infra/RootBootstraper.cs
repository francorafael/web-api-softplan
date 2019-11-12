using ApiOne.Domain.Interfaces;
using ApiOne.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace ApiOne.Infra
{
    [ExcludeFromCodeCoverage]
    public class RootBootstraper
    {
        public void RootRegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ITaxaJurosDomainService, TaxaJurosDomainService>();
        }
    }
}
