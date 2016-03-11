using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public static class Slobotski_Slobotski {

        public static ParentingPlan Create()
        {
            var ParentingPlan = new ParentingPlan();
            var SchoolYear = ParentingPlan.CreateSchedule()
                .WithName("School Year")
                .WithStartDate(Days.NewYearsDay)
                .WithEndDate(Days.NewYearsDay)
                ;

            SchoolYear.CreateActivity()
                .WithName("Alternating Weekends")
                .WithStartDate(new DateFinder().On(DaysOfWeek.Friday).At(17))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Monday).At(8))
                .WithParentingTime(ParentingAssignment.Blue, ParentingAssignment.Pink)
                ;

            SchoolYear.CreateActivity()
                .WithName("Mother's Parenting Time")
                .WithStartDate(new DateFinder().On(DaysOfWeek.Monday).At(8))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Tuesday).At(8))
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            SchoolYear.CreateActivity()
                .WithName("Father's Parenting Time")
                .WithStartDate(new DateFinder().On(DaysOfWeek.Wednesday).At(8))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Thursday).At(8))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            


            var Holidays = ParentingPlan.CreateSchedule()
                .WithName("Holidays")
                .WithStartDate(Days.NewYearsDay)
                .WithEndDate(Days.NewYearsDay)
                ;

            Holidays.CreateActivity()
                .WithName("Mom's Easter")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Saturday).At(19), 
                    TimeAdjustmentMode.Before, 
                    Days.Easter)
                .WithEndDate(Days.Easter.At(15))
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Dad's Easter")
                .WithStartDate(Days.Easter.At(15))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Monday).At(8))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Memorial Day Weekend")
                .WithStartDate(Days.MemorialDay.At(12))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Tuesday).At(9))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Mom's Fourth of July")
                .WithStartDate(new DateFinder().On(MonthsOfYear.July).On(3).At(9))
                .WithEndDate(Days.FourthOfJuly.At(9))
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Dad's Fourth of July")
                .WithStartDate(Days.FourthOfJuly.At(9))
                .WithEndDate(new DateFinder().On(MonthsOfYear.July).On(5).At(9))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Labor Day")
                .WithStartDate(Days.LaborDay.At(8))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Tuesday).At(9))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Halloween Day")
                .WithStartDate(Days.Halloween.At(17))
                .WithEndDate(new DateFinder().On(MonthsOfYear.November).On(1).At(9))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue);
                ;

            
            Holidays.CreateActivity()
                .WithName("Thanksgiving")
                .WithStartDate(Days.Thanksgiving.At(9))
                .WithEndDate(Days.Thanksgiving.At(19))
                .WithParentingTime(ParentingAssignment.Pink)
                ;


            Holidays.CreateActivity()
                .WithName("Mother's Christmas Eve")
                .WithStartDate(Days.ChristmasEve.At(15))
                .WithEndDate(Days.ChristmasEve.At(17, 30))
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Father's Christmas Eve")
                .WithStartDate(Days.ChristmasEve.At(17,30))
                .WithEndDate(Days.ChristmasEve.At(22))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Christmas Eve Overnight")
                .WithStartDate(Days.ChristmasEve.At(22))
                .WithEndDate(Days.ChristmasDay.At(10))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Christmas")
                .WithStartDate(Days.ChristmasDay.At(10))
                .WithEndDate(new DateFinder().On(MonthsOfYear.December).On(26))
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("December 26th")
                .WithStartDate(new DateFinder().On(MonthsOfYear.December).On(26).At(10))
                .WithEndDate(new DateFinder().On(MonthsOfYear.December).On(26).At(18))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("New Years Eve")
                .WithStartDate(Days.NewYearsEve.At(17))
                .WithEndDate(Days.NewYearsDay.At(11))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("New Years Day")
                .WithStartDate(Days.NewYearsDay.At(11))
                .WithEndDate(Days.NewYearsDay.At(19))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;




            Holidays.CreateActivity()
                .WithName("Father's Day")
                .WithStartDate(Days.FathersDay.At(9))
                .WithEndDate(Days.FathersDay.At(19))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Mother's Day")
                .WithStartDate(Days.MothersDay.At(9))
                .WithEndDate(Days.MothersDay.At(19))
                .WithParentingTime(ParentingAssignment.Pink)
                ;



            return ParentingPlan;

        }
    }
}
