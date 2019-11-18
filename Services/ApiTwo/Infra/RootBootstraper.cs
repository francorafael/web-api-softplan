using ApiTwo.Domain.Interfaces;
using ApiTwo.Domain.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace ApiTwo.Infra
{
    [ExcludeFromCodeCoverage]
    public class RootBootstraper
    {
        public void RootRegisterServices(IServiceCollection services)
        {
            services.AddSingleton<ICodigoGitHubDomainService, CodigoGitHubDomainService>();
        }
    }
}
