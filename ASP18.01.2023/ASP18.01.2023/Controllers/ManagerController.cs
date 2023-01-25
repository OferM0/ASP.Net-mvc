using ASP18._01._2023.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data.Entity;
using ASP18._01._2023.ViewModelsManager;

namespace ASP18._01._2023.Controllers
{
    public class ManagerController : Controller
    {
        //הצגה של הקבוצות והפריטים של כל קבוצה
        public IActionResult Index(int? id)
        {
            if (id != null)
            {
                Group group1 = DataLayer.Data.GroupsWithAllIncludes.Find(g=>g.ID==id);
                if(group1!=null) return View(group1);
            }
            Group group = DataLayer.Data.GroupsWithAllIncludes.First();
            return View(group);
        }

        //הוספת קבוצה
        public IActionResult Create(int? id)
        {
            List<Group> groups = DataLayer.Data.Groups.ToList();

            if (id != null)
            {
                Group parent = groups.Find(g => g.ID == id);
                if (parent != null) return View(new VMCreateGroup { Groups = groups, Parent = parent, ParentID = id.Value });
            }
            return View(new VMCreateGroup { Groups = groups, Parent = groups.First(), ParentID = groups.First().ID });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Create(VMCreateGroup VM)
        {
            Group parent = DataLayer.Data.Groups.FirstOrDefault(g=>g.ID==VM.ParentID);
            if (parent != null)
            { 
                //הוספת קבוצה חדשה להורה
                parent.AddSubGroup(VM.Group);
                //הוספת תמונה לקבוצה החדשה
                VM.Group.SetImage = VM.File;

                if(VM.Item.Name!=null)
                {
					VM.Group.AddItem(VM.Item);
                    VM.Item.AddImage(VM.ItemFile);
                    VM.Item.AddPrice(VM.Price);
                }               
                DataLayer.Data.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //פונקצייה להוספת פריט
        public IActionResult AddItem(int? id)
        {
            List<Group> groups = DataLayer.Data.Groups.ToList();

            if (id != null)
            {
                Group group = groups.Find(g => g.ID == id);
                if (group != null) return View(new VMCreateItem { Groups = groups, Group = group, GroupID = id.Value });
            }
            return View(new VMCreateItem { Groups = groups, Group = groups.First(), GroupID = groups.First().ID });
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult AddItem(VMCreateItem VM)
        {
            Group group = DataLayer.Data.Groups.FirstOrDefault(g => g.ID == VM.GroupID);
            if (group != null)
            {
                if (VM.Item.Name != null)
                {
                    group.AddItem(VM.Item);
                    //VM.Group.AddItem(VM.Item);
                    VM.Item.AddImage(VM.ItemFile);
                    VM.Item.AddPrice(VM.Price);
                }
                DataLayer.Data.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        //פונקצייה להצגת פרטי פריט
        public IActionResult ItemDetails(int? id)
        {
            //אם לא התקבל קוד פריט, שולח לדף הראשי
            if (id == null) return RedirectToAction("Index");
            //אם התקבל קוד פריט חיפוש הפריט הראשון ברשימה עם הקוד הזה והחזרתו 
            Item item = DataLayer.Data.Items.Include(i => i.Images).Include(i => i.Prices).Include(i => i.Group).FirstOrDefault(i => i.ID == id); //DataLayer.Data.Friends.ToList().Find(f=>f.ID==id)
            //אם לא מצא את החבר
            if (item == null) return RedirectToAction("Index");

            return View(item);
        }
    }
}