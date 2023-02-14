using ASP30._01._2023.Models;
using System.ComponentModel.DataAnnotations;

namespace ASP30._01._2023.ViewModelsBarber
{
    public class VMAddMonthlyProgram
    {
        public VMAddMonthlyProgram() { }
        public Barber Barber { get; set; }
        public int BarberID { get; set; }

        [Display(Name = "תאריך התחלה"), DataType(DataType.Date)]
        public DateTime StartDate { get; set; } = DateTime.Now;

        [Display(Name = "תאריך סיום"), DataType(DataType.Date)]
        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(10);

        [Display(Name = "עבודה ביום ראשון?")]
        public bool Sunday { get; set; }

        [Display(Name = "שעת התחלה"), DataType(DataType.Time)]
        public TimeOnly StartSunday { get; set; } = new TimeOnly(9, 0);

        [Display(Name = "שעת סיום"), DataType(DataType.Time)]
        public TimeOnly EndSunday { get; set; } = new TimeOnly(16, 0);

        [Display(Name = "עבודה ביום שני?")]
        public bool Monday { get; set; }

        [Display(Name = "שעת התחלה"), DataType(DataType.Time)]
        public TimeOnly StartMonday { get; set; } = new TimeOnly(9, 0);

        [Display(Name = "שעת סיום"), DataType(DataType.Time)]
        public TimeOnly EndMonday { get; set; } = new TimeOnly(16, 0);

        [Display(Name = "עבודה ביום שלישי?")]
        public bool Tuesday { get; set; }

        [Display(Name = "שעת התחלה"), DataType(DataType.Time)]
        public TimeOnly StartTuesday { get; set; } = new TimeOnly(9, 0);

        [Display(Name = "שעת סיום"), DataType(DataType.Time)]
        public TimeOnly EndTuesday { get; set; } = new TimeOnly(16, 0);

        [Display(Name = "עבודה ביום רביעי?")]
        public bool Wednesday { get; set; }

        [Display(Name = "שעת התחלה"), DataType(DataType.Time)] 
        public TimeOnly StartWednesday { get; set; } = new TimeOnly(9, 0);

        [Display(Name = "שעת סיום"), DataType(DataType.Time)] 
        public TimeOnly EndWednesday { get; set; } = new TimeOnly(16, 0);

        [Display(Name = "עבודה ביום חמישי?")]
        public bool Thursday { get; set; }

        [Display(Name = "שעת התחלה"), DataType(DataType.Time)] 
        public TimeOnly StartThursday { get; set; } = new TimeOnly(9, 0);

        [Display(Name = "שעת סיום"), DataType(DataType.Time)] 
        public TimeOnly EndThursday { get; set; } = new TimeOnly(16, 0);

        [Display(Name = "עבודה ביום שישי?")]
        public bool Friday { get; set; }

        [Display(Name = "שעת התחלה"), DataType(DataType.Time)] 
        public TimeOnly StartFriday { get; set; } = new TimeOnly(9, 0);

        [Display(Name = "שעת סיום"), DataType(DataType.Time)] 
        public TimeOnly EndFriday { get; set; } = new TimeOnly(16, 0);
    }
}
