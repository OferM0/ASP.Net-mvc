using System.ComponentModel.DataAnnotations;

namespace ASP18._01._2023.Models
{
    public class Image
    {
        public Image() { }

        [Key]
        public int ID { get; set; }
        public Item Item { get; set; }

        [Display(Name = "תמונה")]
        public byte[] MyImage { get; set; }

        //פונקציה של הכנסת תמונה
        public IFormFile SetImage
        {

            set
            {
                if (value == null) return;
                MemoryStream Stream = new MemoryStream();
                value.CopyTo(Stream);
                MyImage = Stream.ToArray();
            }
        }
    }
}