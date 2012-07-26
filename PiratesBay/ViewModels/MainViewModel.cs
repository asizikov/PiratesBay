using System.Collections.ObjectModel;
using PiratesBay.Domain;
using PiratesBay.Commands;
using System.Windows.Input;
using System;

namespace PiratesBay.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private ICalculation calculation;
        private double total;
        private IPersonFactory<PersonViewModel> personsFactory;

        public ObservableCollection<IPerson> Persons { get; private set; }

        public double Total {
            get { return total; }
            private set 
            {
                if (total != value) 
                {
                    total = value;
                    RaisePropertyChanged("Total");
                }
            }
        }

        public ICommand AddNewPersonCommand { get; private set; }


        public MainViewModel(ICalculation calculation, ObservableCollection<IPerson> persons, IPersonFactory<PersonViewModel> personsFactory)
        {
            this.calculation = calculation;
            this.personsFactory = personsFactory;
            Persons = persons;
            AddNewPerson();

            SetUpCommands();
        }

        private void SetUpCommands()
        {
            AddNewPersonCommand = new AddNewPersonCommand(
                canExecute: () => { return true; },
                execute: () => { AddNewPerson(); }
                );
        }

        private void AddNewPerson()
        {
            var person = personsFactory.GetNewPerson(Persons.Count);
            person.PropertyChanged += (s, e) => 
            {
                if (e.PropertyName == "Spent") 
                {
                    calculation.Process();
                    Total = calculation.Total;
                }
            };
            person.OnDelete += (p) => 
            {
                if (Persons.Contains(p)) 
                {
                    Persons.Remove(p);
                    calculation.Process();
                    Total = calculation.Total;
                }
            };

            Persons.Add(person);
            calculation.Process();

        }


    }
}
