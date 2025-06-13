using Microsoft.EntityFrameworkCore;
using SkyProject.Data;
using SkyProject.Interfaces;
using SkyProject.Services;
using SkyProject.Utils;

var builder = WebApplication.CreateBuilder(args);

GlobalizationUtils.ConfigureCurrentCulture();

// Add services to the container.
builder.Services.AddRazorPages();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? throw new InvalidOperationException("Connection string not found");

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite(connectionString)); //(options => options.UseSqlite(@"Data Source=C:\\Users\\Daniel\\Disertatie\\Projects\\webApp\\Skyproject\\skyproject.db"));

builder.Services.AddScoped<IEmployeeService, EmployeeService>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
