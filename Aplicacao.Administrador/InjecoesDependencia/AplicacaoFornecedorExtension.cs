using Newtonsoft.Json;

namespace Aplicacao.Administrador.InjecoesDependencia
{
    public static class AplicacaoFornecedorExtensions
    {
        public static IServiceCollection AdicionarNewtonsoftJson2(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(
                x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            return services;
        }
    }
}