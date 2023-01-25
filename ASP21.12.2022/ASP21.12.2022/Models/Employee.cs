using System.ComponentModel.DataAnnotations;

namespace ASP21._12._2022.Models
{
    public class Employee
    {
        /*
        public Employee(int id, int idNumber, string firstName, string lastName, DateTime birthDate, string status, string gender, string city, int number, string street, int homeNumber, int phoneNumber)
        {
            ID = id;
            IdNumber = idNumber;
            FirstName = firstName;
            LastName = lastName;
            BirthDate = birthDate;
            Status = status;
            Gender = gender;
            City = city;
            Number = number;
            Street = street;
            HomeNumber = homeNumber;
            PhoneNumber = phoneNumber;
        }
        */
        public Employee() { Images = new List<Image>(); }

        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "מספר זהות")]
        public string IdNumber { get; set; } = "";

        [Required, Display(Name = "שם פרטי")]
        public string FirstName { get; set; } = "";

        [Required, Display(Name = "שם משפחה")]
        public string LastName { get; set; } = "";

        
        [Required, Display(Name = "שם מלא")]
        public string FullName { get { return FirstName+ " " + LastName; } }

        [Required, Display(Name = "אימייל"), EmailAddress(ErrorMessage ="נא הכנס כתובת אימייל נכונה")]
        public string Email { get; set; } = "";

        [Required, Display(Name = "עיר")]
        public string City { get; set; }

        [Required, DataType(DataType.Date), Display(Name ="תאריך לידה")]
        public DateTime Date { get; set; }=DateTime.Now.AddYears(-18);

        [Display(Name = "גיל")]
        public int Age { get { return DateTime.Now.Year - Date.Year; } }

        public List<Image> Images { get; set; }
        /*
        public string Status { get; set; }
        public string Gender { get; set; }
        public int Number { get; set; }
        public string Street { get; set; }
        public int HomeNumber { get; set; }
        public int PhoneNumber { get; set; }*/

        //function- add image to employee
        public IFormFile setImage
        {
            set
            {
                if (value == null) return;
                Images.Add(new Image(value));
            }
        }
    }
}
