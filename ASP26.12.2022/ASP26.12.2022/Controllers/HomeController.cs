using ASP26._12._2022.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Data.Entity;
using ASP26._12._2022.ViewsModels;

namespace ASP26._12._2022.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //הפונקצייה שעולה ראשונה
        public IActionResult Index()
        {
            //טעינת רשימת החברים ממסד הנתונים כולל תמונות שלהם
            List<Friend> friends = DataLayer.Data.Friends.Include(f=>f.Images).ToList();
            //if there is not seed-- friends list is empty
            if (friends.Count == 0) return RedirectToAction("Create"); //nameof(Create)
            return View(friends);
        }

        //פונקצייה ליצירת חבר חדש
        public IActionResult Create()
        {
            //שליחה לדף תצוגה של מודל מוכן המכיל גם חבר חדש וגם מקום לתמונה
            return View(new VMFriendWithImage());
        }

        //פונקציה המקבלת את הטופס המלא מהמשתמש
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(VMFriendWithImage VM)
        {
            //1. הוספת התמונה לחבר 
            VM.Friend.AddImage(VM.File);
            //2. הוספת החבר החדש לטבלת החברים
            DataLayer.Data.Friends.Add(VM.Friend);
            //3. שמירת הנתונים במסד נתונים
            DataLayer.Data.SaveChanges();
            //4. צריך להחליט האם עוברים מכאן לרשימה הכללית או לפרטי החבר הנוכחי שהוסף
            return RedirectToAction("Index"); //nameof(Index)="Index"
        }

        //פונקצייה להצגת פרטי חבר (detailes)
        public IActionResult Details(int? id)
        {
            //אם לא התקבל קוד חבר, שולח לדף הראשי
            if (id == null) return RedirectToAction("Index");
            //אם התקבל קוד חבר חיפוש החבר הראשון ברשימה עם הקוד הזה והחזרתו 
            Friend friend = DataLayer.Data.Friends.Include(f => f.Images).FirstOrDefault(f => f.ID == id); //DataLayer.Data.Friends.ToList().Find(f=>f.ID==id)
            //כל החברים שגרים בהרצליה
            //List<Friend> friends = DataLayer.Data.Friends.Include(f=>f.Images).ToList().FindAll(f => f.City == "הרצליה");
            //אם לא מצא את החבר
            if (friend == null) return RedirectToAction("Index");

            //VMFriendWithImage friendWithImage = new VMFriendWithImage();
            //friendWithImage.Friend = friend;
            return View(new VMFriendWithImage { Friend=friend});
        }

        //פונקצייה להוספת תמונה לחבר קיים במערכת
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddImage(VMFriendWithImage VM)
        {
            //בדיקה האם התקבל אובייקט, במידה ולא חוזרים לדף ראשי
            if (VM == null) return RedirectToAction("Index");
            //מציאת החבר במסד נתונים שהמשתמש רוצה להוסיף לו תמונה
            Friend friend = DataLayer.Data.Friends.Include(f => f.Images).FirstOrDefault(f => f.ID == VM.Friend.ID);
            //במידה ולא נמצא חבר חוזרים לדף ראשי
            if (friend == null) return RedirectToAction("Index");
            if (VM.File != null)
            {
                friend.AddImage(VM.File);
                DataLayer.Data.SaveChanges();
            }
            else
            {
                
            }
            return View("Details", new VMFriendWithImage { Friend = friend });
        }

        //פונקצייה לעריכת חבר קיים במערכת
        public IActionResult Edit(int? id)
        {
            //אם לא התקבל קוד חבר, שולח לדף הראשי
            if (id == null) return RedirectToAction("Index");
            //אם התקבל קוד חבר חיפוש החבר הראשון ברשימה עם הקוד הזה והחזרתו 
            Friend friend = DataLayer.Data.Friends.Include(f => f.Images).FirstOrDefault(f => f.ID == id);
            //אם לא מצא את החבר
            if (friend == null) return RedirectToAction("Index");
            return View(friend);
        }

        
        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Edit(Friend friend)
        {
            //בדיקה האם התקבל אובייקט, במידה ולא חוזרים לדף ראשי
            if (friend == null) return RedirectToAction("Index");
            //מציאת החבר במסד נתונים שהמשתמש רוצה להוסיף לו תמונה
            Friend friendDB = DataLayer.Data.Friends.FirstOrDefault(f => f.ID == friend.ID);
            //במידה ולא נמצא חבר חוזרים לדף ראשי
            if (friendDB == null) return RedirectToAction("Index");
            friendDB.FirstName = friend.FirstName;
            friendDB.LastName = friend.LastName;
            friendDB.Email = friend.Email;
            friendDB.Phone = friend.Phone;
            friendDB.City = friend.City;
            friendDB.Street = friend.Street;
            friendDB.Number = friend.Number;
            DataLayer.Data.SaveChanges();
            return View("Details", new VMFriendWithImage { Friend = friendDB });
        }

        public IActionResult DeleteImage(int id)
        {
            Image image = DataLayer.Data.Images.Include(i=>i.Friend).FirstOrDefault(i => i.ID == id);
            if(image == null) return RedirectToAction("Index");
            Friend friend = image.Friend;
            friend.Images.Remove(image);
            //DataLayer.Data.Images.Remove(image);
            DataLayer.Data.SaveChanges();
            return RedirectToAction("Details", new VMFriendWithImage { Friend = friend });
        }

        public IActionResult Delete(int id)
        {
            //אם התקבל קוד חבר חיפוש החבר הראשון ברשימה עם הקוד הזה והחזרתו 
            Friend friend = DataLayer.Data.Friends.Include(f => f.Images).FirstOrDefault(f => f.ID == id);
            if (friend == null) return RedirectToAction("Index");
            return View(friend);
            //DataLayer.Data.SaveChanges();
            //return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(Friend friend)
        {
            Friend friendDB = DataLayer.Data.Friends.Include(f => f.Images).FirstOrDefault(f => f.ID == friend.ID);
            if (friendDB == null) return RedirectToAction("Index");
            DataLayer.Data.Images.RemoveRange(friendDB.Images);
            DataLayer.Data.Friends.Remove(friendDB);
            DataLayer.Data.SaveChanges();
            return RedirectToAction("Index");
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