using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ITask7.Data;
using ITask7.Localization;
using ITask7.Models.Users;
using ITask7.RealTimeChat;
using ITask7.Services;
using ITask7.Services.DbApi.AccessControl;
using ITask7.Services.DbApi.Chat;
using ITask7.Services.DbApi.Fields;
using ITask7.Services.DbApi.FieldValues;
using ITask7.Services.DbApi.Inventories;
using ITask7.Services.DbApi.Items;
using ITask7.Services.DbApi.Users;
using ITask7.Services.Integrations.SalesForce;
using ITask7.Services.Users;
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
builder.Services.AddScoped<IChatService,ChatService>();
builder.Services.AddScoped<IInventoryRepository, InventoryRepository>();
builder.Services.AddScoped<IItemRepository, ItemRepository>();
builder.Services.AddScoped<IFieldRepository, FieldRepository>();
builder.Services.AddScoped<IItemFieldValueRepository, ItemFieldValueRepository>();
builder.Services.AddScoped<IItemService, ItemService>();
builder.Services.AddScoped<IFieldService, FieldService>();
builder.Services.AddScoped<IInventoryService, InventoryService>();
builder.Services.AddScoped<IAccessControlService, AccessControlService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ISalesForceIntegrationService, SalesForceIntegrationService>();
builder.Services.Configure<SalesForceOptions>(options =>
{
    options.ClientId = builder.Configuration["Integrations:SalesForceId"] ?? 
                       Environment.GetEnvironmentVariable("SALESFORCE_CLIENT_ID") ??
                       throw new Exception("salesforce client id not found");
    options.ClientSecret = builder.Configuration["Integrations:SalesForceSecret"] ?? 
                           Environment.GetEnvironmentVariable("SALESFORCE_CLIENT_SECRET") ??
                           throw new Exception("salesforce client secret not found");
    options.BaseUrl = builder.Configuration["Integrations:SalesForceBaseUrl"] ?? 
                      Environment.GetEnvironmentVariable("SALESFORCE_BASE_URL") ??
                      throw new Exception("salesforce base url not found");;
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