using Newtonsoft.Json;

namespace Aplicacao.Administrador.InjecoesDependencia
{
    public static class AplicacaoMaterialExtensions
    {
        public static IServiceCollection AdicionarNewtonsoftJson0(this IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson(
                x => x.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            return services;
        }
    }
}