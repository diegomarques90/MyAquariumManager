using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyAquariumManager.Application;
using MyAquariumManager.Application.DTOs.Usuario;
using MyAquariumManager.Application.Interfaces.Services;
using MyAquariumManager.Application.Mappers;
using MyAquariumManager.Core.Entities;
using MyAquariumManager.Core.Interfaces.Repositories;
using MyAquariumManager.Infrastructure;
using MyAquariumManager.Infrastructure.Data.Context;
using MyAquariumManager.Infrastructure.Data.Repositories;
using MyAquariumManager.Web.Extensions;
using MyAquariumManager.Web.Filters;
using MyAquariumManager.Web.Validators.Animal;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("MAMConnection");
builder.Services.AddDbContext<MyAquariumManagerDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Usuario>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<MyAquariumManagerDbContext>()
    .AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddApplication();
builder.Services.AddInfrastructure();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login"; 
    //options.AccessDeniedPath = "/Identity/Account/AccessDenied"; // Caminho para acesso negado
    options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
    options.SlidingExpiration = true;
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {     
    options.IdleTimeout = TimeSpan.FromMinutes(15);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Events.OnValidatePrincipal = async context =>
    {
        var userId = context.Principal.FindFirstValue(ClaimTypes.NameIdentifier);
        var session = context.HttpContext.Session;
        var usuarioSessao = session.GetObjectFromJson<UsuarioSessionDto>("usuario");
        var serviceProvider = context.HttpContext.RequestServices;

        if (usuarioSessao == null && !string.IsNullOrEmpty(userId))
        {
            var usuarioService = serviceProvider.GetRequiredService<IUsuarioService>();
            
            var result = await usuarioService.ObterUsuarioSessionDtoPorIdAsync(userId);

            if (result.IsFailure)
                return;
            
            session.SetObjectAsJson("usuario", result.Value);
        }

        
        var stampValidator = serviceProvider.GetRequiredService<ISecurityStampValidator>();
        await stampValidator.ValidateAsync(context);
    };
});


builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationActionFilter>();
});

builder.Services.AddValidatorsFromAssemblyContaining<CriarAnimalDtoValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseEndpoints(endpoints =>
{
    endpoints.MapRazorPages();
});

app.Run();
