using ASP30._01._2023.Services;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.Metrics;
using System.Threading;

namespace ASP30._01._2023.Models
{
    public class Barber:User
    {
        public Barber() { HaircutPerBarberList = new List<HaircutPerBarber>(); }

        [Display(Name = "תיאור")]
        public string Description { get; set; }

        [Display(Name = "תמונה")]
        public byte[] Image { get; set; }

        //רשימה של כל סוגי התספורות שהספר מבצע
        public List<HaircutPerBarber> HaircutPerBarberList { get; set; }
        //public List<WorkTime> WorkTimes { get; set; }

        //פונקציה המוסיפה סוג תספורת
        public void AddHaircut(string haircut, int duration, int price, int precent)
        {
            Haircut haircut1= DataLayer.Data.Haircuts.ToList().Find(h=>h.Name==haircut);
            if (haircut1 == null) return;
            HaircutPerBarber haircutPerBarber=new HaircutPerBarber
            {
                Haircut = haircut1,
                Barber = this,
                Duration = duration,
                Price = price,
                PrecentFromAllHaircuts = precent
            };
            //הוספה לרשימה של הספר
            HaircutPerBarberList.Add(haircutPerBarber);

            //הוספה לרשימה של הפעולות
            haircut1.HaircutPerBarbers.Add(haircutPerBarber);
        }

        //פונקצייה של הכנסת תמונה
        public IFormFile SetImage
        {
            set{ Image = new SetImage(value).Image; }
        }

        //רשימת פגישות
        public List<Appointment> Appointments { get; set; }

        //פונקציה המקבלת טווח חודשי כולל השעות לפי הימים בשבוע

        ////פונקציה המקבלת טווח תאריכי עם שעות של יום בשבוע
        //public void AddRangeDaily(DateTime start, DateTime end, int dayOfTheWeek, TimeOnly timeStart, TimeOnly timeEnd)
        //{
        //    int result = 0;
        //    for(DateTime day= start; day<=end; day = day.AddDays(1))
        //    {
        //        if ((int)day.DayOfWeek == dayOfTheWeek)
        //        {
        //            //AddDailyAppointment(new DateTime(day.Year, day.Month, day.Day,timeStart.Hour, timeStart.Minute,0), new DateTime(day.Year, day.Month, day.Day, timeEnd.Hour, timeEnd.Minute, 0), out result);
        //        }
        //    }
        //}

        //פונקציה המוסיפה פגישות לפי כמה ימים בשבוע
        public void AddWeeklyAppointment(DateTime start, DateTime end, List<MyDay> days)
        {
            int counter = 0;
            for (DateTime i = start; i <= end; i = i.AddDays(1))
            {
                MyDay myDay = days.Find(d => d.Day == ((int)i.DayOfWeek)+1);
                if (myDay != null)
                {
                    //יצירת משתנים של תאריך ושעה המכילים שעת התחלה וסעת סיום של אותו יום
                    DateTime startDay = new DateTime(i.Year, i.Month, i.Day, myDay.Start.Hour, myDay.Start.Minute, 0);
                    DateTime endDay = new DateTime(i.Year, i.Month, i.Day, myDay.End.Hour, myDay.End.Minute, 0);
                    //שליחה לפונקציה היומית
                    AddDailyAppointment(startDay, endDay, counter, out counter);
                }
            }
        }

        //פונקציה המוסיפה פגישות יומיות
        public void AddDailyAppointment(DateTime start, DateTime end, int counter, out int modulu)
        {
            //אם המונה מגיע 0 אז מעדכנים לפי מספר הפעולות של הספר
            if (counter == 0) counter = TotalPlan;
            //תחילת שעון יומי
            DateTime time = start;
            int duration = 0;
            do
            {
                //הוספת פגישה לפי סוג הפגישה בזמן
                //חישוב כל הפגישות פחות השארית
                AddAppointment(Plan[TotalPlan - counter], time);
                //הוספת זמן הפגישה לשעון היומי 
                time = time.AddMinutes(Plan[TotalPlan - counter].Duration);              
                //הפחתת השארית
                counter--;
                //אם המונה מגיע 0 אז מעדכנים לפי מספר הפעולות של הספר
                if (counter == 0) counter = TotalPlan; 
                //הוצאת זמן הפגישה הבאה למשתנה חיצוני
                duration= Plan[TotalPlan - counter].Duration;
                //כל עוד שיש זמן לקבוע פגישה נוספת באותו היום
            } while (time <= end.AddMinutes(-duration));

            modulu = counter;

            ////ריצה על כל סוגי הפעולות של הספר
            //foreach (HaircutPerBarber hairCutPer in HaircutPerBarberList)
            //{
            //    //ריצה על מספר הפעמים שיש לכל פעולה
            //    for(int i =0; i< hairCutPer.PrecentFromAllHaircuts; i++)
            //    {
            //        //בדיקה האם יש זמן עד סוף המשמרת לבצע את הפעולה
            //        if(time<end.AddMinutes(-hairCutPer.Duration))
            //        {
            //            AddAppointment(hairCutPer, time);
            //            //הוספת זמן הפגישה לשעון היומי
            //            time.AddMinutes(hairCutPer.Duration);
            //        }
            //    }
            //}

            //ריצה על כל המקומות ברשימה
            //for (int i = 0; i < Plan.Count; i++)
            //{
            //    //ריצה לפי סוגי הפעולות בכמות של כל אחד מהם
            //    for (int j = 0; j < Plan[i]; j++)
            //    {
            //        //מבודד את הפעולה הנוכחית
            //        HaircutPerBarber hairCut = HaircutPerBarberList[j];
            //        //רץ על כל השעות של אותו יום
            //        for (DateTime currentTime = time; currentTime < end.AddMinutes(-hairCut.Duration); currentTime = currentTime.AddMinutes(hairCut.Duration))
            //        {
            //            time = currentTime;
            //            //הוספת הפגישה בפועל
            //            AddAppointment(hairCut, currentTime);
            //            counter--;
            //        }
            //    }
            //}
            //modulu = counter;
        }

        //החזרת סך מחזוריות
        [NotMapped]
        private int TotalPlan
        {
            get
            {
                return Plan.Count;
            }
        }

        //החזרת רשימה של כל הפעולות
        [NotMapped]
        private List<HaircutPerBarber> Plan
        {
            get
            {
                List<HaircutPerBarber> temp = new List<HaircutPerBarber>();
                foreach (HaircutPerBarber hairCutPer in HaircutPerBarberList)
                {
                    for (int i = 0; i < hairCutPer.PrecentFromAllHaircuts; i++)
                    {
                        //לפי הכמות שהספר ציין לכל פעולה, מתווסף מקום ברשימה 
                        temp.Add(hairCutPer);
                    }
                }
                return temp;
            }
        }

        //פונקציה המוסיפה פגישה לפי שם פעולה
        public Appointment AddAppointment(string haircut, DateTime dateTime)
        {
            HaircutPerBarber haircutPerBarber = HaircutPerBarberList.Find(h => h.Haircut.Name == haircut);
            return AddAppointment(haircutPerBarber, dateTime);
        }

        //פונקציה המוסיפה פגישה
        public Appointment AddAppointment(HaircutPerBarber haircut, DateTime dateTime)
        {
            Appointment appointment = new Appointment
            {
                DateTime= dateTime,
                Haircut= haircut,
            };

            Appointments.Add(appointment);
            return appointment;
        }
    }
}