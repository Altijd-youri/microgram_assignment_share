using Microsoft.EntityFrameworkCore;
using OrderBackend.Models;
using OrderBackend.Repository;

var builder = WebApplication.CreateBuilder(args);

// Database options and setup
string connectionString = Environment.GetEnvironmentVariable("MS_SQL_CONNECTION_STRING") 
                          ?? throw new InvalidOperationException("MS_SQL_CONNECTION_STRING environment variable is required!");

DbContextOptions<OrderContext> options = new DbContextOptionsBuilder<OrderContext>()
    .UseSqlServer(connectionString, options =>
    {
        options.EnableRetryOnFailure(
            maxRetryCount: 10,
            maxRetryDelay: TimeSpan.FromSeconds(3),
            errorNumbersToAdd: new List<int>()
        );
    })
    .Options;

using var context = new OrderContext(options);
context.Database.EnsureCreated();

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddTransient<DbContextOptions<OrderContext>>(_ => options);


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