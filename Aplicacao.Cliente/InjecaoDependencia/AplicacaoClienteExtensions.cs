﻿using Newtonsoft.Json;

namespace Aplicacao.Cliente.InjecaoDependencia
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