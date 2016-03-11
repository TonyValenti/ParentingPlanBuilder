using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public static class CurrentParentingPlan
    {
        public static ParentingPlan Create()
        {
            var ParentingPlan = new ParentingPlan();
            var SchoolYear = ParentingPlan.CreateSchedule()
                .WithName("School Year")
                .WithStartDate(new DateFinder()
                    .On(MonthsOfYear.August)
                    .On(15)
                    )
                .WithEndDate(new DateFinder()
                    .On(MonthsOfYear.May)
                    .On(15)
                    )
                
                .WithStartDate(new DateFinder()
                    .On(MonthsOfYear.January)
                    .On(1)
                    )
                .WithEndDate(new DateFinder()
                    .On(MonthsOfYear.January)
                    .On(1))
                ;


            var TimeWithDad = SchoolYear.CreateActivity()
                .WithName("Time with Dad")
                .WithParentingTime(ParentingAssignment.Blue)
                .WithStartDate(new DateFinder()
                    .On(DaysOfWeek.Sunday)
                    .At(8)
                    )
                .WithEndDate(new DateFinder()
                    .On(DaysOfWeek.Wednesday)
                    .At(15)
                    )
                ;

            SchoolYear.CreateActivity()
                .WithName("Time with Mom")
                .WithParentingTime(ParentingAssignment.Pink)
                .WithStartDate(new DateFinder()
                    .On(DaysOfWeek.Wednesday)
                    .At(15)
                    )
                .WithEndDate(new DateFinder()
                    .On(DaysOfWeek.Sunday)
                    .At(8)
                    )
                ;

            SchoolYear.CreateActivity()
                .WithName("Special Saturday with Dad")
                .WithParentingTime(ParentingAssignment.Blue)
                .WithStartDate(new DateFinder()
                    .On(WeeksOfMonth.First)
                    .On(DaysOfWeek.Saturday)
                    .At(9)
                    )
                .WithEndDate(new DateFinder()
                    .On(DaysOfWeek.Sunday)
                    .At(8)
                    )
                ;


            var Summer = ParentingPlan.CreateSchedule()
                .WithName("Summer")
                .WithStartDate(new DateFinder()
                    .On(MonthsOfYear.May)
                    .On(15)
                    )
                .WithEndDate(new DateFinder()
                    .On(MonthsOfYear.August)
                    .On(15)
                    )
                ;

            var Holidays = ParentingPlan.CreateSchedule()
                .WithName("Holidays")
                .WithStartDate(new DateFinder()
                    .On(MonthsOfYear.January)
                    .On(1))
                .WithEndDate(new DateFinder()
                    .On(MonthsOfYear.January)
                    .On(1)
                    )
                ;

            Holidays.CreateActivity()
                .WithName("Easter")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Saturday).At(22),
                    TimeAdjustmentMode.Before,
                    Days.Easter
                    )
                .WithEndDate(Days.Easter.At(22))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Fourth of July")
                .WithStartDate(new DateFinder()
                    .On(MonthsOfYear.July)
                    .On(3)
                    .At(22)
                    )
                .WithEndDate(new DateFinder()
                    .On(MonthsOfYear.July)
                    .On(5)
                    .At(10)
                    )
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Thanksgiving")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Wednesday).At(22),
                    TimeAdjustmentMode.Before,
                    new DateFinder().On(WeeksOfMonth.Fourth).On(DaysOfWeek.Thursday).On(MonthsOfYear.November).At(8)
                    )
                .WithEndDate(new DateFinder().On(WeeksOfMonth.Fourth).On(DaysOfWeek.Thursday).On(MonthsOfYear.November).At(22))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Christmas")
                .WithStartDate(new DateFinder().On(MonthsOfYear.December).On(24).At(22))
                .WithEndDate(new DateFinder().On(MonthsOfYear.December).On(25).At(22))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("New Years Holiday & Aurora's Birthday")
                .WithStartDate(new DateFinder().On(MonthsOfYear.December).On(32).At(22))
                .WithEndDate(new DateFinder().On(MonthsOfYear.January).On(1).At(22))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Maya's Birthday")
                .WithStartDate(new DateFinder().On(MonthsOfYear.January).On(5).At(22))
                .WithEndDate(new DateFinder().On(MonthsOfYear.January).On(6).At(22))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Father's Day")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Saturday).At(22),
                    TimeAdjustmentMode.Before,
                    new DateFinder().On(WeeksOfMonth.Third).On(DaysOfWeek.Sunday).On(MonthsOfYear.June).At(8, 00)
                    )
                .WithEndDate(new DateFinder().On(WeeksOfMonth.Third).On(DaysOfWeek.Sunday).On(MonthsOfYear.June).At(22))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Mothers's Day")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Saturday).At(22),
                    TimeAdjustmentMode.Before,
                    new DateFinder().On(WeeksOfMonth.Second).On(DaysOfWeek.Sunday).On(MonthsOfYear.May).At(8)
                    )
                .WithEndDate(new DateFinder().On(WeeksOfMonth.Second).On(DaysOfWeek.Sunday).On(MonthsOfYear.May).At(22))
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Tony's Birthday")
                .WithStartDate(new DateFinder().On(MonthsOfYear.September).On(17).At(22))
                .WithEndDate(new DateFinder().On(MonthsOfYear.September).At(18).At(22))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Hannah's Birthday")
                .WithStartDate(new DateFinder().On(MonthsOfYear.January).On(1).At(22))
                .WithEndDate(new DateFinder().On(MonthsOfYear.January).On(2).At(22))
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            return ParentingPlan;

        }
    }
}
