using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public static class ProposedParentingPlan
    {
        public static ParentingPlan Create()
        {
            var ParentingPlan = new ParentingPlan();
            var SchoolYear = ParentingPlan.CreateSchedule()
                .WithName("School Year")
                .WithStartDate(new DateFinder().On(MonthsOfYear.August).On(15))
                .WithEndDate(new DateFinder().On(MonthsOfYear.May).On(15))
                
                .WithStartDate(new DateFinder().On(MonthsOfYear.January).On(1))
                .WithEndDate(new DateFinder().On(MonthsOfYear.January).On(1))
                ;


            var TimeWithDad = SchoolYear.CreateActivity()
                .WithName("Dad's Parenting Time")
                .WithParentingTime(ParentingAssignment.Blue)
                .WithStartDate(new DateFinder().On(DaysOfWeek.Sunday).At(8))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Wednesday).At(15))
                ;

            SchoolYear.CreateActivity()
                .WithName("Mom's Parenting Time")
                .WithParentingTime(ParentingAssignment.Pink)
                .WithStartDate(new DateFinder().On(DaysOfWeek.Wednesday).At(15))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Sunday).At(8))
                ;

            SchoolYear.CreateActivity()
                .WithName("Dad's Special Saturday")
                .WithParentingTime(ParentingAssignment.Blue)
                .WithStartDate(new DateFinder().On(WeeksOfMonth.Second).On(DaysOfWeek.Wednesday).At(15))
                .WithEndDate(new DateFinder().On(WeeksOfMonth.Third).On(DaysOfWeek.Wednesday).At(15))
                ;


            var Summer = ParentingPlan.CreateSchedule()
                .WithStartDate(new DateFinder().On(MonthsOfYear.May).On(15))
                .WithEndDate(new DateFinder().On(MonthsOfYear.August).On(15))
                ;

            var Holidays = ParentingPlan.CreateSchedule()
                .WithName("Holidays")
                .WithStartDate(new DateFinder().On(MonthsOfYear.January).On(1))
                .WithEndDate(new DateFinder().On(MonthsOfYear.January).On(1))
                ;

            //Start on the wednesday before.
            //End on the Wednesday after.
            Holidays.CreateActivity()
                .WithName("Easter")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Wednesday).At(15),
                    TimeAdjustmentMode.Before,
                    Days.Easter
                    )
                .WithEndDate(new DateFinder().On(DaysOfWeek.Wednesday).At(15))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Fourth of July")
                .WithStartDate(new DateFinder().On(MonthsOfYear.July).On(3).At(15))
                .WithEndDate(new DateFinder().On(MonthsOfYear.July).On(5).At(15))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;


            //Made thanksgiving start on the Wednesay before thanksgiving.
            //This prevents back and forth.
            Holidays.CreateActivity()
                .WithName("Thanksgiving")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Wednesday).At(15),
                    TimeAdjustmentMode.Before,
                    new DateFinder().On(WeeksOfMonth.Fourth).On(DaysOfWeek.Thursday).On(MonthsOfYear.November).At(8)
                    )
                .WithEndDate(
                    new DateFinder().On(DaysOfWeek.Friday).At(15),
                    TimeAdjustmentMode.After,
                    new DateFinder().On(WeeksOfMonth.Fourth).On(DaysOfWeek.Thursday).On(MonthsOfYear.November).At(22)
                )
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Christmas")
                .WithStartDate(new DateFinder().On(MonthsOfYear.December).On(24).At(22))
                .WithEndDate(new DateFinder().On(MonthsOfYear.December).On(25).At(22))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("New Years Holiday")
                .WithStartDate(new DateFinder().On(MonthsOfYear.December).On(30).At(22))
                .WithEndDate(new DateFinder().On( MonthsOfYear.January).On(1).At(22))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue);

            Holidays.CreateActivity()
                .WithName("Child1's Birthday")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Friday).At(15),
                    TimeAdjustmentMode.After,
                    new DateFinder().On(MonthsOfYear.January).On(5).At(15)
                )
                .WithEndDate(
                    new DateFinder().On(DaysOfWeek.Sunday).At(8)
                )
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Child1's Birthday")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Friday).At(15),
                    TimeAdjustmentMode.After,
                    new DateFinder().On(MonthsOfYear.December).On(31).At(15)
                )
                .WithEndDate(
                    new DateFinder().On(DaysOfWeek.Sunday).At(8)
                )
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;


            //Start on the Wednesday before.
            //Last till the wednesday after.
            Holidays.CreateActivity()
                .WithName("Father's Day")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Wednesday).At(15),
                    TimeAdjustmentMode.Before,
                    new DateFinder().On(WeeksOfMonth.Third).On(DaysOfWeek.Sunday).On(MonthsOfYear.June).At(8)
                    )
                .WithEndDate(new DateFinder().On(DaysOfWeek.Wednesday).At(15))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            
            Holidays.CreateActivity()
                .WithName("Mothers's Day")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Wednesday).At(15),
                    TimeAdjustmentMode.Before,
                    new DateFinder().On(WeeksOfMonth.Second).On(DaysOfWeek.Sunday).On(MonthsOfYear.May).At(8)
                    )
                .WithEndDate(new DateFinder().On(DaysOfWeek.Wednesday).At(15))
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Dad's Birthday")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Friday).At(15),
                    TimeAdjustmentMode.After,
                    new DateFinder().On(MonthsOfYear.September).On(18).At(15)
                )
                .WithEndDate(
                    new DateFinder().On(DaysOfWeek.Sunday).At(8)
                )
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Mom's Birthday")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Friday).At(15),
                    TimeAdjustmentMode.After,
                    new DateFinder().On(MonthsOfYear.January).On(2).At(15)
                )
                .WithEndDate(
                    new DateFinder().On(DaysOfWeek.Sunday).At(8)
                )
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            return ParentingPlan;

        }
    }
}
