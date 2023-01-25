using System.ComponentModel.DataAnnotations;

namespace ASP21._12._2022.Models
{
    public class Image
    {
        public Image() { }
        public Image(IFormFile file) 
        { 
            //copy file to memory(RAM)
            MemoryStream stream = new MemoryStream();
            file.CopyTo(stream);
            MyImage=stream.ToArray();
        }

        [Key]
        public int ID { get; set; }
        public Employee Employee { get; set; }

        [Display(Name ="תמונה")]
        public byte[] MyImage { get; set; }
    }
}
