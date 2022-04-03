using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WestCoast_Education.DAL;
using WestCoast_Education.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Injects WCEContext to the builder, and supplies the connectionstring
builder.Services.AddDbContext<WCEContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("WCEDbConnectionsString"));
});

builder.Services.AddRazorPages();
builder.Services.AddScoped<WCEStorage>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseStaticFiles();
app.UseAuthorization();
app.MapRazorPages();
app.MapControllers();

app.Run();
