using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MKTListNet.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MKTListNetContextConn");

builder.Services.AddDbContext<MKTListNetContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<MKTListNetUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MKTListNetContext>();

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
});

builder.Services.AddPolicyConfiguration();

// AutoMapper Settings
builder.Services.AutoMapperConfiguration();

// .NET Native DI Abstraction
builder.Services.AddDependencyInjectionConfiguration();

builder.Services.AddMvc();

//bundling and minification of CSS and JavaScript
builder.Services.AddWebOptimizer();

builder.Services.Configure<IdentityOptions>(o =>
{
    o.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(3);
    o.Lockout.MaxFailedAccessAttempts = 5;
    o.SignIn.RequireConfirmedEmail = true;
});

builder.Services.ConfigureApplicationCookie(o =>
{
    o.Cookie.Name = "MKTListNet";
    o.Cookie.HttpOnly = true;
    o.SlidingExpiration = true;
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseStatusCodePagesWithRedirects("/Home/Error/{0}");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseWebOptimizer(); // Use middleware for bundling and minification of CSS and JavaScript files at runtime.

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

// Configure Routers
app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{Id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{Id?}");

app.MapRazorPages();

app.Run();
