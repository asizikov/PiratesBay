using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiratesBay.Domain;
using System.Collections.Generic;
using PiratesBay.Model;

namespace PiratesBay.Test.Unit
{
    [TestClass]
    public class CalculationsTests
    {
        private ICalculation _calculation;
        private Person _first;
        private Person _second;
        private List<Person> _persons;

        [TestInitialize]
        public void SetUp()
        {
            _persons = new List<Person>();
            _calculation = new Calculation(_persons);
            _first = new Person { Spent = 10.0 };
            _second = new Person { Spent = 20.0 };
        }

        [TestMethod]
        public void InitialisationTest() 
        {
            Assert.AreEqual(0, _calculation.Total);
            Assert.AreEqual(0, _calculation.Persons.Count);
        }

        [TestMethod]
        public void AddPersonsTest() 
        {
            _persons.Add(_first);
            Assert.AreEqual(1, _calculation.Persons.Count);
            Assert.IsTrue(_calculation.Persons.Contains(_first));
        }

        [TestMethod]
        public void TotalTest()
        {
            _persons.Add(_first);
            Assert.AreEqual(_first.Spent, _calculation.Total);
            
            _persons.Add(_second);
            Assert.AreEqual(_first.Spent + _second.Spent, _calculation.Total);
        }

        [TestMethod]
        public void ProcessTest()
        {
            _persons.Add(_first);
            _persons.Add(_second);
            _calculation.Process();

            Assert.AreEqual(-5.0, _first.Debt);
            Assert.AreEqual(5.0, _second.Debt);
        }

        [TestMethod]
        public void GetDetailsTest()
        {
            _first.Spent = 16.0;
            _persons.Add(_first);
            _persons.Add(_second);
            var third = new Person { Spent = 6.0 };
            _persons.Add(third);
            _calculation.Process();
            var details = _calculation.GetDetails(third);

            Assert.AreEqual(2, details.Count);
            Assert.AreEqual(2.0, details[0].Give);
            Assert.AreEqual(6.0, details[1].Give);
        }

    }
}
