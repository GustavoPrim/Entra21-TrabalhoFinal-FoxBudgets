﻿using Entra21.CSharp.Area21.Service.Email;
using Microsoft.Extensions.DependencyInjection;
using Servico.Email;
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
            services.AddScoped<IEstoqueServico, EstoqueServico>();
            services.AddScoped<IOrcamentoServico, OrcamentoServico>();
            services.AddScoped<IEmail, EmailService>();

            return services;
        }

        public static IServiceCollection AdicionarMapeamentoEntidades(this IServiceCollection services)
        {
            services.AddScoped<IClienteMapeamentoEntidade, ClienteMapeamentoEntidade>();
            services.AddScoped<IAdministradorMapeamentoEntidade, AdministradorMapeamentoEntidade>();
            services.AddScoped<IFornecedorMapeamentoEntidade, FornecedorMapeamentoEntidade>();
            services.AddScoped<IMaterialMapeamentoEntidade, MaterialMapeamentoEntidade>();
            services.AddScoped<IEstoqueMapeamentoEntidade, EstoqueMapeamentoEntidade>();
            services.AddScoped<IOrcamentoMapeamentoEntidade, OrcamentoMapeamentoEntidade>();

            return services;
        }
    }
}