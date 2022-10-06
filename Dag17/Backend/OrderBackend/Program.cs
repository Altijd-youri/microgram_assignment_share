using Microsoft.EntityFrameworkCore;
using OrderBackend.Models;
using OrderBackend.Repository;

var builder = WebApplication.CreateBuilder(args);

string connectionString = Environment.GetEnvironmentVariable("MS_SQL_CONNECTION_STRING") 
                          ?? throw new InvalidOperationException("MS_SQL_CONNECTION_STRING environment variable is required!");

DbContextOptions<OrderContext> options = new DbContextOptionsBuilder<OrderContext>()
    .UseSqlServer(connectionString)
    .Options;

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