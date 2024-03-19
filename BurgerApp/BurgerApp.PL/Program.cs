using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BurgerApp.PL.Data;
using BurgerApp.PL.Areas.Identity.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("BurgerAppContextConnection") ?? throw new InvalidOperationException("Connection string 'BurgerAppContextConnection' not found.");

builder.Services.AddDbContext<BurgerAppContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<BurgerAppUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<BurgerAppContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapRazorPages();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();