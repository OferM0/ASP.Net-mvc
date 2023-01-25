using System.Data.Entity;

namespace ASP26._12._2022.Models
{
    public class DataLayer:DbContext
    {
        //יצירת מודל פנימי סטטי 
        private static DataLayer data;

        private DataLayer() : base("Data Source=localhost\\sqlexpress; Initial Catalog=MyFriends; Integrated Security=SSPI;Persist Security Info=False")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataLayer>());
            //כאשר המסד הנתונים ריק, מפעיל את הפונקצייה הזורעת
            if (Friends.Count() == 0) Seed();
            //if (Images.Count() == 0) Seed();
        }

        //seed-פונקציה הזורעת את מסד הנתונים בפעם הראשונה
        public void Seed()
        {
            Friend friend = new Friend
            {
                FirstName = "עופר",
                LastName = "מרדכי",
                City = "קריית מוצקין",
                Street = "יגאל אלון",
                Number = "5",
                Phone = "0528016257",
                Email = "ofermordehai0@gmail.com",
                //Date = DateTime.Now.AddYears(-22)
            };
            //הוספת שורה לטבלה
            Friends.Add(friend);
            //שמירת שינויים
            SaveChanges();
        }

        //DbSet- פקודה ליצירת טבלאות בדטה בייס
        //טבלת חברים
        public DbSet<Friend> Friends { get; set; }
        //טבלת תמונות
        public DbSet<Image> Images { get; set; }

        //פונקציה הנותנת גישה לקריאה בלבד של האובייקט הפנימי
        public static DataLayer Data
        {
            get
            {
                //אם האובייקט עדיין לא הופעל, מפעיל את האובייקט
                if (data == null) data = new DataLayer();
                return data;
            }
        }
    }
}
