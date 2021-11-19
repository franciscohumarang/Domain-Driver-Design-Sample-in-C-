using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class TaskEntry
    {
        public int TaskId { get; set; }
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Descrption { get; set; }
        public int ProjectId { get; set; }
        public int? ClientId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime LoggedDate { get; set; }
        public int TaskTypeId { get; set; }

        public bool? IsBillable { get; set; }

        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual Project Project { get; set; }
        public virtual TaskType TaskType { get; set; }
    }
}
