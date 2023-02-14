using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP30._01._2023.Models
{
    public class HaircutPerBarber
    {
        public HaircutPerBarber() { }

        [Key]
        public int Id { get; set; }

        public Barber Barber{ get; set; }

        public Haircut Haircut { get; set; }

        [Display(Name = "מחיר")]
        public int Price { get; set; }

        [Display(Name = "זמן בדקות")]
        public int Duration { get; set; }
        
        [Display(Name = "כמות מכל הפעולות")]
        public int PrecentFromAllHaircuts { get; set; }
    }
}