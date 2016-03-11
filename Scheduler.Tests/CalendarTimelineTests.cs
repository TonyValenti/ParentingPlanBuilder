using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scheduler.Tests
{
    [TestClass]
    public class CalendarTimelineTests
    {
        [TestMethod]
        public void WarmUp()
        {

        }

        [TestMethod]
        public void Adjacent_DoesNot_Intersect()
        {
            var Timeline = new CalendarTimeline();

            var Item0 = CalendarEntries.Day_1_3;
            var Item1 = CalendarEntries.Day_3_5;

            Timeline.Add(Item0, Item1);
            var Items = Timeline.GetItems();

            //Neither of the items should be modified when they are added.
            Assert.IsTrue(Items[0].Duration == Item0.Duration);
            Assert.IsTrue(Items[1].Duration == Item1.Duration);
        }

        [TestMethod]
        public void Overlap_Contained()
        {
            var Timeline = new CalendarTimeline();

            var Item0 = CalendarEntries.Day_1_5;
            var Item1 = CalendarEntries.Day_2_4;

            Timeline.Add(Item0, Item1);
            var Items = Timeline.GetItems();

            Assert.IsTrue(Items.Count == 3);
            Assert.IsTrue(Items[0].Duration.StartDate == Item0.Duration.StartDate);
            Assert.IsTrue(Items[0].Duration.EndDate == Item1.Duration.StartDate);

            Assert.IsTrue(Items[1].Duration.StartDate == Item1.Duration.StartDate);
            Assert.IsTrue(Items[1].Duration.EndDate == Item1.Duration.EndDate);

            Assert.IsTrue(Items[2].Duration.StartDate == Item1.Duration.EndDate);
            Assert.IsTrue(Items[2].Duration.EndDate == Item0.Duration.EndDate);
        }

        [TestMethod]
        public void Overlap_Right()
        {
            var Timeline = new CalendarTimeline();

            var Item0 = CalendarEntries.Day_1_3;
            var Item1 = CalendarEntries.Day_2_4;

            Timeline.Add(Item0, Item1);

            var Items = Timeline.GetItems();

            var OrderedItems = (from x in Items orderby x.Duration select x).ToList();

            Assert.IsTrue(Items.Count == 2);

            Assert.IsTrue(Items[0].Duration.StartDate == Item0.Duration.StartDate);
            Assert.IsTrue(Items[0].Duration.EndDate == Item1.Duration.StartDate);

            Assert.IsTrue(Items[1].Duration.StartDate == Item1.Duration.StartDate);
            Assert.IsTrue(Items[1].Duration.EndDate == Item1.Duration.EndDate);

            CollectionAssert.AreEqual(OrderedItems, Items);
            
        }

        [TestMethod]
        public void Overlap_Left()
        {
            var Timeline = new CalendarTimeline();

            var Item0 = CalendarEntries.Day_2_4;
            var Item1 = CalendarEntries.Day_1_3;

            Timeline.Add(Item0, Item1);

            var Items = Timeline.GetItems();

            var OrderedItems = (from x in Items orderby x.Duration select x).ToList();

            Assert.IsTrue(Items.Count == 2);

            Assert.IsTrue(Items[0].Duration.StartDate == Item1.Duration.StartDate);
            Assert.IsTrue(Items[0].Duration.EndDate == Item1.Duration.EndDate);

            Assert.IsTrue(Items[1].Duration.StartDate == Item1.Duration.EndDate);
            Assert.IsTrue(Items[1].Duration.EndDate == Item0.Duration.EndDate);

            CollectionAssert.AreEqual(OrderedItems, Items);

        }

    }
}
