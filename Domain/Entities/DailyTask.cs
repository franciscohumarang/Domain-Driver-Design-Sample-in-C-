using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class DailyTask
    {

        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Descrption { get; set; }
        public string Project { get; set; }
        public string TaskType { get; set; }

        public TimeSpan Durration { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
