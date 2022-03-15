using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//con esto dejamos la framework que cree las instancias del contexto y que solo lo inyecte en los controladores
//PARA QUE USE EL SQL EN MEMORIA
//builder.Services.AddDbContext<StarwarsDb>(options => options.UseInMemoryDatabase("SwContext"));


//BUSCA LA CADENA DE CONECCION EN EL APPSETTINGS
builder.Services.AddDbContext<StarwarsDb>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("SwContext")));

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
