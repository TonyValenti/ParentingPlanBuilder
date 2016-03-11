using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public enum ParentingAssignment
    {
        Unknown,
        Pink,
        Blue,
       
    }

    public static class ParentingAssignmentExtensions {
        public static readonly ParentingAssignment[] Order = new ParentingAssignment[] {
            ParentingAssignment.Unknown,
            ParentingAssignment.Pink,
            ParentingAssignment.Blue,
            };
    }
}
