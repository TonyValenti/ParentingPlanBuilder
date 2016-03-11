using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public static class ActivityWithers
    {
        public static Activity WithName(this Activity Activity, string Name)
        {
            Activity.Name = Name;
            return Activity;
        }

        public static Activity WithDuration(this Activity Activity, DateRangeFormula Duration)
        {
            Activity.Duration = Duration;
            return Activity;
        }

        public static Activity WithDuration(this Activity Activity, TimeFormula StartDate, TimeFormula EndDate)
        {
            Activity.Duration = new DateRangeFormula(StartDate, EndDate);
            return Activity;
        }

        public static Activity WithStartDate(this Activity Activity, TimeFormula StartDate)
        {
            Activity.Duration.StartDate = StartDate;
            return Activity;
        }

        public static Activity WithStartDate(this Activity Activity, TimeFormula Offset, TimeAdjustmentMode Position, TimeFormula Location) {
            Activity.Duration.StartDate = new TimeAdjuster(Offset, Position, Location);
            return Activity;
        }

        public static Activity WithEndDate(this Activity Activity, TimeFormula EndDate)
        {
            Activity.Duration.EndDate = EndDate;
            return Activity;
        }

        public static Activity WithEndDate(this Activity Activity, TimeFormula Offset, TimeAdjustmentMode Position, TimeFormula Location) {
            Activity.Duration.EndDate = new TimeAdjuster(Offset, Position, Location);
            return Activity;
        }

        public static Activity WithParentingTime(this Activity Activity, ParentingAssignmentFormula ParentingTime)
        {
            Activity.ParentingAssignment = ParentingTime;
            return Activity;
        }

        public static Activity WithParentingTime(this Activity Activity, params ParentingAssignment[] Pattern)
        {
            Activity.ParentingAssignment = new AlternatingParentingAssignmentFormula(Pattern);
            return Activity;
        }

        public static Activity WithParentingTimeAlternatingByYear(this Activity Activity, ParentingAssignment EvenYears)
        {
            Activity.ParentingAssignment = new YearlyAlternatingParentingAssignmentFormula(EvenYears);
            return Activity;
        }
    }
}
