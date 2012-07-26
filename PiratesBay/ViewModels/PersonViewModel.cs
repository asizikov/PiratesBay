using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using PiratesBay.Domain;
using System.Windows.Input;
using PiratesBay.Commands;

namespace PiratesBay.ViewModels
{
    public class PersonViewModel: BaseViewModel, IPerson
    {
        private string name;
        private double spent;
        private double debt;
        IPerson person;

        public event Action<PersonViewModel> OnDelete;

        public PersonViewModel(IPerson person)
        {
            this.person = person;
            name = person.Name;
            spent = person.Spent;
            debt = person.Debt;

        }

        public PersonViewModel()
        {
            name = String.Empty;
            DeleteThisCommand = new DeleteThisPersonCommand(RaiseOnDelete);
        }

        public string Name 
        {
            get { return name; }
            set 
            {
                if (name == value)
                    return;
                name = value;
                RaisePropertyChanged("Name");
            } 
        }

        public double Spent { get { return spent; }
            set 
            {
                if (spent != value) 
                {
                    spent = value;
                    RaisePropertyChanged("Spent");
                }
            }
        }

        public ICommand DeleteThisCommand { get; set; }

        public double Debt
        {
            get { return debt; }
            set
            {
                if (debt != value)
                {
                    debt = value;
                    RaisePropertyChanged("Debt");
                }
            }
        }

        public static string DefaultName
        { get { return "Новый участник"; } }

        private void RaiseOnDelete() 
        {
            if (OnDelete != null) 
            {
                OnDelete(this);
            }
        }
    }
}
