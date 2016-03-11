using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{

    /// <summary>
    /// This alternates parents based on whether the first activity date is in an EVEN year or ODD year.
    /// This is done so that weird things do not happen when an activity overlaps between years
    /// </summary>

    public class YearlyAlternatingParentingAssignmentFormula : ParentingAssignmentFormula
    {
        public ParentingAssignment EvenYears { get; private set; }
        public ParentingAssignment OddYears { get; private set; }

        public YearlyAlternatingParentingAssignmentFormula(ParentingAssignment EvenYears, ParentingAssignment OddYears)
        {
            this.EvenYears = EvenYears;
            this.OddYears = OddYears;
        }

        public YearlyAlternatingParentingAssignmentFormula(ParentingAssignment EvenYears)
        {
            this.EvenYears = EvenYears;

            this.OddYears = (EvenYears == ParentingAssignment.Blue ? ParentingAssignment.Pink : ParentingAssignment.Blue);
        }

        public override IEnumerable<ParentingAssignmentResult> Assignments(IEnumerable<DateRange> DateRange) {

            var Assignment = ParentingAssignment.Unknown;

            var FirstDate = DateTime.MinValue;

            var Index = 0;
            var IE = DateRange.GetEnumerator();

            while (IE.MoveNext()) {
                if(Index == 0) {
                    FirstDate = IE.Current.StartDate;
                    Assignment = (FirstDate.Year % 2 == 0 ? EvenYears : OddYears);
                }

                

                var ret = new ParentingAssignmentResult();
                ret.Duration = IE.Current;
                ret.Parent = Assignment;

                yield return ret;

                Index += 1;
            }

        }

    }


}
