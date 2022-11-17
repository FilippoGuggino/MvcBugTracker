using System.Diagnostics;
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

namespace mvc_bug_tracker.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private readonly IUserRepository _userService;
    private readonly IPersistService _cache;

    public HomeController(ILogger<HomeController> logger, IUserRepository userService, IPersistService cache)
    {
        _logger = logger;
        _userService = userService;
        _cache = cache;
    }

    public async Task<IActionResult> Index()
    {
        
        // var user = new UserLoginModel();
        // user.EmailAddress = "cacca.156";
        // user.Password = "Cacca.157";

        // Console.WriteLine("oaskdjasoi");

        // AuthResponseModel a = await _userService.TryLoginAsync(user);

        // Console.WriteLine(a.Message);
        // Console.WriteLine(a.IsSuccess);

        // HttpHelper.TestGet();
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
