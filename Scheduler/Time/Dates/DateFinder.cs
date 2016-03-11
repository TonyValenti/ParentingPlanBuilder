using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{

    public class DateFinder : TimeFormula
    {
        public List<TimeCondition> Conditions { get; private set; } = new List<TimeCondition>();
        public List<TimeFilter> Filters { get; private set; } = new List<TimeFilter>();

        public int Hour { get; set; }
        public int Minute { get; set; }

        public override IEnumerable<DateTime> Occurances(DateTime StartDate, DateTime EndDate) {
            var ret = ApplyConditions(StartDate, EndDate);
            foreach (var item in Filters) {
                ret = item.Filter(ret);
            }

            return ret;
        }

        protected IEnumerable<DateTime> ApplyConditions(DateTime StartDate, DateTime EndDate) {
            var Modifier = (StartDate < EndDate ? 1 : -1);
            var LowDate = (StartDate < EndDate ? StartDate : EndDate);
            var HighDate = (EndDate > StartDate ? EndDate : StartDate);

            var BaseDate = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, Hour, Minute, 0);

            do {
                if (BaseDate >= LowDate && BaseDate <= HighDate) {
                    if(Conditions.TrueForAll(x => x.Matches(BaseDate))) {
                        yield return BaseDate;
                    }
                }

                BaseDate = BaseDate.AddDays(Modifier);
            } while (BaseDate >= LowDate && BaseDate <= HighDate);

        }

        public override string Description {
            get {
                return "";
            }
        }


    }
}
