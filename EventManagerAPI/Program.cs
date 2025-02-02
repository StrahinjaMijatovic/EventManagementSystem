using EventManagerAPI.Models;
using Marten;
using Wolverine;
using EventManagerAPI.Handlers;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EventManagerAPI.Data;



//inicijalizuje aplikaciju
var builder = WebApplication.CreateBuilder(args);

// ✅ Provera konekcionog stringa iz application.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("DefaultConnection nije podešen u appsettings.json.");
}

// ✅ Povezivanje Martena sa bazom podataka, i definisanje primarnog kljuca za navedene klase
builder.Services.AddMarten(options => 
{
    options.Connection(connectionString);
    options.Schema.For<User>().Identity(x => x.Id);
    options.Schema.For<Event>().Identity(x => x.Id);
    options.Schema.For<Registration>().Identity(x => x.Id);
});

builder.Services.AddControllers();

// ✅ Dodavanje samo Wolverine (bez HTTP-a)
builder.Host.UseWolverine(opts =>
{
    opts.Discovery.IncludeAssembly(typeof(Program).Assembly);
});

// ✅ Učitavanje connection string-a iz appsettings.json
var azureBlobStorageConnectionString = builder.Configuration.GetConnectionString("AzureBlobStorage");

// ✅ Registracija Azure Blob Service-a
builder.Services.AddSingleton(x => new BlobServiceClient(azureBlobStorageConnectionString));

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// ✅ Konfiguracija ASP.NET Identity
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();


var app = builder.Build();

app.UseRouting();

// ✅ Mapiranje API kontrolera
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); // Registruje sve kontrolere iz projekta koje nasleđuju ControllerBase
});

app.Run();
