using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class SummaryByProject
    {
        public string Project { get; set; }
        public int Week { get; set; }

        public List<WeeklyTimesheet> WeeklyTimeLogSummary { get; set; }

    }
}
