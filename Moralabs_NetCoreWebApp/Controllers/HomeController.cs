using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moralabs_NetCoreWebApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Moralabs_NetCoreWebApp.Controllers
{
    public class HomeController : Controller //Proje başladığında burdaki index actionu arar.
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
            string mesaj = Request.Query["mesaj"]; //indexte gönderdiğimiz mesajı burda yakaladık.
            ViewBag.Mesaj = mesaj; //Dinamik bir tür, key value çalışır. 
            ViewData["Mesaj2"] = mesaj; //Bu da aynı işi yapıyor
            TempData["Mesaj3"] = mesaj; // Bu da aynı işi yapıyor //TempData actiondan actiona yönlendirme yaparken değer kaybolmuyor.
            return RedirectToAction("About"); //Privacy tıklandığında About Actionunu döndürüyor. //Sadece TempData görünür.
            //return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
