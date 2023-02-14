using ASP30._01._2023.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ASP30._01._2023.ViewModelsHome;
namespace ASP30._01._2023.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult LogIn(/*int? id*/)
        {
            //if (id == null) DataLayer.Data.GetUser = new Client { FirstName = "התחבר" };
            return View(new VMLogin());
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult LogIn(VMLogin login)
        {
            User user= DataLayer.Data.Users.FirstOrDefault(u=>u.Email==login.Client.Email && u.Password==login.Client.Password);
            if (user == null)
            {
                login.Feedback = "פרטים שגויים";
                login.Color = "red";
                return View(login);
            }
            DataLayer.Data.GetUser = user;
            if(user is Manager)
            {
                login.Feedback = "עופר המנהל";
                login.Color = "green";
                return View(login);
            }

            login.Feedback = "ישראל הספר";
            login.Color = "blue";
            return View(login);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Register(VMLogin login)
        {
            return View();
        }
        public IActionResult Index()
        {
            DataLayer dataLayer = DataLayer.Data;
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
}