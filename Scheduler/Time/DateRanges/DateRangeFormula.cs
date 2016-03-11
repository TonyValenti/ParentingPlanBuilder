using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    

    public class DateRangeFormula 
    {
        /// <summary>
        /// This is normally when the activity begins if no begin date is specified
        /// </summary>
        public TimeFormula StartDate { get; set; }

        /// <summary>
        /// This is when the date ends
        /// </summary>
        public TimeFormula EndDate { get; set; }

        public DateRangeFormula()
        {

        }

        public DateRangeFormula(TimeFormula StartDate, TimeFormula EndDate)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public IEnumerable<DateRange> Occurances(DateTime StartDate, DateTime EndDate) {

            var Query =
                from Start in this.StartDate.Occurances(StartDate, EndDate)
                let End  = (from End in this.EndDate.Occurances(Start, DateTime.MaxValue) where End > Start select End).FirstOrDefault()
                where End != default(DateTime)
                select new DateRange(Start, End);

            return Query;

        }
        

    }

}
