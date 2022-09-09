﻿using Newtonsoft.Json;

namespace Aplicacao.Fornecedor.InjecoesDependencia
{
    public static class AplicacaoExtensions
    {
        public static IServiceCollection AdicionarNewtonsoftJson(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(
                x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            return services;
        }
    }
}