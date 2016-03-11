using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public abstract class TimeFormula
    {

        public abstract IEnumerable<DateTime> Occurances(DateTime StartDate, DateTime EndDate);

        public abstract string Description { get; }

       

        public override string ToString() {
            return this.Description;
        }
    }

}
