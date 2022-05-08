namespace Entities
{
    public class Store : Entity
    {
        public string Name { get; set; } 
        public virtual IEnumerable<DailyTimeRange>? DailyTimeRange { get; set; }
        public string? Address { get; set; }
        // public byte[] logo { get; set; }

        public bool IsOpen(DateTime dateTime)
        {
            if (DailyTimeRange == null) return false;
            DailyTimeRange? hoursOpen = DailyTimeRange.FirstOrDefault(p => p.DayOfWeek == dateTime.DayOfWeek.ToString());
            return hoursOpen != null && hoursOpen.HourInRange(dateTime);
            
        }
      
    }


}