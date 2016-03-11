using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Reporting {
    public class CompleteReport : Report {

        public List<YearReport> Reports { get; private set; } = new List<YearReport>();
        public List<CalendarEntry> Items { get; private set; } = new List<CalendarEntry>();


        public CompleteReport(List<CalendarEntry> Entries, DateRange Range) {
            this.Items.AddRange(Entries);

            for (int Year = Range.StartDate.Year; Year <= Range.EndDate.Year; Year++) {
                var NewReport = new YearReport(Entries, Year);
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
            var Output = new Templates.CompleteReportOutput();
            Output.Report = this;
            return Output.TransformText();
        }

    }
}
