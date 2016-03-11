using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Reporting {
    public class ExportReport : Report {

        public Report Report { get; set; }
        public ExportReport() {

        }

        public ExportReport(Report Report) {
            this.Report = Report;
        }

        public override string ToHtml() {
            var Output = new Templates.__Export();
            Output.Report = this.Report;
            return Output.TransformText();
        }

    }
}
