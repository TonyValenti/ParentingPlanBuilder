using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler {
    public abstract class TimeFilter {
        public abstract IEnumerable<DateTime> Filter(IEnumerable<DateTime> Source);
    }
    
    public class SkipFilter : TimeFilter {

        public int ItemsToSkip { get; set; } = 0;

        public SkipFilter() {
            
        }

        public SkipFilter(int ItemsToSkip) {
            this.ItemsToSkip = ItemsToSkip;
        }

        public override IEnumerable<DateTime> Filter(IEnumerable<DateTime> Source) {
            return Source.Skip(ItemsToSkip);
        }
    }

    public class AlternatingPatternFilter : TimeFilter {
        public List<bool> Pattern { get; private set; } = new List<bool>();

        public AlternatingPatternFilter() {

        }

        public AlternatingPatternFilter(params bool[] Pattern) {
            this.Pattern.AddRange(Pattern);
        }

        public AlternatingPatternFilter(IEnumerable<bool> Pattern) {
            this.Pattern.AddRange(Pattern);
        }

        public override IEnumerable<DateTime> Filter(IEnumerable<DateTime> Source) {
            var Index = 0;
            var IE = Source.GetEnumerator();
            while (IE.MoveNext()) {
                var ShouldRet = true;

                if (Pattern.Count > 0) {
                    ShouldRet = Pattern[Index];
                    Index = (Index + 1) % Pattern.Count;
                }

                if (ShouldRet) {
                    yield return IE.Current;
                }
            }
        }
    }

}
