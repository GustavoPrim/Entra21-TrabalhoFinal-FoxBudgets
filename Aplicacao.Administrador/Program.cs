using Aplicacao.Administrador.Help;
using Aplicacao.Administrador.InjecoesDependencia;
using Aplicacao.Cliente.InjecoesDependencia;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Repositorio.BancoDados;
using Repositorio.InjecoesDependencia;
using Servico.InjecoesDependencia;
using System.Globalization;

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
    .AddScoped<ISessao, Sessao>();
  

var app = builder.Build();

var supportedCultures = new[] { new CultureInfo("pt-BR") };
app.UseRequestLocalization(new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture(culture: "pt-BR", uiCulture: "pt-BR"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
});

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

app.MapRazorPages();

app.UseEndpoints(endpoint =>
{
    endpoint.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();