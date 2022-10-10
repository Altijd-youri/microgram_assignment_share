using CASbackend.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
string connectionString = Environment.GetEnvironmentVariable("MS_SQL_CONNECTION_STRING")
                          ?? throw new InvalidOperationException("MS_SQL_CONNECTION_STRING environment variable is required!");
DbContextOptions<CursusContext> options = new DbContextOptionsBuilder<CursusContext>()
    .UseSqlServer(connectionString, options =>
    {
        options.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(3),
            errorNumbersToAdd: new List<int>()
        );
    })
    .Options;

using var context = new CursusContext(options);
context.Database.EnsureCreated();

builder.Services.AddControllers();
builder.Services.AddTransient<ICursusRepository, CursusRepository>();
builder.Services.AddTransient<DbContextOptions<CursusContext>>(_ => options);

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

app.UseAuthorization();

app.MapControllers();

app.Run();