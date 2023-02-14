using ASP30._01._2023.Models;
using System.ComponentModel.DataAnnotations;

namespace ASP30._01._2023.ViewModelsHome
{
    public class VMLogin
    {
        public VMLogin() { }

        public Client Client { get; set; }
        //[Display(Name ="הכנס כתובת מייל")]
        //[EmailAddress(ErrorMessage ="נא הכנס כתובת מייל תקינה")]
        //public string Email { get; set; }

        //[Display(Name ="הכנס סיסמא")]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }

        public string Feedback { get; set; } = "התחבר";

        public string Color { get; set; } = "black";
    }
}
