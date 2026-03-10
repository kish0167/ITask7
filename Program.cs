using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ITask7.Data;
using ITask7.Localization;
using ITask7.RealTimeChat;
using ITask7.Services;
using ITask7.Services.Chat;
using ITask7.Services.Users;
using ITask7.Users;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("LocalConnectionString") ??
                       Environment.GetEnvironmentVariable("CONNECTION_STRING") ??
                       throw new Exception("db connection string not found");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddSignalR();

builder.Services.AddDefaultIdentity<ApplicationUser>(
        options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.SignIn.RequireConfirmedEmail = false;
        })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddSignInManager<SignInManager<ApplicationUser>>();
builder.Services.AddScoped<IUserStore<ApplicationUser>, AdminAssigningUserStore>();

builder.Services.AddControllersWithViews().
    AddViewLocalization();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;
});

builder.Services.AddLocalization(options =>  options.ResourcesPath = "Resources");

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.SetDefaultCulture(Languages.Default)
        .AddSupportedCultures(Languages.All.ToArray())
        .AddSupportedUICultures(Languages.All.ToArray());
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

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Lax;
});

builder.Services.AddScoped<DbApiService>();
builder.Services.AddScoped<ChatService>();
builder.Services.AddScoped<ViewModelsConverter>();

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

app.UseRequestLocalization();

app.UseRouting();

app.UseAuthentication();
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

app.MapHub<ChatHub>("/ChatHub");

app.Run();