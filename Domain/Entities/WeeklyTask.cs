using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
   public class WeeklyTask
    {
        
      
        public DateTime LoggedDate { get; set; }
        public int Week { get; set; }
        public TimeSpan TotalWeekHrs { get; set; }

       public  List<DailyTask> DailyTask { get; set; }


    }
 



  
}
