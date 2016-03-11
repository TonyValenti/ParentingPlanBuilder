using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public static class Huff_Fisher {

        public static ParentingPlan Create()
        {
            var ParentingPlan = new ParentingPlan();
            var SchoolYear = ParentingPlan.CreateSchedule()
                .WithName("School Year")
                .WithStartDate(Days.NewYearsDay)
                .WithEndDate(Days.NewYearsDay)
                ;

            SchoolYear.CreateActivity()
                .WithName("Mother's Parenting Time")
                .WithStartDate(Days.NewYearsDay)
                .WithEndDate(Days.NewYearsDay)
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            SchoolYear.CreateActivity()
                .WithName("Father's Monday Afternoon")
                .WithStartDate(new DateFinder().On(DaysOfWeek.Monday).At(16))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Monday).At(20))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            SchoolYear.CreateActivity()
               .WithName("Father's Tuesday Afternoon")
               .WithStartDate(new DateFinder().On(DaysOfWeek.Tuesday).At(16))
               .WithEndDate(new DateFinder().On(DaysOfWeek.Tuesday).At(20))
               .WithParentingTime(ParentingAssignment.Blue)
               ;

            SchoolYear.CreateActivity()
                .WithName("Father's Weekend")
                .WithStartDate(new DateFinder().On(DaysOfWeek.Friday).At(17).AlternatingFirst())
                .WithEndDate(new DateFinder().On(DaysOfWeek.Sunday).At(20))
                .WithParentingTime(ParentingAssignment.Blue)
                ;


            var Holidays = ParentingPlan.CreateSchedule()
                .WithName("Holidays")
                .WithStartDate(Days.NewYearsDay)
                .WithEndDate(Days.NewYearsDay)
                ;

            Holidays.CreateActivity()
                .WithName("Easter")
                .WithStartDate(Days.Easter.At(9))
                .WithEndDate(Days.Easter.At(17))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Memorial Day Weekend")
                .WithStartDate(Days.MemorialDay.At(8))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Tuesday).At(8))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Labor Day Weekend")
                .WithStartDate(Days.LaborDay.At(8))
                .WithEndDate(new DateFinder().On(DaysOfWeek.Tuesday).At(8))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Halloween Day (M-F)")
                .WithStartDate(Days.Halloween.On(DaysOfWeek.Weekday).At(17))
                .WithEndDate(Days.Halloween.At(20))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue);
                ;

            Holidays.CreateActivity()
                .WithName("Halloween Day (Weekend)")
                .WithStartDate(Days.Halloween.On(DaysOfWeek.Weekend).At(9))
                .WithEndDate(new DateFinder().On(MonthsOfYear.November).On(1).At(8))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue);
            ;


            Holidays.CreateActivity()
                .WithName("Mom's Thanksgiving")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Wednesday).At(20), 
                    TimeAdjustmentMode.Before,
                    Days.Thanksgiving
                    )
                .WithEndDate(new DateFinder().On(DaysOfWeek.Saturday).At(9))
                .WithParentingTime(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Dad's Thanksgiving")
                .WithStartDate(
                    new DateFinder().On(DaysOfWeek.Saturday).At(9),
                    TimeAdjustmentMode.After,
                    Days.Thanksgiving
                    )

                .WithEndDate(new DateFinder().On(DaysOfWeek.Sunday).At(20))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Christmas Eve")
                .WithStartDate(Days.ChristmasEve.At(13))
                .WithEndDate(Days.ChristmasDay.At(10))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("Christmas")
                .WithStartDate(Days.ChristmasDay.At(10))
                .WithEndDate(Days.ChristmasDay.At(20))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("New Years Eve")
                .WithStartDate(Days.NewYearsEve.At(8))
                .WithEndDate(Days.NewYearsDay.At(8))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Pink)
                ;

            Holidays.CreateActivity()
                .WithName("New Years Day")
                .WithStartDate(Days.NewYearsDay.At(8))
                .WithEndDate(Days.NewYearsDay.At(20))
                .WithParentingTimeAlternatingByYear(ParentingAssignment.Blue)
                ;




            Holidays.CreateActivity()
                .WithName("Father's Day")
                .WithStartDate(Days.FathersDay.At(9))
                .WithEndDate(Days.FathersDay.At(20))
                .WithParentingTime(ParentingAssignment.Blue)
                ;

            Holidays.CreateActivity()
                .WithName("Mother's Day")
                .WithStartDate(Days.MothersDay.At(9))
                .WithEndDate(Days.MothersDay.At(20))
                .WithParentingTime(ParentingAssignment.Pink)
                ;



            return ParentingPlan;

        }
    }
}
