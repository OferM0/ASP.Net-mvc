using ASP30._01._2023.Models;
using ASP30._01._2023.ViewModelsManager;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace ASP30._01._2023.Controllers
{
    public class ManagerController : Controller
    {
        //public ManagerController(int id) { }

        //פונקציה המציגה את הספרים כולל אפשרות להוספת ספר
        public IActionResult Barbers()
        {
            List<User> users = DataLayer.Data.Users.ToList();
            VMIsActiveBarbers vm = new VMIsActiveBarbers(users);
            List<User> managers=users.FindAll(u => u is Manager);
            //List<Barber> allBarbers = vm.ActiveBarbers.Concat(vm.NotActiveBarbers).ToList();
            //List<Barber> barbers = DataLayer.Data.Users.OfType<Barber>().ToList();
            //List<Barber> barbers = DataLayer.Data.Users.ToList().FindAll(b => b.Active && b is Barber);
            //List<Barber> barbers = DataLayer.Data.Users.Where(user => user is Barber).Select(user => (Barber)user).ToList();
            return View(new VMBarbers
            {
                ActiveBarbers = vm.ActiveBarbers,
                NotActiveBarbers = vm.NotActiveBarbers,
                Users= managers,
            });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddBarber(VMBarbers VM)
        {
            if (VM == null) RedirectToAction("Barbers");

            if (VM.Barber.FirstName != null)
            {
                VM.Barber.SetImage = VM.File;
                DataLayer.Data.Users.Add(VM.Barber);
                DataLayer.Data.SaveChanges();
                return RedirectToAction("Barbers");
            }
            else
            {
                User user = DataLayer.Data.Users.OfType<Manager>().ToList().Find(h => h.Id == VM.SelectedUserId);
                //User user = VM.Users.FirstOrDefault(u => u.Id == VM.SelectedUserId);
                //User user = VM.User;
                //VM.Barber.Active = true;
                VM.Barber.FirstName = user.FirstName;
                VM.Barber.LastName = user.LastName;
                VM.Barber.PhoneNumber = user.PhoneNumber;
                VM.Barber.Password = user.Password;
                VM.Barber.Email = user.Email;
                VM.Barber.Description = "ספר מתחיל";
                DataLayer.Data.Users.Add(VM.Barber);
                DataLayer.Data.SaveChanges();
                return RedirectToAction("Barbers");
            }
        }

        public IActionResult ChangeActive(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            List<User> users = DataLayer.Data.Users.ToList();
            List<User> managers = users.FindAll(u => u is Manager);
            Barber barber = users.OfType<Barber>().ToList().Find(User => User.Id == id);

            if (barber == null) return RedirectToAction("Index");

            barber.Active = !barber.Active;
            DataLayer.Data.SaveChanges();

            VMIsActiveBarbers vm = new VMIsActiveBarbers(users);
            return View("Barbers", new VMBarbers
            {
                ActiveBarbers = vm.ActiveBarbers,
                NotActiveBarbers = vm.NotActiveBarbers,
                Users = managers,
            });
        }

        //פונקציה המציגה את התספורות כולל אפשרות להוספת סוג תספורת
        public IActionResult Haircuts()
        {
            List<Haircut> haircuts = DataLayer.Data.Haircuts.ToList();
            return View(new VMHaircuts { Haircuts=haircuts});
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddHaircut(VMHaircuts VM)
        {
            if(VM == null) RedirectToAction("Haircuts");
            VM.Haircut.SetImage = VM.File;
            DataLayer.Data.Haircuts.Add(VM.Haircut);
            DataLayer.Data.SaveChanges();
            return RedirectToAction("Haircuts");
        }

        public IActionResult Index(int? id)
        {
            if (id == null)
            {
                DataLayer.Data.GetUser = new Client { FirstName = "התחבר", };
                return RedirectToAction("Index", "Home");
                ;
            }
            User user = DataLayer.Data.Users.FirstOrDefault(u=>u.IdRandom== id);
            if (user != null)
                if (user is Manager)
                {
                    DataLayer.Data.GetUser = user;
                    user.Rnd = 0;
                    DataLayer.Data.SaveChanges();
                    return View();
                }
            DataLayer.Data.GetUser = new Client { FirstName = "התחבר", };
            return RedirectToAction("Index", "Home");
        }
    }
}
