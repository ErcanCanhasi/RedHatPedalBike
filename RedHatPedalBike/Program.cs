using Microsoft.EntityFrameworkCore;
using RedHatPedalBike.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using RedHatPedalBike.Controllers;
using Microsoft.Extensions.Configuration; // Add this for configuration

var builder = WebApplication.CreateBuilder(args);

// Add User Secrets in Development Environment
if (builder.Environment.IsDevelopment())
{
    builder.Configuration.AddUserSecrets<Program>();
}

// This will include appsettings.json, appsettings.{Environment}.json, user secrets (in Development), environment variables, and command-line arguments
var configuration = builder.Configuration;

var username = configuration["postgres-username"];
var password = configuration["postgres-password"];

// Optional: Debugging lines to check if the variables are being read correctly
Console.WriteLine($"Username: {username ?? "not found"}");
Console.WriteLine($"Password: {password ?? "not found"}");

// Replace placeholders in the connection string with actual environment variables
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    .Replace("{USERNAME}", username)
    .Replace("{PASSWORD}", password);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddDbContext<BikedbContext>(options =>
    options.UseNpgsql(connectionString));

// Add services to the container.
builder.Services.AddHealthChecks()
    .AddNpgSql(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Other configurations...

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    // Map health checks endpoint
    endpoints.MapHealthChecks("/health");
});

// Other app configurations like app.UseAuthorization(), etc.

// Configure the HTTP request pipeline.
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
