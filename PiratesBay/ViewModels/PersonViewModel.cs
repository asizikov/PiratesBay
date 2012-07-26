using System;
using System.Windows.Input;
using PiratesBay.Commands;
using PiratesBay.Domain;

namespace PiratesBay.ViewModels
{
    public class PersonViewModel: BaseViewModel, IPerson
    {
        private string _name;
        private double _spent;
        private double _debt;

        public event Action<PersonViewModel> OnDelete;

        public PersonViewModel(IPerson person)
        {
            _name = person.Name;
            _spent = person.Spent;
            _debt = person.Debt;

        }

        public PersonViewModel()
        {
        }

        public string Name 
        {
            get { return _name; }
            set 
            {
                if (_name == value)
                    return;
                _name = value;
                RaisePropertyChanged("Name");
            } 
        }

        public double Spent { get { return _spent; }
            set 
            {
                if (_spent != value) 
                {
                    _spent = value;
                    RaisePropertyChanged("Spent");
                }
            }
        }

        public double Debt
        {
            get { return _debt; }
            set
            {
                if (_debt != value)
                {
                    _debt = value;
                    RaisePropertyChanged("Debt");
                }
            }
        }

        public static string DefaultName
        {
            get
            {
                return "Новый участник";
            }
        }

        private DeleteThisPersonCommand _deleteCommand;
        public ICommand DeleteThisCommand
        {
            get
            {
                return _deleteCommand ??
                    (_deleteCommand = new DeleteThisPersonCommand(RaiseOnDelete));
            }
        }

        private void RaiseOnDelete() 
        {
            if (OnDelete != null) 
            {
                OnDelete(this);
            }
        }
    }
}
