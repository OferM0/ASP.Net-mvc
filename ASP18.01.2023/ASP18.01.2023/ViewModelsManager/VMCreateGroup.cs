using ASP18._01._2023.Models;
using System.ComponentModel.DataAnnotations;

namespace ASP18._01._2023.ViewModelsManager
{
    public class VMCreateGroup
    {
        public VMCreateGroup() 
        {
            Group = new Group(); 
            Groups = new List<Group>(); 
            Item= new Item();
            Price= new Price();
        }

        //הצגת כל הקבוצות הקיימות שניתן להוסיף להן תת קבוצה
        public List<Group> Groups { get; set; }

        public Group Parent { get; set; }

        [Display(Name ="בחירת קבוצה")]
        public int ParentID { get; set; }

        public Group Group { get; set; }

        public Item Item { get; set; }
        
        //לפעמים יש מין בעיה שברגע ששולחים מעל 2 אובייקטים בטופס זה מתחיל להתבלבל
        public Price Price { get; set; }

        //public decimal ItemPrice { get; set; }

        [Display(Name = "הוספת תמונה")]
        public IFormFile File { get; set; }

        [Display(Name = "הוספת תמונה לפריט")]
        public IFormFile ItemFile { get; set; }
    }
}
