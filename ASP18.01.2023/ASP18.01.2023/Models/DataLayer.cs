using System.Data.Entity;

namespace ASP18._01._2023.Models
{
    public class DataLayer:DbContext
    {
        //יצירת מודל פנימי סטטי 
        private static DataLayer data;

        private DataLayer() : base("Data Source=localhost\\sqlexpress; Initial Catalog=JewelryStore; Integrated Security=SSPI;Persist Security Info=False")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataLayer>());
            //כאשר המסד הנתונים ריק, מפעיל את הפונקצייה הזורעת
            if (Groups.Count() == 0) Seed();
        }

        //seed-פונקציה הזורסת את מסד הנתונים בפעם הראשונה
        private void Seed()
        {
            //קבוצה ראשית
            Group group = new Group { Name = "חנות תכשיטים" };
            //מחיר ברירת מחדל
            Price price= new Price { MyPrice=150000, End = DateTime.Now.AddYears(20) };

            //הוספת שורה לטבלה
            Groups.Add(group);
            Prices.Add(price);
            //שמירת שינויים
            SaveChanges();
        }
        //פונקצייה המחזירה רשימת קבוצות עם כל הטעינות שלהם- פריטים- מחירים ותמונות
        public List<Group> GroupsWithAllIncludes
        {
            get
            {
                //על מנת שהפריטים בטעינה אחר כך יהיו כוללים גם תמונות ומחירים
                List<Item> items= Data.Items.Include(i=>i.Group).Include(i => i.Images).Include(i => i.Prices).ToList();

                return Data.Groups.Include(g=>g.SubGroups).Include(g=>g.Items).ToList();
            }
        }

        //DbSet- פקודה ליצירת טבלאות בדטה בייס
        //טבלת קטגוריות
        public DbSet<Group> Groups { get; set; }
        //טבלת מוצרים
        public DbSet<Item> Items { get; set; }
        //טבלת תמונות
        public DbSet<Image> Images { get; set; }
        //טבלת תמונות
        public DbSet<Price> Prices { get; set; }


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
