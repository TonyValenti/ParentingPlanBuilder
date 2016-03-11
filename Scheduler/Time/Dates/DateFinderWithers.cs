using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler {
    public static class DateFinderWithers {

        public static DateFinder WithCondition(this DateFinder DateFinder, TimeCondition Condition) {
            DateFinder.Conditions.Add(Condition);
            return DateFinder;
        }

        public static DateFinder WithFilter(this DateFinder DateFinder, TimeFilter Filter) {
            DateFinder.Filters.Add(Filter);
            return DateFinder;
        }

        public static DateFinder Skip(this DateFinder DateFinder, int ItemsToSkip) {
            DateFinder.Filters.Add(new SkipFilter(ItemsToSkip));
            return DateFinder;
        }

        public static DateFinder AlternatingFirst(this DateFinder DateFinder) {
            return DateFinder.AlternatingPattern(true, false);
        }

        public static DateFinder AlternatingLast(this DateFinder DateFinder) {
            return DateFinder.AlternatingPattern(false, true);
        }


        public static DateFinder AlternatingPattern(this DateFinder DateFinder, params bool[] Pattern) {
            DateFinder.Filters.Add(new AlternatingPatternFilter(Pattern));
            return DateFinder;
        }

        public static DateFinder InEvenYears(this DateFinder DateFinder) {
            DateFinder.Conditions.Add(new EvenYearsCondition());
            return DateFinder;
        }

        public static DateFinder InOddYears(this DateFinder DateFinder) {
            DateFinder.Conditions.Add(new OddYearsCondition());
            return DateFinder;
        }

        public static DateFinder On(this DateFinder DateFinder, DaysOfWeek DaysOfWeek) {
            DateFinder.Conditions.Add(new DaysOfWeekCondition(DaysOfWeek));
            return DateFinder;
        }

        public static DateFinder On(this DateFinder DateFinder, MonthsOfYear MonthsOfYear) {
            DateFinder.Conditions.Add(new MonthsOfYearCondition(MonthsOfYear));
            return DateFinder;
        }

        public static DateFinder On(this DateFinder DateFinder, WeeksOfMonth WeeksOfMonth) {
            DateFinder.Conditions.Add(new WeeksOfMonthCondition(WeeksOfMonth));
            return DateFinder;
        }

        public static DateFinder On(this DateFinder DateFinder, int DayOfTheMonth) {
            DateFinder.Conditions.Add(new DayOfMonthCondition(DayOfTheMonth));
            return DateFinder;
        }

        public static DateFinder OnTheLastDayOfTheMonth(this DateFinder DateFinder) {
            DateFinder.Conditions.Add(new LastDayOfMonthCondition());
            return DateFinder;
        }


       

        public static DateFinder At(this DateFinder DateFinder, int Hour, int Minute) {
            DateFinder.Hour = Hour;
            DateFinder.Minute = Minute;

            return DateFinder;
        }

        public static DateFinder At(this DateFinder DateFinder, int Hour) {
            return DateFinder.At(Hour, 0);
        }



    }
}
