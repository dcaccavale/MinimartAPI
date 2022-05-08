namespace Entities
{
    public class Store : Entity
    {
        public string Name { get; set; } 
        public virtual IEnumerable<DailyTimeRange>? DailyTimeRange { get; set; }
        public string? Address { get; set; }
        // public byte[] logo { get; set; }

        public bool IsOpen(TimeSpan time, DayOfWeek dayOfWeek)
        {
            if (DailyTimeRange == null) return false;
            return DailyTimeRange.Any(p => p.HourInRange(dayOfWeek, time));
            
            
        }
      
    }


}