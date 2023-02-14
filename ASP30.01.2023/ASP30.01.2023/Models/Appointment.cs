using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP30._01._2023.Models
{
    public class Appointment
    {
        public Appointment() { }

        [Key]
        public int Id { get; set; }
        public HaircutPerBarber Haircut { get; set; }
        public Client Client { get; set; }
        public DateTime DateTime { get; set; }

        //פונקציה המציגה סיכום
        [NotMapped, Display(Name = "פגישה")]
        public string Summary
        {
            get
            {
                return DateTime.ToShortTimeString() + " " + Haircut.Haircut.Name + " " + ClientName;
            }
        }

        //פונקציה המציגה לספר שמות הלקוחות
        [NotMapped, Display(Name = "שם לקוח")]
        public string ClientName 
        { 
            get 
            {
                if (Client == null) return "פנוי";
                return Client.FullName;
            } 
        }

        //פונקציה המציגה את הסטטוס בצבע שונה לפי הסטטוס
        [NotMapped, Display(Name = "צבע פגישה")]
        public string StatusColor
        {
            get
            {
                if (Client == null) return "red";
                return "green";
            }
        }

        //פונקציה המציגה ללקוחות פגישות פנויות
        [NotMapped, Display(Name ="סטטוס פגישה")]
        public string AppointmentStatus
        {
            get
            {
                if (Client == null) return "פנויה";
                return "תפוסה";
            }
        }
    }
}
