using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiratesBay.Domain;
using PiratesBay.ViewModels;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace PiratesBay.Test.Unit
{
    [TestClass]
    public class MainViewModelTests
    {
        private ICalculation calculation;
        private ObservableCollection<IPerson> Persons;
        private IPersonFactory<PersonViewModel> factory;

        [TestInitialize]
        public void SetUp()
        {
            Persons = new ObservableCollection<IPerson>();
            calculation = new Calculation(Persons);
            factory = new PersonFactory();
        }

        [TestMethod]
        public void InitTest()
        {
            var vm = new MainViewModel(calculation, Persons, factory);
            Assert.IsNotNull(vm);

            Assert.IsNotNull(vm.Persons);
            Assert.AreEqual(1, vm.Persons.Count);
            Assert.AreEqual(Persons, vm.Persons);
            Assert.IsInstanceOfType(vm.Persons[0], typeof(PersonViewModel));
            Assert.AreEqual(String.Format("{0}#1", PersonViewModel.DefaultName), vm.Persons[0].Name);
            Assert.AreEqual(0.0, vm.Total);

        }

        [TestMethod]
        public void AddNewPersonCommandTest()
        {
            var vm = new MainViewModel(calculation, Persons, factory);
            Assert.IsNotNull(vm.AddNewPersonCommand);
            Assert.IsTrue(vm.AddNewPersonCommand.CanExecute(null));

            vm.AddNewPersonCommand.Execute(null);
            Assert.AreEqual(2, vm.Persons.Count);
            Assert.AreEqual(String.Format("{0}#2", PersonViewModel.DefaultName), vm.Persons[1].Name);

            bool raised = false;
            vm.PropertyChanged += (s, e) => { if (e.PropertyName == "Total")raised = true; };
            vm.Persons[1].Spent = 10.0;
            Assert.IsTrue(raised);

            var processed = false;
            var person = vm.Persons[1] as BaseViewModel;
            if (person != null)
            {
                person.PropertyChanged += (s, e) => { if (e.PropertyName == "Debt") processed = true; };
            }
            else { Assert.IsTrue(false, "should not be executed!"); }
            vm.AddNewPersonCommand.Execute(null);
            Assert.IsTrue(processed);
        }
    }
}
