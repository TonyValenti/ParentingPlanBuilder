﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Tests
{
    public static class DateRanges
    {
        public static DateRange Null {
            get {
                return null;
            }
        }

        public static DateRange EmptyNow {
            get {
                var T = DateTime.Now;
                return new DateRange(T, T);
            }
        }

        public static DateRange EmptyReverse_1_3 {
            get {
                return new DateRange(Day_1_3.EndDate, Day_1_3.StartDate);
            }
        }

        public static DateRange EmptyReverse_3_5 {
            get {
                return new DateRange(Day_3_5.EndDate, Day_3_5.StartDate);
            }
        }

        public static DateRange Day_1_3 {
            get {
                return new DateRange(
                "2016-01-01 8:00am",
                "2016-01-03 8:00am"
                );
            }
        }

        public static DateRange Day_1_5 {
            get {
                return new DateRange(
                "2016-01-01 8:00am",
                "2016-01-05 8:00am"
                );
            }
        }

        public static DateRange Day_2_4 {
            get {
                return new DateRange(
                "2016-01-02 8:00am",
                "2016-01-04 8:00am"
                );
            }
        }

        public static DateRange Day_3_5 {
            get {
                return new DateRange(
                "2016-01-03 8:00am",
                "2016-01-05 8:00am"
                );
            }
        }


    }
}
