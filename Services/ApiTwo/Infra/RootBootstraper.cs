using ApiTwo.Application.Interfaces;
using ApiTwo.Application.Services.AppJurosCompostos;
using ApiTwo.Core;
using ApiTwo.Core.Providers;
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
            services.AddSingleton<IHttpClientProvider, HttpClientProvider>();
            services.AddHttpClient<IHttpClientProvider, HttpClientProvider>();
            services.AddSingleton<IJurosCompostosAppService, JurosCompostosAppService>();
            services.AddSingleton<ICodigoGitHubDomainService, CodigoGitHubDomainService>();
            services.AddSingleton<IJurosCompostosDomainService, JurosCompostosDomainService>();
        }
    }
}
