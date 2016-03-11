using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler.Tests
{
    public static class CalendarEntries
    {
        private static string GetName([System.Runtime.CompilerServices.CallerMemberName] string MemberName = "")
        {
            return MemberName;
        }

        public static CalendarEntry Day_1_3 {
            get {
                return new CalendarEntry()
                {
                    Name = GetName(),
                    Duration = DateRanges.Day_1_3
                };
            }
        }

        public static CalendarEntry Day_1_5 {
            get {
                return new CalendarEntry()
                {
                    Name = GetName(),
                    Duration = DateRanges.Day_1_5
                };
            }
        }

        public static CalendarEntry Day_2_4 {
            get {
                return new CalendarEntry()
                {
                    Name = GetName(),
                    Duration = DateRanges.Day_2_4
                };
            }
        }

        public static CalendarEntry Day_3_5 {
            get {
                return new CalendarEntry()
                {
                    Name = GetName(),
                    Duration = DateRanges.Day_3_5
                };
            }
        }


    }
}
