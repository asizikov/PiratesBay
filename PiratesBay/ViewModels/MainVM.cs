using System.Collections.Generic;
using PiratesBay.Domain;
using PiratesBay.Extensions;
using ReactiveUI;
using ReactiveUI.Xaml;

namespace PiratesBay.ViewModels
{
    public class MainVM :ReactiveObject
    {
        private readonly IPersonFactory<PersonViewModel> _personFactory;

        public MainVM(IPersonFactory<PersonViewModel> personFactory ,ReactiveAsyncCommand testAddNewPerson = null)
        {
            _personFactory = personFactory.ThrowIfNull("personFactory");
            AddNewPersonCommand = testAddNewPerson ?? new ReactiveAsyncCommand();
            AddNewPersonCommand.RegisterAsyncAction(AddNewPerson);
        }


        public ReactiveAsyncCommand AddNewPersonCommand { get; private set; }

        private ObservableAsPropertyHelper<List<PersonViewModel>> _persons; 
        public List<PersonViewModel> Persons
        {
            get
            {
                return _persons.Value;
            }
        }

        private void AddNewPerson(object o)
        {
            Persons.Add(_personFactory.GetNewPerson(Persons.Count));
        }
    }
}
