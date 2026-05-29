using ex1_clinica.Data;
using ex1_clinica.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// colocar isso para rodar o scaffolding bem aqui
//builder.Services.AddDbContext<FakeContext>();

builder.Services.Configure<MongoSettings>(
    builder.Configuration.GetSection("MongoConnection")
);
// registra Mongo como servico unico
builder.Services.AddSingleton<ContextMongoDb>();


builder.Services.AddRazorPages();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
