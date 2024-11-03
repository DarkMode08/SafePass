// Definicion de Caracteristicas de La App
// Referencias para la conectividad
using Microsoft.EntityFrameworkCore; // Framework Instalado y en uso
using SafePass.Models;
using SafePass.Data;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Llamado de la cadena de conexion con el DBContext
builder.Services.AddDbContext<AppDBContext>(_Options =>
{
    _Options.UseSqlServer(builder.Configuration.GetConnectionString("StringConection"));
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(_Options =>
{
    _Options.LoginPath = "/Access/Login";

    _Options.ExpireTimeSpan = TimeSpan.FromMinutes(5);
});

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
