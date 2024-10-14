using Application.Common;
using Application.Features.Todos.Queries;
using Application.Interfaces;
using Application.Validators.TodoCollectionCommands;
using FluentValidation;
using Infrastructure.Data;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Kinde;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebAPI;
using WebAPI.Options;

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

builder.Services.AddAuthorization();

var authenticationOptions = new AuthenticationOptions();
builder.Configuration.Bind("Authentication", authenticationOptions);

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(o =>
{
    var secretKeyBytes = Encoding.UTF8.GetBytes(authenticationOptions.JwtSecret);
    o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(secretKeyBytes),
        ValidAudience = authenticationOptions.ValidAudience,
        ValidIssuer = authenticationOptions.ValidIssuer,
        ValidateLifetime = true
    };
});


builder.Services.AddScoped<ITodosRepository, TodosRepository>();
builder.Services.AddScoped<ITodoCollectionsRepository, TodoCollectionsRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddValidatorsFromAssemblyContaining<CreateCollectionCommandValidator>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped(sp =>
{
    var identity = new UserIdentity();
    var httpContextAccessor = sp.GetService<IHttpContextAccessor>();

    if (httpContextAccessor is not null)
    {
		var httpContext = httpContextAccessor.HttpContext;
		if (httpContext is not null)
        {
            identity.Id = httpContext.User.FindFirst(ClaimTypes.NameIdentifier)!.Value;
        }
    }

    return identity;
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetTodosHandler).Assembly));

builder.Services.AddHttpClient("SupabaseClient", client =>
{
    var supabaseSettings = builder.Configuration.GetSection("Supabase").Get<SupabaseApiSettings>();
    if (supabaseSettings is null)
        throw new Exception("Supabase settings were not resolved");

    client.BaseAddress = new Uri(supabaseSettings.BaseUrl);
    client.DefaultRequestHeaders.Add("apiKey", supabaseSettings.ApiKey);
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
