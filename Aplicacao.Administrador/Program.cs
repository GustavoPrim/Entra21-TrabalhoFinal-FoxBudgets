using Aplicacao.Administrador.Help;
using Aplicacao.Administrador.InjecoesDependencia;
using Aplicacao.Cliente.InjecoesDependencia;
using Microsoft.EntityFrameworkCore;
using Repositorio.BancoDados;
using Repositorio.InjecoesDependencia;
using Repositorio.Repositorios;
using Servico.InjecoesDependencia;
using Servico.MapeamentoEntidades;
using Servico.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services
    .AdicionarServicos()
    .AdicionarRepositorios()
    .AdicionarMapeamentoEntidades()
    .AdicionarNewtonsoftJson()
    .AdicionarNewtonsoftJson1()
    .AdicionarNewtonsoftJson2()
    .AdicionarEntityFramework(builder.Configuration)
    .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
    .AddScoped<ISessao, Sessao>()
    .AddSession(o =>
    {
        o.Cookie.HttpOnly = true;
        o.Cookie.IsEssential = true;
    });


builder.Services.AddScoped<IMaterialMapeamentoEntidade, MaterialMapeamentoEntidade>();
builder.Services.AddScoped<IMaterialService, MaterialService>();
builder.Services.AddScoped<IMaterialRepositorio, MaterialRepositorio>();


var app = builder.Build();



using (var scopo = app.Services.CreateScope())
{
    var contexto = scopo.ServiceProvider
        .GetService<OrcamentoContexto>();
    contexto.Database.Migrate();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseAuthorization();

app.MapRazorPages();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});


app.Run();