using Microsoft.VisualStudio.TestTools.UnitTesting;
using PiratesBay.Commands;
using System.Windows.Input;

namespace PiratesBay.Test.Unit
{
    [TestClass]
    public class AddNewPersonCommandTest
    {
        [TestMethod]
        public void ICommandImplementationTest()
        {
            var command = new AddNewPersonCommand(null, null);
            Assert.IsInstanceOfType(command, typeof(ICommand));
        }

        [TestMethod]
        public void AcceptsLambdasAsCanExecute()
        {
            var command = new AddNewPersonCommand(() => true, null);
            Assert.IsTrue(command.CanExecute(null));
        }

    }
}
