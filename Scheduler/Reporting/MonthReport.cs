using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Reporting {
    public class MonthReport : Report {
        public List<DayReport> Reports { get; private set; } = new List<DayReport>();
        public List<CalendarEntry> Items { get; private set; } = new List<CalendarEntry>();

        public int Year { get; private set; }
        public int Month { get; private set; }


        public MonthReport(List<CalendarEntry> Entries, int Year, int Month) {
            this.Year = Year;
            this.Month = Month;

            var Start = new DateTime(Year, Month, 1);
            var End = Start.AddMonths(1);
            var Range = new DateRange(
                    Start,
                    End
                    );

            var Query = from x in Entries
                        where x.Duration.Intersects(Range)
                        select x;

            Items.AddRange(Query);

            for (int Day = 1; Day <= DateTime.DaysInMonth(Year,Month); Day++) {
                var NewReport = new DayReport(Items, Year, Month, Day);
                Reports.Add(NewReport);
            }

            Analyze();
        }

        private void Analyze() {
            CalculateOvernights();
        }


        public Dictionary<ParentingAssignment, int> Overnights { get; private set; }  = new Dictionary<ParentingAssignment, int>();
        private void CalculateOvernights() {
            foreach (var item in ParentingAssignmentExtensions.Order) {
                Overnights[item] = 0;
            }

            foreach (var item in Reports) {
                var Value = 0;
                Overnights.TryGetValue(item.Overnight, out Value);
                Overnights[item.Overnight] = Value + 1;
            }
        }


        public override string ToHtml() {
            var Output = new Templates.MonthView();
            Output.Report = this;
            return Output.TransformText();
        }
    }
}
