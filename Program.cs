using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ITask7.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LocalConnectionString") ??
                       Environment.GetEnvironmentVariable("CONNECTION_STRING") ?? throw new Exception("connection string not found");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"] 
                           ?? Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID")!;
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] 
                               ?? Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET")!;
    })
    .AddFacebook(options =>
    {
        options.AppId = builder.Configuration["Authentication:Facebook:AppId"] 
                        ?? Environment.GetEnvironmentVariable("FACEBOOK_APP_ID")!;
        options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"] 
                            ?? Environment.GetEnvironmentVariable("FACEBOOK_APP_SECRET")!;
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

if (Environment.GetEnvironmentVariable("ENABLE_AUTO_MIGRATION") == "true")
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    db.Database.Migrate();
}

app.Run();