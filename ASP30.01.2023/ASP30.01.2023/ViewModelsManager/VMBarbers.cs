using ASP30._01._2023.Models;
using System.ComponentModel.DataAnnotations;

namespace ASP30._01._2023.ViewModelsManager
{
    public class VMBarbers
    {
        public VMBarbers()
        {
            ActiveBarbers = new List<Barber>();
            NotActiveBarbers = new List<Barber>();
            Barber = new Barber();
        }
        public List<Barber> ActiveBarbers { get; set; }
        public List<Barber> NotActiveBarbers { get; set; }
        public List<User> Users { get; set; }
        public User User { get; set; }

        [Display(Name = "בחירת משתמש")]
        public int SelectedUserId { get; set; }
        public Barber Barber { get; set; }

        [Display(Name="הוספת תמונה")]
        public IFormFile File { get; set; }
    }
}
