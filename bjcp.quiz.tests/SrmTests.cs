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
            var orderedSrms = Srm.GetMasterSrms();
            comparer = new SrmComparer(orderedSrms);
        }

        [Test]
        public void srm_straw_isSetProperly()
        {
            var straw = new Srm(1, "Straw", 2, 3);
            Assert.AreEqual(1, straw.Id);
            Assert.AreEqual("Straw", straw.Name);
            Assert.AreEqual(2, straw.Low);
            Assert.AreEqual(3, straw.High);
        }

        [Test]
        public void srm_yellow_isSetProperly()
        {
            var yellow = new Srm(2, "Yellow", 3, 4);
            Assert.AreEqual(2, yellow.Id);
            Assert.AreEqual("Yellow", yellow.Name);
            Assert.AreEqual(3, yellow.Low);
            Assert.AreEqual(4, yellow.High);
        }

        [Test]
        public void srm_null_equalsFalse()
        {
            var yellow = new Srm(2, "Yellow", 3, 4);
            Srm nullSrm = null;
            Assert.IsFalse(yellow.Equals(nullSrm));
        }
        [Test]
        public void srm_empty_equalsFalse()
        {
            var yellow = new Srm(2, "Yellow", 3, 4);
            var empty = new Srm();
            Assert.IsFalse(yellow.Equals(empty));
        }

        [Test]
        public void srm_yellow_stringIsDisplayed()
        {
            var yellow = new Srm(2, "Yellow", 3, 4);
            Assert.AreEqual("Yellow - 3, 4", yellow.ToString());
        }

        [Test]
        public void srm_black_stringIsDisplayed()
        {
            var black = new Srm(11, "Black", 30);
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
            var srm1 = new Srm(2, "Yellow", 3, 4);
            var srm2 = new Srm(2, "Yellow", 3, 4);

            Assert.IsTrue(srm1.Equals(srm2));
        }

        [Test]
        public void srmComparer_whenIncorrectOrder_returnsFalse()
        {
            comparer.QuizSrms = GetUnorderedListofSrm();
            Assert.AreEqual(false, comparer.IsCorrect());
        }

        [Test]
        public void srmComparer_whenCorrectOrder_returnsTrue()
        {
            comparer.QuizSrms.Add(new Srm(1, "Straw", 2, 3));
            comparer.QuizSrms.Add(new Srm(2, "Yellow", 3, 4));
            comparer.QuizSrms.Add(new Srm(3, "Gold", 5, 6));
            comparer.QuizSrms.Add(new Srm(4, "Amber", 6, 9));
            comparer.QuizSrms.Add(new Srm(5, "Deep Amber/Light Copper", 10, 14));
            comparer.QuizSrms.Add(new Srm(6, "Copper", 14, 17));
            comparer.QuizSrms.Add(new Srm(7, "Deep Copper/Light Brown", 17, 18));
            comparer.QuizSrms.Add(new Srm(8, "Brown", 19, 22));
            comparer.QuizSrms.Add(new Srm(9, "Dark Brown", 22, 30));
            comparer.QuizSrms.Add(new Srm(10, "Very Dark Brown", 30, 35));
            comparer.QuizSrms.Add(new Srm(11, "Black", 30));
            comparer.QuizSrms.Add(new Srm(12, "Black, Opaque", 40));
            Assert.IsTrue(comparer.IsCorrect());
        }

        [Test]
        public void srmComparer_whenIncorrectName_returnsFalse()
        {
            var srms = new List<Srm>();
            srms.Add(new Srm(1, "Not Straw", 2, 3));
            srms.Add(new Srm(2, "Yellow", 3, 4));
            srms.Add(new Srm(3, "Gold", 5, 6));
            srms.Add(new Srm(4, "Amber", 6, 9));
            srms.Add(new Srm(5, "Deep Amber/Light Copper", 10, 14));
            srms.Add(new Srm(6, "Copper", 14, 17));
            srms.Add(new Srm(7, "Deep Copper/Light Brown", 17, 18));
            srms.Add(new Srm(8, "Brown", 19, 22));
            srms.Add(new Srm(9, "Dark Brown", 22, 30));
            srms.Add(new Srm(10, "Very Dark Brown", 30, 35));
            srms.Add(new Srm(11, "Black", 30));
            srms.Add(new Srm(12, "Black, Opaque", 40));
            comparer.QuizSrms = srms;
            Assert.AreEqual(false, comparer.IsCorrect());
        }

        [Test]
        public void srm_whenSameNameWithoutPunctuation_returnsTrue()
        {
            var srm1 = new Srm(5, "Deep Amber/Light Copper", 10, 14);
            var srm2 = new Srm(5, "Deep Amber Light Copper", 10, 14);

            Assert.IsTrue(srm1.Equals(srm2));
        }

        [Test]
        public void srm_whenSameNameWithoutPunctuation_returnsTrue2()
        {
            var srm1 = new Srm(12, "black, opaque", 40);
            var srm2 = new Srm(12, "black opaque", 40);
            Assert.IsTrue(srm1.Equals(srm2));
        }

        [Test]
        public void srm_whenSameNameWithSpaceInPunctionaion_returnsTrue()
        {
            var srm1 = new Srm(5, "Deep Amber / Light Copper", 10, 14);
            var srm2 = new Srm(5, "Deep Amber/Light Copper", 10, 14);

            Assert.IsTrue(srm1.Equals(srm2));

        }

        [Test]
        public void srmComparer_whenEmpty_returnsFalse()
        {
            Assert.IsFalse(comparer.IsCorrect());
        }

        [Test]
        public void srm_quiz_hasNoNames()
        {
            var quiz = Srm.GetQuiz();
            Assert.IsTrue(quiz.All(srm => String.IsNullOrWhiteSpace(srm.Name)));
        }

        private static List<Srm> GetUnorderedListofSrm()
        {
            var srms = new List<Srm>();
            srms.Add(new Srm(5, "Deep Amber/Light Copper", 10, 14));
            srms.Add(new Srm(2, "Yellow", 3, 4));
            srms.Add(new Srm(1, "Straw", 2, 3));
            srms.Add(new Srm(3, "Gold", 5, 6));
            srms.Add(new Srm(4, "Amber", 6, 9));
            srms.Add(new Srm(6, "Copper", 14, 17));
            srms.Add(new Srm(7,"Deep Copper/Light Brown", 17, 18));
            srms.Add(new Srm(8,"Brown", 19, 22));
            srms.Add(new Srm(9,"Dark Brown", 22, 30));
            srms.Add(new Srm(10,"Very Dark Brown", 30, 35));
            srms.Add(new Srm(11,"Black", 30));
            srms.Add(new Srm(12,"Black, Opaque", 40));
            return srms;
        }
    }
}