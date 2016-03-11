using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    class __Program
    {
        static void Main(string[] args)
        {
            var StartDate = new DateTime(2016, 01, 01);
            var EndDate = new DateTime(2027, 01, 01);

            var Range = new DateRange(StartDate, EndDate);

            //PARENTING PLAN ASSIGNED:
            
            //var ParentingPlan = Huff_Fisher.Create();
            //var ParentingPlan = Slobotski_Slobotski.Create();
            var ParentingPlan = Dvorak_Nauss.Create();

            //ParentingPlan = CurrentParentingPlan.Create();

            var Events = ParentingPlan.Generate(StartDate, EndDate);

            var EventItems = Events.ToList();

            var Timeline = new CalendarTimeline();
            Timeline.Add(CalendarEntry.Unknown(Range));

            Timeline.AddRange(EventItems);
            Timeline.Scope(Range);
            var Items = Timeline.GetItems();

            var C = new Reporting.CompleteReport(Items, Range);

            var Output = new Reporting.ExportReport(C).ToHtml();

            var Q = (
                from x in ParentingPlan.Schedules
                from y in x.Activities
                select y.Description

                ).ToList();

            System.IO.File.WriteAllText(@"C:\Users\Administrator\Desktop\ParentingPlan.html", Output);

        }

 
    }
}
