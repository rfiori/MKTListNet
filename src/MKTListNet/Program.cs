using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MKTListNet.Configuration;
using MKTListNet.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("MKTListNetContextConn");

builder.Services.AddDbContext<MKTListNetContext>(options =>
    options.UseSqlite(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<MKTListNetUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<MKTListNetContext>();
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

builder.Services.AddControllersWithViews();
builder.Services.AddPolicyConfiguration();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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

// Configure Routers
app.MapControllerRoute(
      name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
