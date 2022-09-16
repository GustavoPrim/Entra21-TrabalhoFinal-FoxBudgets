using Newtonsoft.Json;

namespace Aplicacao.Administrador.InjecoesDependencia
{
    public static class AplicacaoExtensions
    {
        public static IServiceCollection AdicionarNewtonsoftJson1(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(
                x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            return services;
        }
    }
}