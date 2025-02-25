using Microsoft.Win32;
using MinimalApiDemo.Config;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.RegisterDependencies();

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
 
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

var buildInfo = new BuildDto();
builder.Configuration.GetSection("Build").Bind(buildInfo);

app.MapGet("/", () => Results.Json(buildInfo));

// pet endpoints

app.MapEndpoints();

app.UseHttpsRedirection();

app.Run();

internal record BuildDto
{
    public string Title { get; set; } = string.Empty;
    public string Version { get; set; } = string.Empty;
}