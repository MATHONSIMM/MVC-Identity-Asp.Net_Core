using Mapping_List.Areas.Identity.Data;
using Mapping_List.Data;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("Mapping_ListContextConnection") ?? throw new InvalidOperationException("Connection string 'Mapping_ListContextConnection' not found.");

builder.Services.AddDbContext<Mapping_ListContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<Mapping_ListUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<Mapping_ListContext>();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

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

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
