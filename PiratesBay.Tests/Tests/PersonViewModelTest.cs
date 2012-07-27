using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiratesBay.Domain;
using PiratesBay.ViewModels;

namespace PiratesBay.Test.Unit
{
    [TestClass]
    public class PersonViewModelTest
    {
        [TestInitialize]
        public void SetUp()
        {
            ;
        }

        [TestMethod]
        public void InitTest()
        {
            var person = new MoqPerson(10.0);
            var personVM = new PersonViewModel(person);
            Assert.IsNotNull(personVM);
        }

        [TestMethod]
        public void ViewModelPropertiesAreEqualToDomainPropertiesTest()
        {
            var personsList = new List<IPerson>();
            var personVM = new PersonViewModel();
            personVM.Name = "Anton";
            personVM.Spent = 10.0;
            personVM.Debt = 0.0;
            Assert.AreEqual("Anton", personVM.Name);
            Assert.AreEqual(10.0, personVM.Spent);
            Assert.AreEqual(0.0, personVM.Debt);

            var eventRaiseCounter = 0;
            personVM.PropertyChanged += (s,arg) => eventRaiseCounter++;

            var otherPerson = new MoqPerson(20.0);
            var calculation = new Calculation(personsList);
            personsList.Add(personVM);
            personsList.Add(otherPerson);
            calculation.Process();

            Assert.IsTrue(eventRaiseCounter > 0);
            Assert.AreEqual(-5.0, personVM.Debt);

        }

    }
}
