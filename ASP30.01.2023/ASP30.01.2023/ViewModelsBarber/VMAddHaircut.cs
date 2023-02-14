using ASP30._01._2023.Models;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP30._01._2023.ViewModelsBarber
{
    public class VMAddHaircut
    {
        public VMAddHaircut()
        {
            HaircutsOfBarber = new List<HaircutPerBarber>();
            HaircutPerBarber = new HaircutPerBarber();
            Barber = new Barber();
            Haircuts = new List<Haircut>();
        }
        public List<HaircutPerBarber> HaircutsOfBarber { get; set; }

        [Display(Name = "בחר פעולה")]
        public List<Haircut> Haircuts { get; set; }
        public HaircutPerBarber HaircutPerBarber { get; set; }
        //public Haircut Haircut { get; set; }
        public int HaircutID { get; set; }
        public int BarberID { get; set; }
        public Barber Barber { get; set; }
    }
}
