using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public static class Dvorak_Nauss
    {
        public static ParentingPlan Create()
        {
            var ParentingPlan = new ParentingPlan();
            var SchoolYear = ParentingPlan.CreateSchedule()
                .WithName("School Year")
                .WithStartDate(new DateFinder().On(MonthsOfYear.August).On(15))
                .WithEndDate(new DateFinder().On(MonthsOfYear.May).On(15))
                ;

            SchoolYear.CreateActivity()
                .WithName("Alternating Weekends")
                .WithStartDate(new DateFinder().On(DaysOfWeek.Friday).At(17))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Sunday).At(19))
                .WithParentingTime(ParentingAssignment.Pink, ParentingAssignment.Blue)
                ;

            SchoolYear.CreateActivity()
                .WithName("Time with Mother")
                .WithStartDate(new DateFinder().On(DaysOfWeek.Sunday).At(19))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Monday).At(15))
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            SchoolYear.CreateActivity()
                .WithName("Time with Mother")
                .WithStartDate(new DateFinder().On(DaysOfWeek.Monday).At(20))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Thursday).At(15))
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            SchoolYear.CreateActivity()
                .WithName("Time with Mother")
                .WithStartDate(new DateFinder().On(DaysOfWeek.Thursday).At(20))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Friday).At(17))
                .WithParentingTime(ParentingAssignment.Pink)
                ;


            SchoolYear.CreateActivity()
                .WithName("Time with Dad")
                .WithStartDate(new DateFinder().On(DaysOfWeek.Monday).At(15))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Monday).At(20))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            SchoolYear.CreateActivity()
                .WithName("Time with Dad")
                .WithStartDate(new DateFinder().On(DaysOfWeek.Thursday).At(15))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Thursday).At(20))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            var Summer = ParentingPlan.CreateSchedule()
                .WithName("Summer")
                .WithStartDate(new DateFinder().On(MonthsOfYear.May).On(15))
                .WithEndDate(new DateFinder().On(MonthsOfYear.August).On(15))
                ;

            Summer.CreateActivity()
                .WithName("Normal Time with Mom")
                .WithStartDate(new DateFinder().On(MonthsOfYear.May).On(15))
                .WithEndDate(new DateFinder().On(MonthsOfYear.August).On(15))
                .WithParentingTime(ParentingAssignment.Pink);
                ;


            Summer.CreateActivity()
               .WithName("Every Other Weekend for Dad")
               .WithStartDate(new DateFinder().On(DaysOfWeek.Friday).At(17).AlternatingPattern(true, false))
               .WithEndDate(new DateFinder().On(DaysOfWeek.Monday).At(19))
               .WithParentingTime(ParentingAssignment.Blue)
               ;

            var Thursdays = 
                Summer.CreateActivity()
               .WithName("Dad's Summer Thursdays")
               .WithStartDate(new DateFinder().On(DaysOfWeek.Thursday).At(17).AlternatingPattern(false, true))
               .WithEndDate(new DateFinder().On(DaysOfWeek.Thursday).At(20))
               .WithParentingTime(ParentingAssignment.Blue)
               ;



            var Holidays = ParentingPlan.CreateSchedule()
                .WithName("Holidays")
                .WithStartDate(new DateFinder().On(MonthsOfYear.January).On(1))
                .WithEndDate(new DateFinder().On(MonthsOfYear.January).On(1))
                ;

            Holidays.CreateActivity()
                .WithName("Easter")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Saturday).At(8),
                    TimeAdjustmentMode.Before,
                    Days.Easter
                    )
                .WithEndDate(Days.Easter.At(18))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Memorial Day Weekend")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Friday).At(18),
                    TimeAdjustmentMode.Before,
                    Days.MemorialDay
                    )
                .WithEndDate(Days.MemorialDay.At(18))
                .WithParentingTime(ParentingAssignment.Blue)
                ;


            Holidays.CreateActivity()
                .WithName("Fourth of July")
                .WithStartDate(new DateFinder().On(MonthsOfYear.July).On(4).At(10))
                .WithEndDate(new DateFinder().On(MonthsOfYear.July).On(5).At(8))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Labor Day Weekend")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Friday).At(18),
                    TimeAdjustmentMode.Before,
                    Days.LaborDay
                    )
                .WithEndDate(Days.LaborDay.At(18))
                .WithParentingTime(ParentingAssignment.Pink)
                ;
                

            Holidays.CreateActivity()
                .WithName("Mom's Thanksgiving")
                .WithStartDate(Days.Thanksgiving.InOddYears().At(10))
                .WithEndDate(Days.Thanksgiving.At(20))
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Dad's Thanksgiving")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Wednesday).At(17),
                    TimeAdjustmentMode.Before,
                    Days.Thanksgiving.InEvenYears())
                .WithEndDate(Days.Thanksgiving.At(20))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Christmas Eve")
                .WithStartDate(Days.ChristmasEve.At(10))
                .WithEndDate(Days.ChristmasDay.At(10))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Christmas")
                .WithStartDate(Days.ChristmasDay.At(10))
                .WithEndDate(new DateFinder().On(MonthsOfYear.December).On(26))
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("New Years")
                .WithStartDate(Days.NewYearsEve.At(18))
                .WithEndDate(Days.NewYearsDay.At(18))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;


            Holidays.CreateActivity()
                .WithName("Father's Day")
                .WithStartDate(Days.FathersDay.At(8))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Monday).At(8))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Mother's Day")
                .WithStartDate(Days.MothersDay.At(8))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Monday).At(8))
                .WithParentingTime(ParentingAssignment.Pink)
                ;



            return ParentingPlan;

        }
    }
}
