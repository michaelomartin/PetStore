using Serilog;
using Microsoft.Extensions.Hosting;
using PetStore.Services.Data;
using PetStoreEFData.DataAccess;
using System.Configuration;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Use Serilog
builder.Host.UseSerilog((ctx, lc) => lc
    //.WriteTo.Console()
    .WriteTo.File("log.txt") // Would be better to have logging into Application Insights in Azure
    .ReadFrom.Configuration(ctx.Configuration)); // Use Appsettings.json for configuration

// Inject business classes
builder.Services.AddScoped<IPetProcessor, PetProcessor>();
builder.Services.AddScoped<IPetRepository, PetRepository>();
builder.Services.AddScoped<IPetTypeRepository, PetTypeRepository>();

// Inject DB Context
var connectionString = builder.Configuration.GetConnectionString("PetStoreConnection");
builder.Services.AddDbContext<PetContext>(x => x.UseSqlServer(connectionString));


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
