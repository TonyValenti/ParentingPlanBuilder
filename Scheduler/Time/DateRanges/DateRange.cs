using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class DateRange : IComparable<DateRange>, IEqualityComparer<DateRange>
    {
        public TimeSpan ToTimeSpan() {
            var ret = default(TimeSpan);
            if (!IsEmpty) {
                ret = EndDate - StartDate;
            }
            return ret;
        }
        
        // >=
        public DateTime StartDate { get; set; }

        // <
        public DateTime EndDate { get; set; }

        public override string ToString()
        {
            return string.Format(
                "{0:yyyy-MM-dd @ HH:mm:ss} TILL {1:yyyy-MM-dd @ HH:mm:ss}",
                StartDate,
                EndDate
                );
        }

        public DateRange Clone()
        {
            return new DateRange(this);
        }

        public DateRange()
        {

        }

        public DateRange(DateTime StartDate, string EndDate)
        {
            this.StartDate = StartDate;
            this.EndDate = DateTime.Parse(EndDate);
        }

        public DateRange(string StartDate, DateTime EndDate)
        {
            this.StartDate = DateTime.Parse(StartDate);
            this.EndDate = EndDate;
        }

        public DateRange(string StartDate, string EndDate)
        {
            this.StartDate = DateTime.Parse(StartDate);
            this.EndDate = DateTime.Parse(EndDate);
        }

        public DateRange(DateTime StartDate, DateTime EndDate)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public DateRange(DateRange Source) : this(Source.StartDate, Source.EndDate)
        {

        }


        public bool IsEmpty {
            get {
                return StartDate >= EndDate;
            }
        }

        public DateRange Intersection(DateRange Item) {
            return Intersection(this, Item);
        }

        public bool Intersects(DateRange Item)
        {
            return Intersects(this, Item);
        }

        public bool Intersects(DateTime DateTime)
        {
            return DateTime >= StartDate && DateTime < EndDate;
        }

        /*
            We have one of the two scenarios below

                /------------\
                |            |
            /---------\
            |         |

                /------------\
                |            |
                        /---------\
                        |         |


            */
        public static DateRange Intersection(DateRange X, DateRange Y) {
            DateRange ret = null;

            if(! X.IsEmpty && !Y.IsEmpty) {

                var BiggestStart = (X.StartDate >= Y.StartDate ? X.StartDate : Y.StartDate);
                var SmallestFinish = (X.EndDate <= Y.EndDate ? X.EndDate : Y.EndDate);

                var NewItem = new DateRange(BiggestStart, SmallestFinish);

                if (!NewItem.IsEmpty) {
                    ret = NewItem;
                }
                
            }

            return ret;
        }

        public static bool Intersects(DateRange X, DateRange Y)
        {
            return Intersection(X, Y) != null;
        }

        

        public static int Compare(DateRange X, DateRange Y)
        {
            /*
            Logic:
            Empty items have no value and should always come first.
            Two empty items are always equal.
            If two items have the same start date, the one that ends first comes first.
            If two items are not empty, the one that has the earliest start date comes first.
            */

            //If X or Y is empty, make them null.
            X = (Object.ReferenceEquals(X, null) || X.IsEmpty ? null : X);
            Y = (Object.ReferenceEquals(Y, null) || Y.IsEmpty ? null : Y);


            int ret = 0;
            if (Object.ReferenceEquals(X, null) && Object.ReferenceEquals(Y, null)) {
                ret = 0;
            } else if (Object.ReferenceEquals(X, null) && !Object.ReferenceEquals(Y, null))
            {
                ret = -1;
            } else if (!Object.ReferenceEquals(X, null) && Object.ReferenceEquals(Y, null))
            {
                ret = 1;
            } else
            {
                if (X.StartDate < Y.StartDate) {
                    ret = -1;
                } else if (X.StartDate > Y.StartDate)
                {
                    ret = 1;
                } else
                {
                    if (X.EndDate < Y.EndDate)
                    {
                        ret = -1;
                    } else if (X.EndDate > Y.EndDate)
                    {
                        ret = 1;
                    } else
                    {
                        ret = 0;
                    }
                }
            
            }
            

            return ret;
        }

        public int CompareTo(DateRange other)
        {
            return Compare(this, other);
        }

        public static bool operator==(DateRange x, DateRange y)
        {
            return (Compare(x, y) == 0);
        }

        public static bool operator!=(DateRange x, DateRange y)
        {
            return !(Compare(x,y) == 0);
        }

        public static bool operator>(DateRange x, DateRange y)
        {
            return (Compare(x, y) > 0);
        }

        public static bool operator <(DateRange x, DateRange y)
        {
            return (Compare(x, y) < 0);
        }

        public static bool operator <=(DateRange x, DateRange y)
        {
            return (Compare(x, y) <= 0);
        }

        public static bool operator >=(DateRange x, DateRange y)
        {
            return (Compare(x, y) >= 0);
        }

        public override int GetHashCode()
        {
            var ret = 0;
            if (!this.IsEmpty)
            {
                ret = this.StartDate.GetHashCode() ^ this.EndDate.GetHashCode();
            }

            return ret;
        }

        public override bool Equals(object obj)
        {
            var V = obj as DateRange;

            return this == V;
        }

        public bool Equals(DateRange x, DateRange y)
        {
            return x == y;
        }

        public int GetHashCode(DateRange obj)
        {
            return obj.GetHashCode();
        }
    }
}
