using Microsoft.EntityFrameworkCore;
using MyAquariumManager.Application.Mappers;
using MyAquariumManager.Core.Interfaces.Repositories;
using MyAquariumManager.Infrastructure.Data.Context;
using MyAquariumManager.Infrastructure.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connectionString = builder.Configuration.GetConnectionString("MAMConnection");
builder.Services.AddDbContext<MyAquariumManagerDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped<IAnimalRepository, AnimalRepository>();


builder.Services.AddAutoMapper(typeof(AnimalProfile).Assembly);

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
