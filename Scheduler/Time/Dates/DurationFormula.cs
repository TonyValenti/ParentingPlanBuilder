using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class DurationFormula : TimeFormula
    {
        public int Months { get; private set; }
        public int Weeks { get; private set; }
        public int Days { get; private set; }

        public int Hour { get; private set; }
        public int Minute { get; private set; }

        public DurationFormula(int Days, int Hour, int Minute) : this(0, 0, Days, Hour, Minute) {

        }

        public DurationFormula(int Weeks, int Days, int Hour, int Minute) : this(0,Weeks, Days, Hour, Minute) {

        }

        public DurationFormula(int Months, int Weeks, int Days, int Hour, int Minute) {
            this.Months = Months;
            this.Weeks = Weeks;
            this.Days = Days;
            this.Hour = Hour;
            this.Minute = Minute;
        }


        public override IEnumerable<DateTime> Occurances(DateTime StartDate, DateTime EndDate) {
            if (this.Months != 0 || this.Weeks != 0 || this.Days != 0) {
                var Modifier = (StartDate < EndDate ? 1 : -1);
                var LowDate = (StartDate < EndDate ? StartDate : EndDate);
                var HighDate = (EndDate > StartDate ? EndDate : StartDate);

                var BaseDate = new DateTime(StartDate.Year, StartDate.Month, StartDate.Day, Hour, Minute, 0);

                do {
                    BaseDate = BaseDate.AddMonths(Months * Modifier);
                    BaseDate = BaseDate.AddDays(Weeks * 7 * Modifier);
                    BaseDate = BaseDate.AddDays(Days * Modifier);

                    if (BaseDate >= LowDate && BaseDate <= HighDate) {
                        yield return BaseDate;
                    }

                } while (BaseDate >= LowDate && BaseDate <= HighDate);

            }
        }

        public override string Description {
            get {
                var ret = "";
                var Items = new List<String>();
                if(Months >= 0) {
                    Items.Add(string.Format("{0} months"));
                }

                if (Weeks >= 0) {
                    Items.Add(string.Format("{0} weeks"));
                }

                if (Days >= 0) {
                    Items.Add(string.Format("{0} days"));
                }

                ret += Language.ListAnd(Items);

                ret += Language.AtTime(Hour, Minute);


                return ret;
            }
        }

    }
}
