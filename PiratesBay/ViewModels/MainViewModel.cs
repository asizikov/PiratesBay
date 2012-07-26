using System.Collections.ObjectModel;
using PiratesBay.Domain;
using PiratesBay.Commands;
using System.Windows.Input;

namespace PiratesBay.ViewModels
{
    public class MainViewModel: BaseViewModel
    {
        private readonly ICalculation _calculation;
        private readonly IPersonFactory<PersonViewModel> _personsFactory;

        private double _total;
        

        public ObservableCollection<IPerson> Persons { get; private set; }

        public double Total {
            get { return _total; }
            private set 
            {
                if (_total != value) 
                {
                    _total = value;
                    RaisePropertyChanged("Total");
                }
            }
        }

        public ICommand AddNewPersonCommand { get; private set; }


        public MainViewModel(ICalculation calculation, ObservableCollection<IPerson> persons, 
            IPersonFactory<PersonViewModel> personsFactory)
        {
            _calculation = calculation;
            _personsFactory = personsFactory;
            Persons = persons;
            AddNewPerson();

            SetUpCommands();
        }

        private void SetUpCommands()
        {
            AddNewPersonCommand = new AddNewPersonCommand(
                () => true, AddNewPerson);
        }

        private void AddNewPerson()
        {
            var person = _personsFactory.GetNewPerson(Persons.Count);
            person.PropertyChanged += (s, e) => 
            {
                if (e.PropertyName == "Spent") 
                {
                    _calculation.Process();
                    Total = _calculation.Total;
                }
            };
            person.OnDelete += p => 
            {
                if (Persons.Contains(p)) 
                {
                    Persons.Remove(p);
                    _calculation.Process();
                    Total = _calculation.Total;
                }
            };

            Persons.Add(person);
            _calculation.Process();

        }


    }
}
