using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class CalendarEntry 
    {
        public static CalendarEntry Unknown(DateRange Range) {
            return Unknown(Range.StartDate, Range.EndDate);
        }

        public static CalendarEntry Unknown(DateTime StartDate, DateTime EndDate) {
            var ret = new CalendarEntry() {
                Name = "Unknown",
                Owner = ParentingAssignment.Unknown,
                Duration = new DateRange(StartDate, EndDate)
            };

            return ret;
        }


        public override string ToString()
        {
            return string.Format("{0} ({1})", Name, Duration);
        }


        public DateRange Duration { get; set; }

        public ParentingAssignment Owner { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public CalendarEntry Clone()
        {
            var ret = new CalendarEntry()
            {
                Duration = this.Duration.Clone(),
                Owner = this.Owner,
                Name = this.Name,
                Description = this.Description
            };

            return ret;
        }

        public CalendarEntry()
        {
            Duration = new DateRange();
            Name = "";
            Description = "";
            Owner = ParentingAssignment.Unknown;
        }
       

       

        public static List<CalendarEntry> Add(CalendarEntry Priority, CalendarEntry Value)
        {
            var ret = new List<CalendarEntry>() { Priority };

            if (!Value.Duration.Intersects(Priority.Duration)){
                ret.Add(Value);
            } else
            {
                var NewValue = Value.Clone();
                if (Priority.Duration.Intersects(NewValue.Duration.StartDate))
                {
                    NewValue.Duration.StartDate = Priority.Duration.EndDate;
                }

                if(NewValue.Duration.Intersects(Priority.Duration.StartDate))
                {
                    NewValue.Duration.EndDate = Priority.Duration.StartDate;
                }

                if (!NewValue.Duration.IsEmpty)
                {
                    ret.Add(NewValue);
                }
            }

            ret = (from x in ret orderby x.Duration.StartDate select x).ToList();

            return ret;
        }

  
    }
}
