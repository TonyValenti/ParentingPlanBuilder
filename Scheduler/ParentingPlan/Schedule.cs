using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class Schedule
    {
        public string Name { get; set; }

        public DateRangeFormula Duration { get; set; }

        public Schedule()
        {
            Duration = new DateRangeFormula();
        }

        public List<Activity> Activities { get; private set; } = new List<Activity>();


        public string Description {
            get {
                var ret = string.Format("{0} shall last from {1} to {2}.", Name, Duration.StartDate.Description, Duration.EndDate.Description);

                return ret;
            }
        }

        public override string ToString() {
            return Description;
        }
    }
}
