using System;

namespace Minimart_API.Controllers
{
    public class IsOpenRequest
    {
        public DayOfWeek DayOfweek { get; set; }
        public byte Hour { get; set; }
        public byte Minutes { get; set; }
    }
}