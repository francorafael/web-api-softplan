using ApiTwo.Domain.Interfaces;

namespace ApiTwo.Domain.Services
{
    public class CodigoGitHubDomainService : ICodigoGitHubDomainService
    {
        private string _urlGitHubTesteSoftPlan = "https://github.com/francorafael/web-api-softplan";
        
        public string ExibirUrlCodigoTesteSoftPlanoGitHub()
        {
            return _urlGitHubTesteSoftPlan;
        }
    }
}
