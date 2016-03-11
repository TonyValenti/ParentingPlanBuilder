﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler {
    [Flags]
    public enum MonthsOfYear {
        None = 0,
        January = 1,
        February = 2,
        March = 4,
        April = 8,
        May = 16,
        June = 32,
        July = 64,
        August = 128,
        September = 256,
        October = 512,
        November = 1024,
        December = 2048,

        Every = January | February | March | April | May | June | July | August | September | October | November | December
    }

    public static class MonthsOfYearExtensions {
        private static readonly MonthsOfYear[] Order = new MonthsOfYear[] {
                MonthsOfYear.January, MonthsOfYear.February, MonthsOfYear.March, MonthsOfYear.April
                , MonthsOfYear.May, MonthsOfYear.June, MonthsOfYear.July, MonthsOfYear.August
                , MonthsOfYear.September, MonthsOfYear.October, MonthsOfYear.November, MonthsOfYear.December
            };

        public static List<MonthsOfYear> GetValues(this MonthsOfYear Flags) {
            var ret = new List<MonthsOfYear>(Order.Length);
            foreach (var item in Order) {
                if (Flags.HasFlag(item)) {
                    ret.Add(item);
                }
            }

            return ret;
        }

        public static bool Matches(this MonthsOfYear Flags, DateTime DateTime) {
            return (Flags & GetMonth(DateTime.Month)) != MonthsOfYear.None;
        }

        public static MonthsOfYear GetMonth(int Month) {
            return Order[Month - 1];
        }


        public static int GetMonth(this MonthsOfYear Month) {
            var ret = 0;

            var FlagValues = GetValues(Month);
            if (FlagValues.Count > 0) {
                for (int i = 0; i < Order.Length; ++i) {
                    if (Order[i] == FlagValues[0]) {
                        ret = i + 1;
                        break;
                    }
                }
            }

            return ret;
        }

       

    }
}