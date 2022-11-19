using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvc_bug_tracker.Models;
using mvc_bug_tracker.Helpers;
using Amazon.Extensions.CognitoAuthentication;


using mvc_bug_tracker.Contracts.DTO;
using mvc_bug_tracker.Contracts;
using mvc_bug_tracker.Core.Services;
using mvc_bug_tracker.Core.Repositories;
using mvc_bug_tracker.Contracts.Repositories;
using mvc_bug_tracker.Contracts.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;

namespace mvc_bug_tracker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IUserRepository _userService;
    private readonly IPersistService _cache;

    private readonly HttpContext _httpContext;

    public HomeController(ILogger<HomeController> logger, IUserRepository userService, IPersistService cache, IHttpContextAccessor httpContext)
    {
        _logger = logger;
        _userService = userService;
        _cache = cache;
        _httpContext = httpContext.HttpContext;
    }

    // [ValidateAntiForgeryToken]
    [AllowAnonymous]
    public async Task<IActionResult> Index()
    {  
        // var user = new UserLoginModel();
        // user.EmailAddress = "cacca.156";
        // user.Password = "Cacca.157";

        // AuthResponseModel a = await _userService.TryLoginAsync(user);

        // Console.WriteLine(a.Tokens.AccessToken);
        // Console.WriteLine(a.IsSuccess);
        //  var logout = new UserSignOutModel();
        // logout.AccessToken = await _httpContext.GetTokenAsync("access_token");
        // logout.UserId = User.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).First().Value;

        // await _userService.TryLogOutAsync();
        // Console.WriteLine(HttpContext.GetTokenAsync("access_token").ToString());
        // foreach(var s in HttpContext.)
        // Console.WriteLine(s);


      

        // await _userService.TryLogOutAsync(logout);
        
        // Console.WriteLine(_httpContext.Request.Headers);
        // string s = await _httpContext.GetTokenAsync(IdentityConstants.ExternalScheme, "access_token");
        // Console.WriteLine(s);
        // Console.WriteLine(_httpContext.Request.Headers["Authorization"]);
        
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
