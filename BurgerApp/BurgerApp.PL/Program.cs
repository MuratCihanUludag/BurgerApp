using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BurgerApp.PL.Data;
using BurgerApp.PL.Areas.Identity.Data;
using BurgerApp.PL.Areas.Admin.Profiles;
using BurgerApp.PL.Areas.Identity.Pages.EmailSender.YourProject.Services;
using Microsoft.AspNetCore.Identity.UI.Services;

var builder = WebApplication.CreateBuilder(args);


var connectionString = builder.Configuration.GetConnectionString("BurgerAppContextConnectionKutay") ?? throw new InvalidOperationException("Connection string 'BurgerAppContextConnection' not found.");

builder.Services.AddTransient<IEmailSender, EmailSenderManager>();


builder.Services.AddDbContext<BurgerAppContext>(options =>

{ options.UseLazyLoadingProxies(); options.UseSqlServer(connectionString); });


builder.Services.AddDefaultIdentity<BurgerAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole<string>>()
                .AddEntityFrameworkStores<BurgerAppContext>();


builder.Services.AddAutoMapper(builder => builder.AddProfile<GeneralProfile>());


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

app.UseAuthentication();

app.UseAuthorization();


app.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
