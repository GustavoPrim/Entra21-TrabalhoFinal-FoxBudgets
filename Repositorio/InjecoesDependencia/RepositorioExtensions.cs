using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Repositorio.BancoDados;
using Repositorio.Repositorios;

namespace Repositorio.InjecoesDependencia;

public static class RepositorioExtensions
{
    public static IServiceCollection AdicionarRepositorios(this IServiceCollection services)
    {
        services.AddScoped<IAdministradorRepositorio, AdministradorRepositorio>();
        services.AddScoped<IClienteRepositorio, ClienteRepositorio>();
        services.AddScoped<IFornecedorReposistorio, FornecedorRepositorio>();
        services.AddScoped<IMaterialRepositorio, MaterialRepositorio>();
        services.AddScoped<IEstoqueRepositorio, EstoqueRepositorio>();
        services.AddScoped<IOrcamentoRepositorio, OrcamentoRepositorio>();

        return services;
    }
    public static IServiceCollection AdicionarEntityFramework(
        this IServiceCollection services, ConfigurationManager configurationManager)
    {
        services.AddDbContext<OrcamentoContexto>(options =>
            options.UseSqlServer(configurationManager.GetConnectionString("SqlServer")));

        return services;
    }
}