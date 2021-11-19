using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Client
    {
        public Client()
        {
            TaskEntries = new HashSet<TaskEntry>();
        }

        public int ClientId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TaskEntry> TaskEntries { get; set; }
    }
}
