using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class CalendarTimeline
    {
        private List<CalendarEntry> Items { get; set; } = new List<CalendarEntry>();

        public List<CalendarEntry> GetItems()
        {
            var ret = (
                from x in Items
                select x.Clone()
                ).ToList();


            return ret;
        }

        public void Add(params CalendarEntry[] Items)
        {
            AddRange(Items);
        }

        public void AddRange(IEnumerable<CalendarEntry> Items)
        {
            foreach (var item in Items)
            {
                this.Add(item);
            }
        }
        

        public int LastIntersection(CalendarEntry Item) {
            var ret = -1;
            var LowerBound = 0;
            var UpperBound = Items.Count - 1;


            while (LowerBound <= UpperBound) {
                var Position = (LowerBound + UpperBound) / 2;
                var RootItem = Items[Position];
                if (Item.Duration.Intersects(RootItem.Duration)) {
                    ret = Position;
                    LowerBound = Position + 1;

                } else if (Item.Duration.EndDate <= RootItem.Duration.EndDate) {
                    UpperBound = Position - 1;
                } else {
                    LowerBound = Position + 1;
                }
            }

            return ret;
        }


        public void Add(CalendarEntry NewItem) {
            NewItem = NewItem.Clone();

            var LastIndex = LastIntersection(NewItem);
            var FirstIndex = LastIndex;
            while (FirstIndex >= 1 && Items[FirstIndex - 1].Duration.Intersects(NewItem.Duration)) {
                FirstIndex -= 1;
            }

            var NewItems = new List<CalendarEntry>();
            for (int i = FirstIndex; i <= LastIndex && i >= 0; i++) {
                var LeftHalf = Items[i].Clone();
                LeftHalf.Duration.EndDate = NewItem.Duration.StartDate;
                if (!LeftHalf.Duration.IsEmpty) {
                    NewItems.Add(LeftHalf);
                }

                var RightHalf = Items[i].Clone();
                RightHalf.Duration.StartDate = NewItem.Duration.EndDate;
                if (!RightHalf.Duration.IsEmpty) {
                    NewItems.Add(RightHalf);
                }
            }
            NewItems.Add(NewItem);
            NewItems = (from x in NewItems orderby x.Duration select x).ToList();

            if (FirstIndex >= 0) {
                Items.RemoveRange(FirstIndex, LastIndex - FirstIndex + 1);
                Items.InsertRange(FirstIndex, NewItems);
            } else {
                var InsertAt = 0;

                while (InsertAt < Items.Count && Items[InsertAt].Duration.EndDate <= NewItem.Duration.StartDate) {
                    InsertAt += 1;
                }
                Items.InsertRange(InsertAt, NewItems);
            }
        }

        public void Operation_OLD(List<CalendarEntry> Items, CalendarEntry NewItem) {
            NewItem = NewItem.Clone();

            for (int i = Items.Count - 1; i >= 0; i--) {
                var Item = Items[i];

                if (Item.Duration.Intersects(NewItem.Duration)) {
                    Items.RemoveAt(i);

                    var RightHalf = Item.Clone();
                    RightHalf.Duration.StartDate = NewItem.Duration.EndDate;
                    if (!RightHalf.Duration.IsEmpty) {
                        Items.Insert(i, RightHalf);
                    }

                    var LeftHalf = Item.Clone();
                    LeftHalf.Duration.EndDate = NewItem.Duration.StartDate;
                    if (!LeftHalf.Duration.IsEmpty) {
                        Items.Insert(i, LeftHalf);
                    }

                }

            }

            var InsertAt = 0;

            while (InsertAt < Items.Count && Items[InsertAt].Duration.EndDate <= NewItem.Duration.StartDate) {
                InsertAt += 1;
            }
            Items.Insert(InsertAt, NewItem);



        }


        public void AddOld(CalendarEntry NewItem)
        {
            NewItem = NewItem.Clone();

            for (int i = Items.Count - 1; i >= 0 ; i--)
            {
                var Item = Items[i];

                if (Item.Duration.Intersects(NewItem.Duration))
                {
                    Items.RemoveAt(i);
                    
                    var RightHalf = Item.Clone();
                    RightHalf.Duration.StartDate = NewItem.Duration.EndDate;
                    if (!RightHalf.Duration.IsEmpty)
                    {
                        Items.Insert(i, RightHalf);
                    }

                    var LeftHalf = Item.Clone();
                    LeftHalf.Duration.EndDate = NewItem.Duration.StartDate;
                    if(!LeftHalf.Duration.IsEmpty)
                    {
                        Items.Insert(i, LeftHalf);
                    }

                }

            }
            
            var InsertAt = 0;

            while(InsertAt < Items.Count && Items[InsertAt].Duration.EndDate <= NewItem.Duration.StartDate)
            {
                InsertAt += 1;
            }
            Items.Insert(InsertAt, NewItem);
            
            
            
        }

        public void TrimBefore(DateTime Time)
        {
            for (int i = Items.Count - 1; i >= 0 ; i--)
            {
                var Item = Items[i];
                if(Item.Duration.EndDate < Time)
                {
                    Items.RemoveAt(i);
                } else if (Item.Duration.Intersects(Time))
                {

                    var NewItem = Item.Clone();
                    NewItem.Duration.StartDate = Time;

                    Items.RemoveAt(i);
                    Items.Insert(i, NewItem);
                }
            }
        }

        public void TrimAfter(DateTime Time)
        {
            for (int i = Items.Count - 1; i >= 0; i--)
            {
                var Item = Items[i];
                if (Item.Duration.StartDate > Time)
                {
                    Items.RemoveAt(i);
                }
                else if (Item.Duration.Intersects(Time))
                {

                    var NewItem = Item.Clone();
                    NewItem.Duration.EndDate = Time;

                    Items.RemoveAt(i);
                    Items.Insert(i, NewItem);
                }
            }
        }

        public void Scope(DateTime StartDate, DateTime EndDate)
        {
            TrimBefore(StartDate);
            TrimAfter(EndDate);
        }

        public void Scope(DateRange Range) {
            Scope(Range.StartDate, Range.EndDate);
        }


    }
}
