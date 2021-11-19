using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public partial class Employee
    {
        public Employee()
        {
            TaskEntries = new HashSet<TaskEntry>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<TaskEntry> TaskEntries { get; set; }
    }
}
