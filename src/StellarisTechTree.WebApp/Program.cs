using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StellarisTechTree.Application;
using StellarisTechTree.Application.Services;
using StellarisTechTree.Infrastructure.Mapping;
using StellarisTechTree.Infrastructure.Services;
using StellarisTechTree.Infrastructure.Services.ContextService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// singletons
builder.Services.AddSingleton<IVariableService, VariableService>();
builder.Services.AddSingleton<IFileService, FileService>();
builder.Services.AddSingleton<IContextService, ContextService>();
builder.Services.AddSingleton<IMappingService, MappingService>();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

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

app.Run();