using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class TaskType
    {
        public TaskType()
        {
            TaskEntries = new HashSet<TaskEntry>();
        }

        public int TaskTypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TaskEntry> TaskEntries { get; set; }
    }
}
