namespace ASP21._12._2022.Models
{
    public class DataLayer
    {
        private static DataLayer data;

        private DataLayer():base("Data Source=localhost\\sqlexpress; Initial Catalog=Employess; Integrated Security=SSPI;Persist Security Info=False")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DataLayer>());
            if (Employees.Count() == 0) seed();
        }

        //פונקציה הנותנת גישה לקריאה בלבד של האובייקט הפנימי
        public static DataLayer Data
        {
            get
            {
                //אם האובייקט עדיין לא הופעל, מפעיל את האובייקט
                if(data == null) data = new DataLayer();
                return data;
            }
        }
    }
}
