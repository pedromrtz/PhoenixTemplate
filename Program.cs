using Microsoft.EntityFrameworkCore;
using PhoenixTemplate.Models.Accesos;

var builder = WebApplication.CreateBuilder(args);

// Configuración de conexiones a bases de datos
var AccesosConnStr = builder.Configuration.GetConnectionString("AccesosConnStr");

// Agregar DbContexts para las bases de datos
builder.Services.AddDbContext<AccesosContext>(options => options.UseSqlServer(AccesosConnStr));

builder.Services.AddHttpContextAccessor();
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

// Configuración de CORS para permitir todas las solicitudes
builder.Services.AddCors(options => {
    options.AddPolicy("AllowAll", builder => {
        builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Home}/{id?}");

app.Run();
