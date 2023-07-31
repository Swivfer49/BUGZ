using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BUGZ.LAYER_DATACCESS;
using BUGZ.LAYER_DOMAN;
using Microsoft.AspNetCore.Authorization;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'AppDBContextConnection' not found.");

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<AppDBContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
});

#region ale

// Authorization handlers.
builder.Services.AddScoped<IAuthorizationHandler,
                      AbminAuthorizationHandler>();

builder.Services.AddScoped<IAuthorizationHandler,
                      PMTicketAuthorizationHandler>();

builder.Services.AddScoped<IAuthorizationHandler,
                      PMUserAuthorizationHandler>();

builder.Services.AddScoped<IAuthorizationHandler,
                      DeveloperTicketAuthorizationHandler>();

builder.Services.AddScoped<IAuthorizationHandler,
                      DeveloperProjectAuthorizationHandler>();

builder.Services.AddScoped<IAuthorizationHandler,
                      SubTicketAuthorizationHandler>();

builder.Services.AddScoped<IAuthorizationHandler,
                      SubProjectAuthorizationHandler>();

builder.Services.AddScoped<IAuthorizationHandler,
                      AverageAttachmentAuthorizationHandler>();

builder.Services.AddScoped<IAuthorizationHandler,
                      AverageCommentAuthorizationHandler>();
#endregion

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDBContext>();
    context.Database.Migrate();
    // requires using Microsoft.Extensions.Configuration;
    // Set password with the Secret Manager tool.
    // dotnet user-secrets set SeedUserPW <pw>

    var testUserPw = builder.Configuration.GetValue<string>("SeedUserPW");

    await Seedata.Initialize(services, testUserPw);
}

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
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
