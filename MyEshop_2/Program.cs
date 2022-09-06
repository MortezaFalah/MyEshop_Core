using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using MyEshop_2.Data;
using MyEshop_2.Data.Repositories;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
//builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
//    .AddCookie(option =>
//    {
//        option.LoginPath = "/Account/login";
//        option.LogoutPath = "/Account/Logout";
//    });
#region Context
builder.Services.AddDbContext<MyEshopContext2>(
    options => options.UseSqlServer("Data Source=.; Initial Catalog=EshopCoredb2; Integrated Security=True")
    );
#endregion

#region IOC

builder.Services.AddScoped<IGroupRepository,GroupRepository>();
builder.Services.AddScoped<IUserRepository,UserRepository>();
#endregion

builder.Services.AddRazorPages();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(option =>
    {
        option.LoginPath = "/Account/Login";
        option.LogoutPath = "/Account/Logout";
        option.ExpireTimeSpan = TimeSpan.FromDays(10);
    }
    );
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

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.Use(async (context, next) =>
{
    if (context.Request.Path.StartsWithSegments("/Admin"))
    {

        if (!context.User.Identity.IsAuthenticated)
        {
            context.Response.Redirect("/Account/Login");
        }

        else if (!bool.Parse(context.User.FindFirstValue("isadmin")))
        {
            context.Response.Redirect("/Account/Login");
        }
    }
   
    await next.Invoke();
});
app.UseEndpoints(
    endpoints =>
    {
        endpoints.MapRazorPages();
    }
    );
 
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
