using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler {
    public abstract class TimeCondition {
        public bool Enabled { get; set; }

        public bool Matches(DateTime Time) {
            var ret = true;
            if (Enabled) {
                ret = MatchesInternal(Time);
            }

            return ret;
        }

        protected abstract bool MatchesInternal(DateTime Time);

        public TimeCondition() {
            this.Enabled = true;
        }

    }

    public class EvenYearsCondition : TimeCondition {
        protected override bool MatchesInternal(DateTime Time) {
            return Time.Year % 2 == 0;
        }
    }

    public class OddYearsCondition : TimeCondition {
        protected override bool MatchesInternal(DateTime Time) {
            return Time.Year % 2 == 1;
        }
    }

    public class DaysOfWeekCondition : TimeCondition {
        public DaysOfWeek DaysOfWeek { get; set; }

        protected override bool MatchesInternal(DateTime Time) {
            return DaysOfWeek.Matches(Time);
        }

        public DaysOfWeekCondition() {
            this.DaysOfWeek = DaysOfWeek.Every;
        }

        public DaysOfWeekCondition(DaysOfWeek DaysOfWeek) {
            this.DaysOfWeek = DaysOfWeek;
        }

    }

    public class MonthsOfYearCondition : TimeCondition {
        public MonthsOfYear MonthsOfYear { get; set; }

        protected override bool MatchesInternal(DateTime Time) {
            return MonthsOfYear.Matches(Time);
        }

        public MonthsOfYearCondition() {
            this.MonthsOfYear = MonthsOfYear.Every;
        }

        public MonthsOfYearCondition(MonthsOfYear MonthsOfYear) {
            this.MonthsOfYear = MonthsOfYear;
        }
    }

    public class WeeksOfMonthCondition : TimeCondition {
        public WeeksOfMonth WeekOfMonth { get; set; }

        protected override bool MatchesInternal(DateTime Time) {
            return WeekOfMonth.Matches(Time);
        }

        public WeeksOfMonthCondition() {
            this.WeekOfMonth = WeeksOfMonth.Every;
        }

        public WeeksOfMonthCondition(WeeksOfMonth WeekOfMonth) {
            this.WeekOfMonth = WeekOfMonth;
        }
    }

    public class DayOfMonthCondition : TimeCondition {
        public int DayOfMonth { get; set; }

        protected override bool MatchesInternal(DateTime Time) {
            return Time.Day == DayOfMonth;
        }

        public DayOfMonthCondition() {
            this.DayOfMonth = 1;
        }

        public DayOfMonthCondition(int DayOfMonth) {
            this.DayOfMonth = DayOfMonth;
        }
    }

    public class LastDayOfMonthCondition : TimeCondition {
        protected override bool MatchesInternal(DateTime Time) {
            var NewTime = Time.AddDays(1);
            return NewTime.Month != Time.Month;
        }
    }

    public class EasterTimeCondition : TimeCondition {
        protected override bool MatchesInternal(DateTime Time) {
            var Easter = EasterSunday(Time.Year);

            return Easter.Date == Time.Date;
        }

        private DateTime EasterSunday(int year) {
            int day = 0;
            int month = 0;

            int g = year % 19;
            int c = year / 100;
            int h = (c - (int)(c / 4) - (int)((8 * c + 13) / 25) + 19 * g + 15) % 30;
            int i = h - (int)(h / 28) * (1 - (int)(h / 28) * (int)(29 / (h + 1)) * (int)((21 - g) / 11));

            day = i - ((year + (int)(year / 4) + i + 2 - c + (int)(c / 4)) % 7) + 28;
            month = 3;

            if (day > 31) {
                month++;
                day -= 31;
            }

            return new DateTime(year, month, day);
        }

    }
    
    public class YearTimeCondition : TimeCondition {
        public int Year { get; set; } = 0;

        public YearTimeCondition() {

        }

        public YearTimeCondition(int Year) {
            this.Year = Year;
        }

        protected override bool MatchesInternal(DateTime Time) {
            return Time.Year == this.Year;
        }
    }
}
