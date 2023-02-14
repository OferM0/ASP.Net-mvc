using ASP30._01._2023.Models;

namespace ASP30._01._2023.ViewModelsManager
{
    public class VMIsActiveBarbers
    {
        public VMIsActiveBarbers(List<User> barbers)
        {
            ActiveBarbers = barbers.OfType<Barber>().Where(b => b.Active).ToList();
            NotActiveBarbers = barbers.OfType<Barber>().Where(b => !b.Active).ToList();
        }
        //רשימה של הספרים הפעילים 
        public List<Barber> ActiveBarbers { get; set; }
        //רשימה של הספרים הלא פעילים
        public List<Barber> NotActiveBarbers { get; set; }
    }
}
