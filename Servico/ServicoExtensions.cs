using Aplicacao.Administradores;
using Microsoft.Extensions.DependencyInjection;
using Servico.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servico
{
    public static class ServicoExtensions
    {
        public static IServiceCollection AdicionarServicos(this IServiceCollection services)
        {
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IAdministradorServico, AdministradorServico>();
            services.AddScoped<IFornecedorServico, FornecedorServico>();

            return services;
        }
    }
}
