namespace Entities
{
    public class DailyTimeRange :Entity
    {

        /// <summary>
        /// Represents one hour from,  year 1 mouth 1 day 1 
        /// </summary>
        public TimeSpan HourFrom { get; set; }
        /// <summary>
        /// Represents one hour To ,  year 1 mouth 1 day 1 
        /// </summary>
        public TimeSpan HourTo { get; set; }
        /// <summary>
        /// Represents one Day of week ,  year 1 mouth 1 day 1 
        /// </summary>
        public string  DayOfWeek { get; set; }
        public DailyTimeRange()
        {

        }
        /// <summary>
        /// Constructor whit parameter 
        /// </summary>
        /// <param name="hourFrom">Use it only to save the time from</param>
        /// <param name="hourTo">Use it only to save the time to</param>
        /// <param name="dayOfWeek"></param>
        /// <exception cref="ArgumentException"></exception>
        public DailyTimeRange(TimeSpan hourFrom , TimeSpan hourTo,DayOfWeek dayOfWeek)
        {
            if (hourTo < hourFrom) throw new ArgumentOutOfRangeException("Invalid parameter, hour from greater than hour to");
            DayOfWeek = dayOfWeek.ToString();
            HourFrom = hourFrom;
            HourTo = hourTo;
        }
        public  bool HourInRange(DayOfWeek dayOfWeek , TimeSpan time)
        {
             return dayOfWeek.ToString() == DayOfWeek
               && HourFrom <= time && HourTo > time;

        }
    }
}