using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class DailyLog
    {
        public TimeSpan Duration { get; set; }
        public DateTime LoggedDate { get; set; }
    }
}
