using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class ParentingPlan
    {
        public List<Schedule> Schedules { get; private set; } = new List<Schedule>();


        public IEnumerable<CalendarEntry> Generate(int Year)
        {
            return Generate(new DateTime(Year, 1, 1), new DateTime(Year, 1, 1));
        }

        public IEnumerable<CalendarEntry> Generate(DateTime StartDate, DateTime EndDate)
        {
            var NewStart = StartDate.AddYears(-1);
            var NewEnd = EndDate.AddYears(1);

            var Query = from Schedule in Schedules
                        from ScheduleOccurance in Schedule.Duration.Occurances(NewStart, NewEnd)
                        from Activity in Schedule.Activities
                        from ActivityOccurance in Activity.Occurances(ScheduleOccurance)
                        select ActivityOccurance
                        ;


            var Q2 = from x in Schedules
                     where x != null
                     select x
                     ;

            return Query;
        }
    }
}
