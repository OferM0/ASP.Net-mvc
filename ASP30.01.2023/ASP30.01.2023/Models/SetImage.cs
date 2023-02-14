namespace ASP30._01._2023.Models
{
    //עשינו מחלקה שבתוכה הפונקציה במקום לעשות אותה הפןנקציה בהרבה מחלקות שונות
    public class SetImage
    {
        public SetImage(IFormFile file)
        {
            if (file == null) return;
            MemoryStream stream = new MemoryStream();
            //העתקת הקובץ מהמשתמש למקום שנוצר זכרון
            file.CopyTo(stream);
            //הפיכת הזכרון למערך כדי שיוכל להיכנס למסד נתונים
            Image = stream.ToArray();
        }
        public byte[] Image { get; }

    }
}