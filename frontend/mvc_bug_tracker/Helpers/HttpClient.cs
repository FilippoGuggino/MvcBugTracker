using mvc_bug_tracker.Models;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace mvc_bug_tracker.Helpers;

static class HttpHelper
{

    static public HttpClientHandler clientHandler;
    

    static public HttpClient client = new HttpClient();

    static HttpHelper()
    {
         clientHandler = new HttpClientHandler();
         clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
         client = new HttpClient(clientHandler);
    }

    static void ShowBug(Bug bug)
    {
        Console.WriteLine(bug.Title);
    }

    static async Task<Uri> CreateBugAsync(Bug bug)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync(
                "api/Bugs", bug);
            Console.WriteLine(response.ToString());
            response.EnsureSuccessStatusCode();

            // return URI of the created resource.
            return response.Headers.Location;
        }


    static async Task<Bug> GetBugAsync(string path)
    {
        Bug bug = null;
        HttpResponseMessage response = await client.GetAsync(path);
        if (response.IsSuccessStatusCode)
        {
            bug = await response.Content.ReadFromJsonAsync<Bug>();
        }
        return bug;
    }

    static public async void TestGet()
    {
        HttpHelper.client.BaseAddress = new Uri("https://localhost:7110/");
        HttpHelper.client.DefaultRequestHeaders.Accept.Clear();
        HttpHelper.client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        try
        {
            Console.WriteLine("inizio");
            Bug bug = new Bug
            {
                Id = "636f72b6a8752768b6e302d1",
                Title = "proviamo",
                Severity = 34
            };

            var url = await CreateBugAsync(bug);
            Console.WriteLine($"Created at {url}");

            
            bug = await GetBugAsync(url.PathAndQuery);
            ShowBug(bug);
            
        } catch(Exception e){
            Console.WriteLine(e.Message);
        }
    }

    // static async Task RunAsync()
    // {
    //     // Update port # in the following line.
    //     client.BaseAddress = new Uri("http://localhost:64195/");
    //     client.DefaultRequestHeaders.Accept.Clear();
    //     client.DefaultRequestHeaders.Accept.Add(
    //         new MediaTypeWithQualityHeaderValue("application/json"));

    //     try
    //     {
    //         // Create a new product
    //         Bug product = new Bug
    //         {
    //             Id = "636f72b6a8752768b6e304dc",
    //             Title = "Gizmo",
    //             Severity = 100,
    //         };

    //         var url = await CreateBugAsync(product);
    //         Console.WriteLine($"Created at {url}");

    //         // Get the product
    //         product = await GetBugAsync(url.PathAndQuery);
    //         ShowBug(product);

    //         // Update the product
    //         Console.WriteLine("Updating price...");
    //         product.Price = 80;
    //         await UpdateBugAsync(product);

    //         // Get the updated product
    //         product = await GetBugAsync(url.PathAndQuery);
    //         ShowBug(product);

    //         // Delete the product
    //         var statusCode = await DeleteBugAsync(product.Id);
    //         Console.WriteLine($"Deleted (HTTP Status = {(int)statusCode})");

    //     }
    //     catch (Exception e)
    //     {
    //         Console.WriteLine(e.Message);
    //     }

    //     Console.ReadLine();
    // }

}