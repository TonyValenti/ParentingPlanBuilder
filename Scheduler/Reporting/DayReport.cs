using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Reporting {
    public class DayReport : Report {
        public List<CalendarEntry> Items { get; private set; } = new List<CalendarEntry>();

        public int Year { get; private set; }
        public int Month { get; private set; }
        public int Day { get; private set; }

        public DateTime StartDate { get; private set; }
        public DateTime EndDate { get; private set; }
        public DateRange Range { get; private set; }

        public DayReport(List<CalendarEntry> Entries, int Year, int Month, int Day) {
            this.Year = Year;
            this.Month = Month;
            this.Day = Day;
            this.StartDate = new DateTime(Year, Month, Day);
            this.EndDate = StartDate.AddDays(1);
            this.Range = new DateRange(
                    StartDate,
                    EndDate
                    );

            var Query = from x in Entries
                        where x.Duration.Intersects(Range)
                        select x;

            Items.AddRange(Query);

            Analyze();
        }
        
        private void Analyze() {
            CalculateOvernight();
        }

        public ParentingAssignment Overnight { get; private set; } = ParentingAssignment.Unknown;
        private void CalculateOvernight() { 
            var OvernightTime = new DateTime(Year, Month, Day, 23, 59, 00);
            var Item = (from x in Items where x.Duration.Intersects(OvernightTime) select x).FirstOrDefault();

            if(Item != null) {
                Overnight = Item.Owner;
            }
        }
        

    }
}
