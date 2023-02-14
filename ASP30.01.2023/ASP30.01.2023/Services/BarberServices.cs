using ASP30._01._2023.Models;
using ASP30._01._2023.ViewModelsBarber;

namespace ASP30._01._2023.Services
{
    public class BarberServices
    {
        public BarberServices() { VM = new VMAddMonthlyProgram(); }
        public VMAddMonthlyProgram VM { get; set; }
        public List<MyDay> Days { get; set; } = new List<MyDay>();
        public void PlanProgram()
        {
            if(VM.Sunday) Days.Add(new MyDay { Day=1, Start=VM.StartSunday, End=VM.EndSunday});
            if (VM.Monday) Days.Add(new MyDay { Day = 2, Start = VM.StartMonday, End = VM.EndMonday });
            if (VM.Tuesday) Days.Add(new MyDay { Day = 3, Start = VM.StartTuesday, End = VM.EndTuesday });
            if (VM.Wednesday) Days.Add(new MyDay { Day = 4, Start = VM.StartWednesday, End = VM.EndWednesday });
            if (VM.Thursday) Days.Add(new MyDay { Day = 5, Start = VM.StartThursday, End = VM.EndThursday });
            if (VM.Friday) Days.Add(new MyDay { Day = 6, Start = VM.StartFriday, End = VM.EndFriday });

            Barber barber = DataLayer.Data.getBarbersAllIncludes.Find(b=>b.Rnd==VM.BarberID);
            if (barber == null) return;
            barber.AddWeeklyAppointment(VM.StartDate, VM.EndDate, Days);
        }
    }

    public class MyDay
    {
        public int Day { get; set; }
        public TimeOnly Start { get; set; }
        public TimeOnly End { get; set; }
    }
}
