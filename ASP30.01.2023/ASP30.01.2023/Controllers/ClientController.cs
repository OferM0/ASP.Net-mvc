using ASP30._01._2023.Models;
using ASP30._01._2023.ViewModelsManager;
using Microsoft.AspNetCore.Mvc;

namespace ASP30._01._2023.Controllers
{
    public class ClientController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //פונקציה המציגה את הספרים וכניסה לתורים שלהם
        public IActionResult Barbers()
        {
            List<Barber> barbers = DataLayer.Data.Users.OfType<Barber>().ToList().FindAll(b => b.Active); ;
            return View(barbers);
        }

        public IActionResult Appointments(int? id)
        {
            Barber barber = DataLayer.Data.getBarbersAllIncludes.FirstOrDefault(b => b.Id == id && b.Active);
            if (barber == null) return RedirectToAction("Index", "Home");
            List<Appointment> appointments = barber.Appointments.ToList();
            return View(appointments);
        }

    }
}
//בדף הקלנדר אפשרות לשנות כמה ימים קדימה הספר רואה- הדף יתרנדר כל פעם מחדש

//בחירת ספר
//בחירת פעולה
//בחירת תאריך
//בחירת תור ספציפי, תשלום וקבלת התור וקבלה במייל