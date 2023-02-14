namespace ASP30._01._2023.Models
{
    public class WorkTime
    {
        public int Id { get; set; }
        public Barber Barber { get; set; }
        public int BarberId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}
