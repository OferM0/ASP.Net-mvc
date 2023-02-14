using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP30._01._2023.Models
{
    public abstract class User
    {        
        public User() { Rnd = 0; }

        [Key]
        public int Id { get; set; }

        //מספר נוסף שמשתנה רנדומלית עם כל התחברות למערכת
        public int IdRandom { get; set; }

        [NotMapped]
        public int Rnd 
        {
            get 
            {
                return Id*100000 + IdRandom;
            }
            set
            {
                Random random = new Random();
                IdRandom = random.Next(10000,99999);
            } 
        }
        [Required, Display(Name ="שם פרטי")]
        public string FirstName { get; set; }

        [Required, Display(Name = "שם משפחה")]
        public string LastName { get; set; }

        [NotMapped, Display(Name = "שם מלא")]
        public string FullName { get { return FirstName + " " + LastName; } }

        [Required, Display(Name = "מספר טלפון")]
        public string PhoneNumber { get; set; }

        [EmailAddress(ErrorMessage ="נא הכנס כתובת מייל תקינה"), Display(Name = "כתובת מייל")]
        public string Email { get; set; }

        [DataType(DataType.Password), Display(Name = "סיסמא")]
        public string Password { get; set; }

        
        [Display(Name ="פעיל")]
        public bool Active { get; set; } = true;

        [Display(Name="פעיל"), NotMapped]
        public string IsActive 
        {
            get
            {
                if (Active) return "פעיל"; 
                return "לא פעיל";
            }
        }
        
    }
}
