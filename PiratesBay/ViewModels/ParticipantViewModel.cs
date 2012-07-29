using PiratesBay.Model;
using ReactiveUI;

namespace PiratesBay.ViewModels
{
    public class ParticipantViewModel : ReactiveObject
    {
        public Person Model { get; private set; }

        public ParticipantViewModel(Person model)
        {
            Model = model;
        }


        private bool _isSelected;
        public bool IsSelected
        {
            get { return _isSelected; }
            set { this.RaiseAndSetIfChanged(x => x.IsSelected, ref _isSelected, value); }
        }

        public string Name
        {
            get { return Model.Name; }
            set { Model.Name = value; }
        }
        public double Spent 
        { 
            get { return Model.Spent; }
            set { Model.Spent = value; }
        }
        public double Debt 
        { 
            get { return Model.Debt; }
        }
    }
}