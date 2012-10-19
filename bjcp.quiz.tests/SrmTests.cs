using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace bjcp.quiz.tests
{
    [TestFixture]
    public class SrmTests
    {
        private SrmComparer comparer;
        [SetUp]
        public void Setup()
        {
            var orderedSrms = GetOrderedListOfSrm();
            comparer = new SrmComparer(orderedSrms);
        }

        [Test]
        public void srm_straw_isSetProperly()
        {
            var straw = new Srm("Straw", 2, 3);
            Assert.AreEqual("Straw", straw.Name);
            Assert.AreEqual(2, straw.Low);
            Assert.AreEqual(3, straw.High);
        }

        [Test]
        public void srm_yellow_isSetProperly()
        {
            var yellow = new Srm("Yellow", 3, 4);
            Assert.AreEqual("Yellow", yellow.Name);
            Assert.AreEqual(3, yellow.Low);
            Assert.AreEqual(4, yellow.High);
        }

        [Test]
        public void srm_yellow_stringIsDisplayed()
        {
            var yellow = new Srm("Yellow", 3, 4);
            Assert.AreEqual("Yellow - 3, 4", yellow.ToString());
        }

        [Test]
        public void srm_black_stringIsDisplayed()
        {
            var black = new Srm("Black", 30);
            Assert.AreEqual("Black - 30+", black.ToString());
        }

        [Test]
        public void srmComparer_initialized_hasCorrectAmountOfItems()
        {
            Assert.AreEqual(12, comparer.SrmItemsOrganized.Count());
        }

        [Test]
        public void srm_yellow_equalsOtherYellow()
        {
            var srm1 = new Srm("Yellow", 3, 4);
            var srm2 = new Srm("Yellow", 3, 4);

            Assert.IsTrue(srm1.Equals(srm2));
        }


        [Test]
        public void srmComparer_whenIncorrectOrder_returnsFalse()
        {
            comparer.SrmItems = GetUnorderedListofSrm();
            Assert.AreEqual(false, comparer.IsCorrect());
        }

        [Test]
        public void srmComparer_whenCorrectOrder_returnsTrue()
        {
            comparer.SrmItems.Add(new Srm("Straw", 2, 3));
            comparer.SrmItems.Add(new Srm("Yellow", 3, 4));
            comparer.SrmItems.Add(new Srm("Gold", 5, 6));
            comparer.SrmItems.Add(new Srm("Amber", 6, 9));
            comparer.SrmItems.Add(new Srm("Deep Amber/Light Copper", 10, 14));
            comparer.SrmItems.Add(new Srm("Copper", 14, 17));
            comparer.SrmItems.Add(new Srm("Deep Copper/Light Brown", 17, 18));
            comparer.SrmItems.Add(new Srm("Brown", 19, 22));
            comparer.SrmItems.Add(new Srm("Dark Brown", 22, 30));
            comparer.SrmItems.Add(new Srm("Very Dark Brown", 30, 35));
            comparer.SrmItems.Add(new Srm("Black", 30));
            comparer.SrmItems.Add(new Srm("Black, Opaque", 40));
            Assert.IsTrue(comparer.IsCorrect());
        }

        [Test]
        public void srmComparer_whenIncorrectName_returnsFalse()
        {
            var srms = new List<Srm>();
            srms.Add(new Srm("Not Straw", 2, 3));
            srms.Add(new Srm("Yellow", 3, 4));
            srms.Add(new Srm("Gold", 5, 6));
            srms.Add(new Srm("Amber", 6, 9));
            srms.Add(new Srm("Deep Amber/Light Copper", 10, 14));
            srms.Add(new Srm("Copper", 14, 17));
            srms.Add(new Srm("Deep Copper/Light Brown", 17, 18));
            srms.Add(new Srm("Brown", 19, 22));
            srms.Add(new Srm("Dark Brown", 22, 30));
            srms.Add(new Srm("Very Dark Brown", 30, 35));
            srms.Add(new Srm("Black", 30));
            srms.Add(new Srm("Black, Opaque", 40));
            comparer.SrmItems = srms;
            Assert.AreEqual(false, comparer.IsCorrect());
        }

        [Test]
        public void srmComparer_whenEmpty_returnsFalse()
        {
            Assert.IsFalse(comparer.IsCorrect());
        }

        private static List<Srm> GetOrderedListOfSrm()
        {
            var srms = new List<Srm>();
            srms.Add(new Srm("Straw", 2, 3));
            srms.Add(new Srm("Yellow", 3, 4));
            srms.Add(new Srm("Gold", 5, 6));
            srms.Add(new Srm("Amber", 6, 9));
            srms.Add(new Srm("Deep Amber/Light Copper", 10, 14));
            srms.Add(new Srm("Copper", 14, 17));
            srms.Add(new Srm("Deep Copper/Light Brown", 17, 18));
            srms.Add(new Srm("Brown", 19, 22));
            srms.Add(new Srm("Dark Brown", 22, 30));
            srms.Add(new Srm("Very Dark Brown", 30, 35));
            srms.Add(new Srm("Black", 30));
            srms.Add(new Srm("Black, Opaque", 40));

            return srms;
        }

        private static List<Srm> GetUnorderedListofSrm()
        {
            var srms = new List<Srm>();
            srms.Add(new Srm("Deep Amber/Light Copper", 10, 14));
            srms.Add(new Srm("Yellow", 3, 4));
            srms.Add(new Srm("Straw", 2, 3));
            srms.Add(new Srm("Gold", 5, 6));
            srms.Add(new Srm("Amber", 6, 9));
            srms.Add(new Srm("Copper", 14, 17));
            srms.Add(new Srm("Deep Copper/Light Brown", 17, 18));
            srms.Add(new Srm("Brown", 19, 22));
            srms.Add(new Srm("Dark Brown", 22, 30));
            srms.Add(new Srm("Very Dark Brown", 30, 35));
            srms.Add(new Srm("Black", 30));
            srms.Add(new Srm("Black, Opaque", 40));
            return srms;
        }
    }
}