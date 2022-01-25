using Entities.Infrastructure.DatabaseContext;
using Infrastructure.DomainConnectors;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
// Add services to the container.

var progAssemblies = typeof(Program).Assembly.GetReferencedAssemblies().Select(Assembly.Load).ToArray();
builder.Services.AddDomainMessageHandler(progAssemblies);

var entityConnection = configuration.GetConnectionString("EntitiesDbConnectionString");
var identityConnection = configuration.GetConnectionString("IdentityDbConnectionString");
builder.Services.AddDbUserContext(entityConnection, identityConnection);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseIdentityServer();

app.Run();
