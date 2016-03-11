using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public static class ScheduleWithers
    {
        public static Activity CreateActivity(this Schedule Schedule)
        {
            var ret = new Activity();

            Schedule.Activities.Add(ret);

            return ret;
        }

        public static Schedule WithName(this Schedule Schedule, string Name)
        {
            Schedule.Name = Name;
            return Schedule;
        }

        public static Schedule WithDuration(this Schedule Schedule, DateRangeFormula Duration)
        {
            Schedule.Duration = Duration;
            return Schedule;
        }

        public static Schedule WithDuration(this Schedule Schedule, TimeFormula StartDate, TimeFormula EndDate)
        {
            Schedule.Duration = new DateRangeFormula(StartDate, EndDate);
            return Schedule;
        }

        public static Schedule WithStartDate(this Schedule Schedule, TimeFormula StartDate)
        {
            Schedule.Duration.StartDate = StartDate;
            return Schedule;
        }

        public static Schedule WithEndDate(this Schedule Schedule, TimeFormula EndDate)
        {
            Schedule.Duration.EndDate = EndDate;
            return Schedule;
        }



    }
}
