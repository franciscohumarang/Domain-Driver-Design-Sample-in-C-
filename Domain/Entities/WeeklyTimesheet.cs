using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{

    public class WeeklyTimesheet
    {
        public TimeSpan TotalWeeklogLogs { get; set; }
        public List<DailyLog> DailyLogs { get; set; }

    }
}
