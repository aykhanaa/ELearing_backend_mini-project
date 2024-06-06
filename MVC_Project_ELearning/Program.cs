
using Microsoft.EntityFrameworkCore;
using MVC_Project_ELearning.Data;
using MVC_Project_ELearning.Services.Interfaces;
using MVC_Project_ELearning.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

builder.Services.AddScoped<ISliderService, SliderService>();




var app = builder.Build();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();


app.UseAuthorization();

app.MapControllerRoute(
   name: "areas",
   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
