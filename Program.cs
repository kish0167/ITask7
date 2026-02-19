using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ITask7.Data;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LocalConnectionString") ??
                       Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                       throw new Exception("db connection string not found");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

builder.Services.AddAuthentication()
    .AddGoogle(options =>
    {
        options.ClientId = builder.Configuration["Authentication:Google:ClientId"] ?? 
                           Environment.GetEnvironmentVariable("GOOGLE_CLIENT_ID") ??
                           throw new Exception("google client id not found");
        options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"] ?? 
                               Environment.GetEnvironmentVariable("GOOGLE_CLIENT_SECRET") ??
                               throw new Exception("google client secret not found");
    })
    .AddFacebook(options =>
    {
        options.AppId = builder.Configuration["Authentication:Facebook:AppId"] ?? 
                        Environment.GetEnvironmentVariable("FACEBOOK_APP_ID") ??
                        throw new Exception("facebook client id not found");
        options.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"] ??
                            Environment.GetEnvironmentVariable("FACEBOOK_APP_SECRET") ??
                            throw new Exception("facebook client secret not found");
    });

var app = builder.Build();

app.UseForwardedHeaders();

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