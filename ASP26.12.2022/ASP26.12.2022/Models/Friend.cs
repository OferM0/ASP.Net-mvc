using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASP26._12._2022.Models
{
    public class Friend
    {
        /*
       public Friend(int id, string firstName, string lastName, string phone, string email, string city, int number, string street)
       {
           ID = id;
           FirstName = firstName;
           LastName = lastName;           
           Phone = phone;
           Email=email
           City = city;
           Street = street;
           Number= number
           Images = new List<Image>();
       }
       */
        public Friend() { Images = new List<Image>(); }

        [Key]
        public int ID { get; set; }

        [Required, Display(Name = "שם פרטי")]
        public string FirstName { get; set; } = "";

        [Required, Display(Name = "שם משפחה")]
        public string LastName { get; set; } = "";

        [Display(Name = "שם מלא"), NotMapped]//notmapped= this field will not get to DB
        public string FullName { get { return FirstName + " " + LastName; } }

        [Required, Display(Name = "מספר טלפון"), Phone(ErrorMessage ="נא הכנס מספר טלפון תקין")]
        public string Phone { get; set; } = "";

        [Required, Display(Name = "אימייל"), EmailAddress(ErrorMessage = "נא הכנס כתובת מייל נכונה")]
        public string Email { get; set; } = "";

        [Required, Display(Name = "עיר")]
        public string City { get; set; } = "";

        [Required, Display(Name = "רחוב")]
        public string Street { get; set; } = "";

        [Required, Display(Name = "מספר")]
        public string Number { get; set; } = "";

        [Display(Name = "כתובת מלאה"), NotMapped]//notmapped= this field will not get to DB
        public string Address { get { return City + " " + Street + " " + Number; } }
       
        /*
        [Required, DataType(DataType.Date), Display(Name = "תאריך לידה")]
        public DateTime Date { get; set; } = DateTime.Now.AddYears(-18);

        
        [Display(Name = "גיל")]
        public int Age { get { return DateTime.Now.Year - Date.Year; } }
        */
        public List<Image> Images { get; set; }

        //function- add image to employee
        public void AddImage(IFormFile file)
        {
            if (file == null) return;
            Images.Add(new Image { Friend=this, SetImage = file });

        }
    }
}

