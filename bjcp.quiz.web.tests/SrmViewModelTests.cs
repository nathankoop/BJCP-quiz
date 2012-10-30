using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using bjcp.quiz.web.ViewModels;

namespace bjcp.quiz.web.tests
{
    [TestFixture]
    public class SrmViewModelTests
    {
        [Test]
        public void SrmViewModel_setup_hasPropertiesSet()
        {
            var srm = new Srm("Straw", 2, 3);
            var srmVm = new SrmViewModel(srm);

            Assert.AreEqual("Straw", srmVm.Name);
            Assert.AreEqual(2, srmVm.Low);
            Assert.AreEqual(3, srmVm.High);
        }


        
        [Test]
        public void SrmViewModel_setupCorrectly_Succeeds()
        {
            var userSrm = new Srm("Straw", 2,3);
            var srmVm = new SrmViewModel(userSrm);

            Assert.IsTrue(srmVm.Correct);
        }

        [Ignore]
        [Test]
        public void SrmViewModel_setupIncorrectly_Fails()
        {
            var srm = new Srm("Straw", 2, 3);
            var srmVm = new SrmViewModel(srm);

            Assert.IsFalse(srmVm.Correct);
        }
    }
}
