using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiratesBay.Domain;
using PiratesBay.ViewModels;
using System;

namespace PiratesBay.Test.Unit
{
    [TestClass]
    public class PersonFactoryTests
    {
        [TestMethod]
        public void InitTest()
        {
            var factory = new PersonFactory();
            Assert.IsInstanceOfType(factory, typeof(IPersonFactory<PersonViewModel>));
            var person = factory.GetNewPerson(0);
            PersonViewModel vm = person;
            Assert.IsNotNull(vm);
        }

        [TestMethod]
        public void PersonsNameTest()
        {
            var factory = new PersonFactory();
            var person = factory.GetNewPerson(0);
            Assert.AreEqual(String.Format("{0}#1",PersonViewModel.DefaultName), person.Name);
        }
    }
}
