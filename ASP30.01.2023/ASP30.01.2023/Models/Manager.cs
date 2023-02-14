using System.ComponentModel.DataAnnotations;

namespace ASP30._01._2023.Models
{
    public class Manager:User
    {
        //public Manager() { }
        
        [Display(Name ="תאריך תחילת המינוי"), DataType(DataType.Date)]
        public DateTime Start { get; set; }

        //[Display(Name = "תאריך סיום המינוי")]
        //public DateTime End { get; set; }
    }
}