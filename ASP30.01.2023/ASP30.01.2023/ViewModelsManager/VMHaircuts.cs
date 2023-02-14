using ASP30._01._2023.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP30._01._2023.ViewModelsManager
{
    public class VMHaircuts
    {
        public VMHaircuts() 
        { 
            Haircuts = new List<Haircut>(); 
            Haircut = new Haircut();
        }
        public List<Haircut> Haircuts { get; set; } 
        public Haircut Haircut { get; set; }

        [Display(Name = "הוספת תמונה")]
        public IFormFile File { get; set; }
    }
}
