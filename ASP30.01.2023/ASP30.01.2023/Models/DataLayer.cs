using static System.Net.Mime.MediaTypeNames;
using System.Collections.Generic;
using System.Data.Entity;

namespace ASP30._01._2023.Models
{
    public class DataLayer : DbContext
    {
        //המשתמש המחובר כרגע
        public User GetUser = new Client { FirstName = "התחבר", };

        //יצירת מודל פנימי סטטי 
        private static DataLayer data;

        public DataLayer() : base("Data Source=localhost\\sqlexpress; Initial Catalog=BarberyShop; Integrated Security=SSPI;Persist Security Info=False")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataLayer>());
            //כאשר המסד הנתונים ריק, מפעיל את הפונקצייה הזורעת
            if (Users.Count() == 0) Seed();
        }

        //seed-פונקציה הזורעת את מסד הנתונים בפעם הראשונה
        public void Seed()
        {
            Manager manager = new Manager()
            {
                FirstName = "עופר",
                LastName = "מרדכי",
                PhoneNumber = "0528016257",
                Email = "ofermordehai0@gmail.com",
                Password = "ofer123456",
                Start= DateTime.Now
            };
            //הוספת שורה לטבלה
            Users.Add(manager);
            Barber barber = new Barber()
            {
                FirstName = "ישראל",
                LastName = "ישראלי",
                PhoneNumber = "0528046264",
                Email = "mail@gmail.com",
                Password = "israel123456",
                Description = "ספר מצוין"
            };
            //הוספת שורה לטבלה
            Users.Add(barber);
            //שמירת שינויים
            SaveChanges();
        }

        //DbSet- פקודה ליצירת טבלאות בדטה בייס
        //טבלת משתמשים
        public DbSet<User> Users { get; set; }
        //טבלת תספורות
        public DbSet<Haircut> Haircuts { get; set; }
        //טבלת תספורות של ספרים
        public DbSet<HaircutPerBarber> HaircutPerBarber { get; set; }
        //טבלת תורים
        public DbSet<Appointment> Appointments { get; set; }

        //
        public List<Barber> getBarbersAllIncludes
        {

            get
            {
                Haircuts.Include(h => h.HaircutPerBarbers).ToList();
                return Users.OfType<Barber>().Include(b => b.HaircutPerBarberList).Include(b => b.Appointments).ToList();
            }
        }

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
