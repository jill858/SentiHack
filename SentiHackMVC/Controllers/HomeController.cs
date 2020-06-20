using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestSharp;
using SentiHackMVC.Models;

namespace SentiHackMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
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
        public IActionResult Upload()
        {
           
            return View();
        }
       
         [HttpPost]
         public IActionResult Upload(HttpPostedFileBase file)
         {
             var client = new RestClient("https://apis.sentient.io/microservices/utility/csvtojson/v1.0/getresults");
             client.Timeout = -1;
             var request = new RestRequest(Method.POST);
             request.AddHeader("x-api-key", "C0DD235378A94213B9BF");
             request.AddHeader("Content-Type", "text/csv");
             request.AddParameter("text/csv", "<file contents here>", ParameterType.RequestBody);
             IRestResponse response = client.Execute(request);
             Console.WriteLine(response.Content);
             return View();
         }
        
    }
}
