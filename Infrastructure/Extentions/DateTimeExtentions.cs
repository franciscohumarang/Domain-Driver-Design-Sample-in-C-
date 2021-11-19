using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Infrastructure.Misc
{
   public static partial class DateTimeExtensions
    {
        public static int GetWeekOfYear(this DateTime dateTime)
        {
            CultureInfo cultureInfo = new CultureInfo("en-US");
            Calendar calendar = cultureInfo.Calendar;


            CalendarWeekRule calendarWeekRule = cultureInfo.DateTimeFormat.CalendarWeekRule;
            DayOfWeek firstDayOfWeek = cultureInfo.DateTimeFormat.FirstDayOfWeek;

          

            return calendar.GetWeekOfYear(dateTime, calendarWeekRule, firstDayOfWeek);
        }
    }
}
