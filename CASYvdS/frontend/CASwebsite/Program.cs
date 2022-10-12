using CASwebsite.Agents;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

string baseUrl = Environment.GetEnvironmentVariable("API_BASE_URL")
                 ?? throw new InvalidOperationException("API_BASE_URL environment variable is required!");;
builder.Services.AddSingleton<ICursusAgent>(new CursusAgent(baseUrl));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Cursus}/{action=Base}");

app.Run();