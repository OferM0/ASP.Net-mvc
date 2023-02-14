using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ASP30._01._2023.Models
{
    public class Client:User
    {
        public Client() { }

        /*[Display(Name = "תיאור")]
        public string Description { get; set; }

        [Display(Name = "תמונה")]
        public byte[] Image { get; set; }  

        //פונקצייה של הכנסת תמונה
        public IFormFile SetImage
        {
            set { Image = new SetImage(value).Image; }
        }*/
    }
}
