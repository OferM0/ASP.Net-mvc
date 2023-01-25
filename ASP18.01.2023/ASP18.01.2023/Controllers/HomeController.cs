using ASP18._01._2023.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.Entity;
 
namespace ASP18._01._2023.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int? id)
        {
            //טעינת רשימת קטגוריות ממסד הנתונים כולל תתי קטגוריות ופריטים שלהם
            Group group = DataLayer.Data.Groups.Include(g => g.SubGroups).Include(g => g.Items).ToList().First();
            List<Item> items = group.AllItems;
            return View(items);
        }

        public IActionResult test()
        {
            return View(new Price());
        }

        [HttpPost]
        public IActionResult test(Price price)
        {
            return View(price);
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