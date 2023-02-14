using ASP30._01._2023.Models;
using ASP30._01._2023.Services;
using ASP30._01._2023.ViewModelsBarber;
using ASP30._01._2023.ViewModelsManager;
using Microsoft.AspNetCore.Mvc;
using System.Threading;

namespace ASP30._01._2023.Controllers
{
    public class BarberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //פונקציה המציגה את פעולות הספר כולל אפשרות להוספת פעולה
        public IActionResult HaircutPlan()
        {
            List<Haircut> haircuts = DataLayer.Data.Haircuts.ToList();
            Barber barber = (Barber)DataLayer.Data.GetUser;
            List<HaircutPerBarber> haircutOfBarber = DataLayer.Data.HaircutPerBarber.ToList().FindAll (h=>h.Barber.Id== barber.Id);
            return View(new VMAddHaircut
            {
                Haircuts = haircuts,
                HaircutsOfBarber= haircutOfBarber,
                Barber = barber,
                BarberID = barber.Id,
            });
        }

        //להסתכל בסרטון ולנסות לעשות בלי טעינות נוספות
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddToHaircutPlan(VMAddHaircut VM)
        {
            if (VM == null) RedirectToAction("HaircutPlan");
            VM.HaircutPerBarber.Haircut = DataLayer.Data.Haircuts.ToList().Find(h=>h.Id== VM.HaircutID);
            VM.HaircutPerBarber.Barber = DataLayer.Data.Users.OfType<Barber>().ToList().Find(u => u.Id == VM.BarberID);
            DataLayer.Data.HaircutPerBarber.Add(VM.HaircutPerBarber);
            DataLayer.Data.SaveChanges();
            return RedirectToAction("HaircutPlan");
        }

        //פונקציה של הוספת תכנית תאריכית
        public IActionResult AddProgram(int? id)
        {
            if (id == null) return RedirectToAction("Index", "Home");
            User user = DataLayer.Data.Users.ToList().Find(u=>u.Rnd==id);
            if (user == null) return RedirectToAction("Index", "Home");
            user.Rnd = 0;
            DataLayer.Data.SaveChanges();
            DataLayer.Data.GetUser = user;
            VMAddMonthlyProgram VM = new VMAddMonthlyProgram 
            {
                Barber=(Barber)user,
                BarberID=user.Rnd,
            };
            return View(VM);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddProgram(VMAddMonthlyProgram VM)
        {
            if(VM==null) return RedirectToAction("Index", "Home");
            new BarberServices { VM = VM}.PlanProgram();
            DataLayer.Data.SaveChanges();          
            return RedirectToAction("Calender", new { id = VM.BarberID });
        }

        public IActionResult Calender(int? id/*, VMCalender VM*/, int daysForward)
        {
            //if(VM!=null) { return View(VM); }
            Barber barber = DataLayer.Data.getBarbersAllIncludes.Find(u=>u.Id == id);
            if(barber==null) return RedirectToAction("Index", "Home");
            if(barber.Appointments.Count==0) return RedirectToAction("Index", "Home");
            if (daysForward == 0) { daysForward = 7; }
            return View(new VMCalender { DaysForweard=daysForward, Appointments=barber.Appointments });
        }

        //[HttpPost]
        //public IActionResult Calender(int? id, VMCalender VM)
        //{
        //    Barber barber = DataLayer.Data.getBarbersAllIncludes.Find(u => u.Id == id);
        //    if (barber == null) return RedirectToAction("Index", "Home");
        //    if (barber.Appointments.Count == 0) return RedirectToAction("Index", "Home");
        //    if (VM.DaysForweard == null) { VM.DaysForweard = 7; }
        //    VM.Appointments = barber.Appointments;
        //    return View(VM);
        //}
    }
}
