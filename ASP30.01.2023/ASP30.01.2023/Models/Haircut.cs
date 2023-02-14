using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace ASP30._01._2023.Models
{
    public class Haircut
    {
        public Haircut() { HaircutPerBarbers = new List<HaircutPerBarber>(); }

        [Key]
        public int Id { get; set; }

        [Display(Name ="סוג תספורת")]
        public string Name { get; set; }

        [Display(Name = "תיאור")]
        public string Description { get; set; }

        [Display(Name = "תמונה")]
        public byte[] Image { get; set; }
 
        //רשימת כל הספרים שעושים פעולה מסוימת
        public List<HaircutPerBarber> HaircutPerBarbers { get; set; }

        //פונקצייה של הכנסת תמונה
        public IFormFile SetImage
        {
            set{ Image = new SetImage(value).Image; }
        }
    }
}
