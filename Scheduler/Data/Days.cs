using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler {
    public static class Days {
        public static DateFinder FathersDay {
            get {
                return new DateFinder().On(WeeksOfMonth.Third).On(DaysOfWeek.Sunday).On(MonthsOfYear.June);
            }
        }

        public static DateFinder MothersDay {
            get {
                return new DateFinder().On(WeeksOfMonth.Second).On(DaysOfWeek.Sunday).On(MonthsOfYear.May);
            }
        }

        public static DateFinder Thanksgiving {
            get {
                return new DateFinder().On(WeeksOfMonth.Fourth).On(DaysOfWeek.Thursday).On(MonthsOfYear.November);
            }
        }

        public static DateFinder MemorialDay {
            get {
                return new DateFinder().On(WeeksOfMonth.Last).On(DaysOfWeek.Monday).On(MonthsOfYear.May);
            }
        }

        public static DateFinder LaborDay {
            get {
                return new DateFinder().On(WeeksOfMonth.First).On(DaysOfWeek.Monday).On(MonthsOfYear.September);
            }
        }

        public static DateFinder ChristmasEve {
            get {
                return new DateFinder().On(MonthsOfYear.December).On(24);
            }
        }

        public static DateFinder ChristmasDay {
            get {
                return new DateFinder().On(MonthsOfYear.December).On(25);
            }
        }

        public static DateFinder NewYearsEve {
            get {
                return new DateFinder().On(MonthsOfYear.December).On(31);
            }
        }

        public static DateFinder NewYearsDay {
            get {
                return new DateFinder().On(MonthsOfYear.January).On(1);
            }
        }

        public static DateFinder Easter {
            get {
                return new DateFinder().WithCondition(new EasterTimeCondition());
            }
        }

        public static DateFinder Halloween {
            get {
                return new DateFinder().On(MonthsOfYear.October).On(31);
            }
        }

        public static DateFinder FourthOfJuly {
            get {
                return new DateFinder().On(MonthsOfYear.July).On(4);
            }
        }
    }
}
