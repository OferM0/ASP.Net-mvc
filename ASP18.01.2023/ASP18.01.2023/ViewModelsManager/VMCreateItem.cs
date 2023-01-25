using ASP18._01._2023.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP18._01._2023.ViewModelsManager
{
    public class VMCreateItem
    {
        public VMCreateItem()
        {
            Group = new Group();
            Groups = new List<Group>();
            Item = new Item();
            Price = new Price();
        }

        public List<Group> Groups { get; set; }

        [Display(Name = "בחירת קבוצה")]
        public int GroupID { get; set; }

        public Group Group { get; set; }

        public Item Item { get; set; }

        [Display(Name = "הוספת מחיר")]
        public Price Price { get; set; }

        [Display(Name = "הוספת תמונה לפריט")]
        public IFormFile ItemFile { get; set; }
    }
}
