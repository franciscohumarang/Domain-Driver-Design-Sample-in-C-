using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Project
    {
        public Project()
        {
            TaskEntries = new HashSet<TaskEntry>();
        }

        public int ProjectId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TaskEntry> TaskEntries { get; set; }
    }
}
