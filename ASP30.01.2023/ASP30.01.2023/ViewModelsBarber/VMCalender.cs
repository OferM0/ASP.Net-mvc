using ASP30._01._2023.Models;
using System.ComponentModel.DataAnnotations;

namespace ASP30._01._2023.ViewModelsBarber
{
    public class VMCalender
    {
        //פגישות של 10 ימים קדימה, של טור מכיל תאריך למעלה עם הפגישות של אותו יום
        //כל פגישה עם 4 מאפיינים, מספור רץ, זמן, סוג, אם יש לקוח- שמו אם לא- פנוי
        //אם יש לקוח צבע פגישה בירוק, אם אין צבע פגישה באדום
        //public VMCalender() 
        //{ 
        //    _appointments = new List<Appointment>(); 
        //}
        //משתנה פנימי
        private List<Appointment> _appointments;

        [Display(Name = "מספר ימים קדימה")]
        public int DaysForweard { get; set; } = 7;

        public List<Appointment> Appointments
        {
            get { return _appointments.ToList(); }
            set { _appointments = value.FindAll(a => a.DateTime.Date >= DateTime.Now.Date && a.DateTime.Date <= DateTime.Now.AddDays(DaysForweard).Date); }
        }

        public List<Appointment[]> DailyAppointment
        {
            get
            {
                //בניית רשימה של מערכים לשליחה בפונקציה
                List<Appointment[]> MyDaily = new List<Appointment[]>();
                //ריצה על כל הימים שבטווח של הפגישות
                for (DateTime i = Appointments.First().DateTime.Date; i <= Appointments.Last().DateTime.Date; i = i.AddDays(1))
                {
                    //יצירת רשימה יומית
                    Appointment[] temp = Appointments.FindAll(a => a.DateTime.Date == i).ToArray();
                    //בדיקה האם יש פגישות באותו יום
                    if (temp.Length > 0)
                    {
                        MyDaily.Add(temp);
                    }
                }
                return MyDaily;
            }
        }
    }
}
