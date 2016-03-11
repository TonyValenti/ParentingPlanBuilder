using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{

    public class AlternatingParentingAssignmentFormula : ParentingAssignmentFormula
    {
        public System.Collections.ObjectModel.ReadOnlyCollection<ParentingAssignment> Pattern { get; private set; }

        public AlternatingParentingAssignmentFormula(params ParentingAssignment[] Pattern) {
            this.Pattern = Pattern.ToList().AsReadOnly();
        }

        public override IEnumerable<ParentingAssignmentResult> Assignments(IEnumerable<DateRange> DateRange) {
            var IE = DateRange.GetEnumerator();
            var Index = 0;
            while (IE.MoveNext()) {
                var ret = new ParentingAssignmentResult();
                ret.Duration = IE.Current;
                ret.Parent = ParentingAssignment.Unknown;

                if(Pattern.Count > 0) {
                    ret.Parent = Pattern[Index];
                    Index = (Index + 1) % Pattern.Count;
                }

                yield return ret;

                
            }


        }

    }


}
