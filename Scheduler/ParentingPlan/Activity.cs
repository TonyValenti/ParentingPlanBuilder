using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class Activity
    {
        public string Name {get; set;}
        public DateRangeFormula Duration { get; set; }
        public ParentingAssignmentFormula ParentingAssignment { get; set; }

        public Activity()
        {
            this.Duration = new DateRangeFormula();
        }
        
        

        public IEnumerable<CalendarEntry> Occurances(DateRange Range) {
            return Occurances(Range.StartDate, Range.EndDate);
        }

        public IEnumerable<CalendarEntry> Occurances(DateTime StartAfterDate, DateTime StartBeforeDate)
        {
            var Durations = Duration.Occurances(StartAfterDate, StartBeforeDate);
            var Assignments = ParentingAssignment.Assignments(Durations);

            var Query = 
                        from result in Assignments
                        select new CalendarEntry() {
                            Name = Name,
                            Duration = result.Duration,
                            Owner = result.Parent
                        };
            
            return Query;
        }

        public string Description {
            get {
                var ret = "";

                ret += string.Format("{0} will start on {1} and end on {2}.", Name, Duration.StartDate.Description, Duration.EndDate.Description);

                return ret;
            }
        }

        public override string ToString() {
            return Description;
        }


    }
}
