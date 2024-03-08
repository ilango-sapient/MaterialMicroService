using CustomExHandler;
using CustomExHandler;
using DataModels;
using Microsoft.Extensions.Hosting;
using MaterialMicroService;
using Serilog;
using System.Runtime.CompilerServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddExceptionHandler<NotFoundExHandler>();
builder.Services.AddExceptionHandler<BadRequestExHandler>();
builder.Services.AddExceptionHandler<GlobalExHandler>();

builder.Services.AddLogging();

builder.Host.UseSerilog((context, configuration) =>
    configuration.ReadFrom.Configuration(context.Configuration));

//builder.Services.AddTransient<GlobalExHandler>();
builder.Services.AddProblemDetails();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseExceptionHandler();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseSerilogRequestLogging();

app.UseHttpsRedirection();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/error");
}

app.UseAuthorization();

//app.UseMiddleware<GlobalExHandler>();

//app.MapControllers();

app.MapPost("/SearchMaterials", (MaterialsSearch materialSearchInput) =>
{
    ExecutionClass refObj = new ExecutionClass(app.Logger);
    return refObj.SearchMaterials(materialSearchInput);
});

app.Run();
