using System;
using Microsoft.Silverlight.Testing.UnitTesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiratesBay.Domain;
using System.Collections.Generic;

namespace PiratesBay.Test.Unit
{
    [TestClass]
    public class CalculationsTests
    {
        private ICalculation calculation;
        private IPerson first;
        private IPerson second;
        private List<IPerson> Persons;

        [TestInitialize]
        public void SetUp()
        {
            Persons = new List<IPerson>();
            calculation = new Calculation(Persons);
            first = new MoqPerson(10.0);
            second = new MoqPerson(20.0);
        }

        [TestMethod]
        public void InitialisationTest() 
        {
            Assert.AreEqual(0, calculation.Total);
            Assert.AreEqual(0, calculation.Persons.Count);
        }

        [TestMethod]
        public void AddPersonsTest() 
        {
            Persons.Add(first);
            Assert.AreEqual(1, calculation.Persons.Count);
            Assert.IsTrue(calculation.Persons.Contains(first));
        }

        [TestMethod]
        public void TotalTest()
        {
            Persons.Add(first);
            Assert.AreEqual(first.Spent, calculation.Total);
            
            Persons.Add(second);
            Assert.AreEqual(first.Spent + second.Spent, calculation.Total);
        }

        [TestMethod]
        public void ProcessTest()
        {
            Persons.Add(first);
            Persons.Add(second);
            calculation.Process();

            Assert.AreEqual(-5.0, first.Debt);
            Assert.AreEqual(5.0, second.Debt);
        }

        [TestMethod]
        public void GetDetailsTest()
        {
            first.Spent = 16.0;
            Persons.Add(first);
            Persons.Add(second);
            var third = new MoqPerson(6.0);
            Persons.Add(third);
            calculation.Process();
            var details = calculation.GetDetails(third);

            Assert.AreEqual(2, details.Count);
            Assert.AreEqual(2.0, details[0].Give);
            Assert.AreEqual(6.0, details[1].Give);
            //первому 2
            //второму 6
        }

    }
}
