using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiratesBay.Domain;
using PiratesBay.Model;

namespace PiratesBay.Test.Unit
{
    [TestClass]
    public class PersonViewModelTest
    {

        [TestMethod]
        public void ViewModelPropertiesAreEqualToDomainPropertiesTest()
        {
            var personsList = new List<Person>();
            var personVM = new Person 
            {Name = "Anton", Spent = 10.0, Debt = 0.0};
            Assert.AreEqual("Anton", personVM.Name);
            Assert.AreEqual(10.0, personVM.Spent);
            Assert.AreEqual(0.0, personVM.Debt);

            var eventRaiseCounter = 0;
            personVM.PropertyChanged += (s,arg) => eventRaiseCounter++;

            var otherPerson = new Person { Spent = 20.0 };
            var calculation = new Calculation(personsList);
            personsList.Add(personVM);
            personsList.Add(otherPerson);
            calculation.Process();

            Assert.IsTrue(eventRaiseCounter > 0);
            Assert.AreEqual(-5.0, personVM.Debt);

        }

    }
}
