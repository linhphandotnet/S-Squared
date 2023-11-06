using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using S_Squared.EmployeeAPI.Infrastructure;
using S_Squared.EmployeeAPI.Infrastructure.Data;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
var configuration = GetConfiguration();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Add entity framework for Sql Server. Create database schema using migration tool
builder.Services.AddEntityFrameworkSqlServer()
    .AddDbContext<S_SquaredDBContext>(options =>
    {
        options.UseSqlServer(configuration.GetConnectionString("S_SquaredDB"),
                                        sqlServerOptionsAction: sqlOptions =>
                                        {
                                            sqlOptions.MigrationsAssembly(typeof(Program).GetTypeInfo().Assembly.GetName().Name);
                                            sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
                                        });
        options.EnableSensitiveDataLogging();
    }, ServiceLifetime.Scoped
    );

//Add dependencies for Employee and role repository
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();

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

using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<S_SquaredDBContext>();
    var env = scope.ServiceProvider.GetRequiredService<IWebHostEnvironment>();
    var log = scope.ServiceProvider.GetRequiredService<ILogger<SeedData>>();
    dataContext.Database.Migrate();

    new SeedData().SeedDataAsync(dataContext, log).Wait();
}

app.Run();

IConfiguration GetConfiguration()
{
    var builder = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

    return builder.Build();
}
