using Microsoft.Extensions.DependencyInjection;
using Servico.MapeamentoEntidades;
using Servico.Servicos;

namespace Servico.InjecoesDependencia
{
    public static class ServicoExtensions
    {
        public static IServiceCollection AdicionarServicos(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IAdministradorServico, AdministradorServico>();
            services.AddScoped<IFornecedorServico, FornecedorServico>();
            services.AddScoped<IMaterialService, MaterialService>();
            services.AddScoped<IOrcamentoServico, OrcamentoServico>();
            return services;
        }

        public static IServiceCollection AdicionarMapeamentoEntidades(this IServiceCollection services)
        {
            services.AddScoped<IClienteMapeamentoEntidade, ClienteMapeamentoEntidade>();
            services.AddScoped<IAdministradorMapeamentoEntidade, AdministradorMapeamentoEntidade>();
            services.AddScoped<IFornecedorMapeamentoEntidade, FornecedorMapeamentoEntidade>();
            services.AddScoped<IMaterialMapeamentoEntidade, MaterialMapeamentoEntidade>();
            services.AddScoped<IOrcamentoMapeamentoEntidade, OrcamentoMapeamentoEntidade>();
            return services;
        }
    }
}