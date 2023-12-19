using ICareAboutClimate.DataAccess;
using ICareAboutClimateBE.Services;
using Microsoft.Extensions.Logging.ApplicationInsights;
using Microsoft.EntityFrameworkCore;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var connection = String.Empty;
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddEnvironmentVariables().AddJsonFile("appsettings.Development.json");
    connection = builder.Configuration.GetConnectionString("WebApiDatabase");
}
else
{
    connection = Environment.GetEnvironmentVariable("SQLCONNSTR_WebApiDatabase");
}

builder.Services.AddDbContext<ClimateContext>(options =>
    options.UseSqlServer(connection));

// builder.Services.AddDbContext<ClimateContext>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("CORSPolicy",
        builder =>
        {
            builder
            .AllowAnyMethod()
            .AllowAnyHeader()
            .WithOrigins("https://localhost:44440");
        });
});

builder.Services.AddScoped<IFormServices, FormServices>();

builder.Logging.AddApplicationInsights(
        configureTelemetryConfiguration: (config) => 
            config.ConnectionString = builder.Configuration.GetConnectionString("APPLICATIONINSIGHTS_CONNECTION_STRING"),
            configureApplicationInsightsLoggerOptions: (options) => { }
    );

builder.Services.AddApplicationInsightsTelemetry();

var app = builder.Build();

app.Logger.LogInformation("Initiating logging! {}", connection);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseCors("CORSPolicy");
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

