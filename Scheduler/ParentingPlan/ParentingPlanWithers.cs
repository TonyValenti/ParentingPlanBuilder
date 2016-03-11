using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public static class ParentingPlanWithers
    {
        public static Schedule CreateSchedule(this ParentingPlan ParentingPlan)
        {
            var ret = new Schedule();
            ParentingPlan.Schedules.Add(ret);
            return ret;
        }

    }
}
