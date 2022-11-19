using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

using mvc_bug_tracker.Models;
using mvc_bug_tracker.Core.Services;

using mvc_bug_tracker.Core;
using mvc_bug_tracker.Core.Repositories;
using mvc_bug_tracker.Contracts;
using mvc_bug_tracker.Contracts.Repositories;
using mvc_bug_tracker.Contracts.Services;
using mvc_bug_tracker.Core.Services;

var builder = WebApplication.CreateBuilder(args);

// builder.Services.Configure<CookiePolicyOptions>(options =>
//             {
//                 // This lambda determines whether user consent for non-essential cookies is needed for a given request.
//                 options.CheckConsentNeeded = context => false;
//                 options.MinimumSameSitePolicy = SameSiteMode.None;
//             });
// builder.Services.AddMemoryCache();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<AWS>(builder.Configuration.GetSection("AWS"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<UserContextManager>();
builder.Services.AddScoped<IPersistService, CacheService>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
// builder.Services.AddSingleton<ITokenAcquisition, TokenAcquisition>();

builder.Services.AddHttpContextAccessor();

builder.Services.AddCognitoIdentity();
// builder.Services.AddAuthentication(options =>
//     {
//         options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//         options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
//         options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
//     })
//     .AddCookie()
//     .AddOpenIdConnect(options =>
//     {
//         options.ResponseType = "code";
//         options.MetadataAddress = "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_1e2Ps2DP4/.well-known/openid-configuration";
//         options.ClientId = builder.Configuration["AWS:AppClientId"];
//         options.SaveTokens = true;
//     });
//     // {
//     //     options.LoginPath = "/User/Login";
//     //     options.LogoutPath = "/User/Logout";
//     //     options.ReturnUrlParameter = "";
//     // });

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
	options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
.AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options => {
    options.LoginPath = "/User/Login";
    options.LogoutPath = "/User/Logout";
    options.ReturnUrlParameter = "";
    options.AccessDeniedPath = "/Home";
});
// .AddOpenIdConnect(options =>
// {
//    options.ResponseType = "code";
//    options.MetadataAddress = "https://cognito-idp.us-east-1.amazonaws.com/us-east-1_1e2Ps2DP4/.well-known/openid-configuration";
//    options.ClientId = builder.Configuration["AWS:AppClientId"];
//    options.SaveTokens = true;
// });

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
