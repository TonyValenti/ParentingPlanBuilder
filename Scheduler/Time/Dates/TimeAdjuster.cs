using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler {
    public class TimeAdjuster : TimeFormula {

        public override IEnumerable<DateTime> Occurances(DateTime StartDate, DateTime EndDate) {
            
            var NewEndDate = DateTime.MinValue;
            
            switch (Position) {
                case TimeAdjustmentMode.After:
                    NewEndDate = EndDate;
                    break;
                case TimeAdjustmentMode.Before:
                    NewEndDate = StartDate;
                    break;
                default:
                    break;
            }

            var Query =
                from x in Location.Occurances(StartDate, EndDate)
                let Adjusted = Offset.Occurances(x, NewEndDate).FirstOrDefault()
                where Adjusted != default(DateTime)
                select Adjusted
                ;
            
            return Query;
        }

        public TimeFormula Offset { get; set; }
        public TimeAdjustmentMode Position { get; set; }
        public TimeFormula Location { get; set; }

        public TimeAdjuster(TimeFormula Offset, TimeAdjustmentMode Position, TimeFormula Location) {
            this.Offset = Offset;
            this.Position = Position;
            this.Location = Location;
        }

        public override string Description {
            get {
                var ret = "";

                ret = string.Format("{0} {1} {2}", Offset.Description, Position, Location.Description);

                return ret;
            }
        }

    }

    public enum TimeAdjustmentMode {
        After,
        Before,
    }
}
