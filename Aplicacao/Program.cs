using Aplicacao.Help;
using Aplicacao.InjecoesDependencia;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Repositorio.BancoDados;
using Repositorio.InjecoesDependencia;
using Servico.InjecoesDependencia;
using System.Globalization;
using Repositorio.Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<RazorViewEngineOptions>(options =>
{
    options.AreaViewLocationFormats.Clear();
    options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Areas/{2}/Views/{1}/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Areas/{2}/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Views/Shared/{0}.cshtml");
    options.AreaViewLocationFormats.Add("/Views/{0}.cshtml");
});

builder.Services.AddControllersWithViews();

builder.Services
    .AdicionarServicos()
    .AdicionarRepositorios()
    .AdicionarMapeamentoEntidades()
   // .AdicionarNewtonsoftJson()
    .AdicionarEntityFramework(builder.Configuration)
    .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
    .AddScoped<ISessao, Sessao>()
    .AddSession(o =>
    {
        o.Cookie.HttpOnly = true;
        o.Cookie.IsEssential = true;
    });

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

app.UseSession();

app.UseAuthorization();

app.UseEndpoints(endpoint =>
{
    endpoint.MapAreaControllerRoute(
        name: "AreaAdministrador",
        areaName: "Administrador",
        pattern: "Administrador/{controller=Home}/{action=Index}/{id?}");

    endpoint.MapAreaControllerRoute(
        name: "AreaFornecedor",
        areaName: "Fornecedor",
        pattern: "Fornecedor/{controller=Home}/{action=Index}/{id?}");

    endpoint.MapAreaControllerRoute(
        name: "AreaCliente",
        areaName: "Cliente",
        pattern: "Cliente/{controller=Home}/{action=Index}/{id?}");

    endpoint.MapAreaControllerRoute(
        name: "AreaPublico",
        areaName: "Publico",
        pattern: "{controller=Home}/{action=Index}/{id?}");

    endpoint.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();