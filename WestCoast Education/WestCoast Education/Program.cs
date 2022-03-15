using Microsoft.AspNetCore.Mvc;
using WestCoast_Education.DAL;
using WestCoast_Education.DAL.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<WCEStorage>();
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
app.UseAuthorization();
app.MapControllers();

app.Run();
