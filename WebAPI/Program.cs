using Application.Features.Todos.Queries;
using Application.Interfaces;
using Infrastructure.Data;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<MongoDbContext>(sp =>
{
    var databaseName = builder.Configuration["Database:Name"];
    var connectionString = builder.Configuration["Database:ConnectionString"];

    if (string.IsNullOrEmpty(databaseName))
        throw new NullReferenceException("Database name cannot be null or empty");

    if (string.IsNullOrEmpty(connectionString))
        throw new NullReferenceException("Database connection string cannot be null or empty");

    var context = new MongoDbContext(connectionString, databaseName);
    return context;
});

builder.Services.AddScoped<ITodosRepository, TodosRepository>();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTodosHandler).Assembly));

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
