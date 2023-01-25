using System.ComponentModel.DataAnnotations;

namespace ASP26._12._2022.Models
{
    public class Image
    {
        public Image() { }
    
        public Friend Friend { get; set; }

        [Key]
        public int ID { get; set; }

        [Display(Name = "תמונה")]
        public byte[] MyImage { get; set; }

        //תכונת הוספה של תמונה
        public IFormFile SetImage
        {
            set
            {
                //בדיקת ולידציה
                if (value == null) return;
                //יצירת מקום בזכרון המכיל קובץ
                MemoryStream stream = new MemoryStream();
                //העתקת הקובץ מהמשתמש למקום שנוצר בזכרון
                value.CopyTo(stream);
                //הפיכת הזכרון למערך כדי שיוכל להיכנס למסד נתונים
                MyImage=stream.ToArray();
            }
        }
    }
}
