using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Reporting {
    public class YearReport : Report {

        public List<MonthReport> Reports { get; private set; } = new List<MonthReport>();
        public List<CalendarEntry> Items { get; private set; } = new List<CalendarEntry>();

        public int Year { get; private set; }

        public YearReport(List<CalendarEntry> Entries, int Year) {
            this.Year = Year;

            var Range = new DateRange(
                    new DateTime(Year, 1, 1),
                    new DateTime(Year + 1, 1, 1)
                    );

            var Query = from x in Entries
                        where x.Duration.Intersects(Range)
                        select x;

            Items.AddRange(Query);


            for (int Month = 1; Month <= 12; Month++) {
                var NewReport = new MonthReport(Items, Year, Month);
                Reports.Add(NewReport);
            }

            Analyze();
        }

        private void Analyze() {
            CalculateOvernights();
        }


        public Dictionary<ParentingAssignment, int> Overnights { get; private set; } = new Dictionary<ParentingAssignment, int>();
        private void CalculateOvernights() {
            foreach (var item in ParentingAssignmentExtensions.Order) {
                Overnights[item] = 0;
            }

            var Values = from report in Reports
                         from value in report.Overnights
                         select value;

            foreach (var item in Values) {
                var Value = 0;
                Overnights.TryGetValue(item.Key, out Value);
                Overnights[item.Key] = Value + item.Value;
            }
        }

        public override string ToHtml() {
            var Output = new Templates.YearReportView();
            Output.Report = this;
            return Output.TransformText();
        }

    }
}
