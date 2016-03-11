using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public abstract class ParentingAssignmentFormula
    {
        public abstract IEnumerable<ParentingAssignmentResult> Assignments(IEnumerable<DateRange> DateRange);

    }

    


}
