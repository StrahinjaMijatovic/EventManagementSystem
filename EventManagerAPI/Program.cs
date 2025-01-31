using Marten;
using Wolverine;
using Wolverine.Http;

var builder = WebApplication.CreateBuilder(args);

//Dodavanje Martena
builder.Services.AddMarten(options => 
{
    options.Connection(builder.Configuration.GetConnectionString("DefaultConnection"));
});

//Dodavanje Wolverine
builder.Host.UseWolverine();

var app = builder.Build();

// Dodaj Wolverine HTTP integraciju
app.MapWolverineEndpoints();

app.Run();




