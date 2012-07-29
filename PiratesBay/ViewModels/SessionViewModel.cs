using System;
using System.Linq;
using System.Reactive.Linq;
using PiratesBay.Domain;
using PiratesBay.Extensions;
using PiratesBay.Model;
using ReactiveUI;
using ReactiveUI.Xaml;

namespace PiratesBay.ViewModels
{
    public class SessionViewModel :ReactiveObject
    {
        private readonly SessionModel _model;
        private readonly IPersonFactory<Person> _personFactory;


        public ReactiveCommand AddNewPersonCommand { get; private set; }
        public ReactiveCommand DeleteSelectedCommand { get; private set; }

        public ReactiveCollection<ParticipantViewModel> Participants { get; protected set; }


        public SessionViewModel(SessionModel model ,IPersonFactory<Person> personFactory)
        {
            _model = model.ThrowIfNull("model");
            _personFactory = personFactory.ThrowIfNull("personFactory");

            AddNewPersonCommand = new ReactiveCommand();
            AddNewPersonCommand.Subscribe(dontcare => 
                _model.Participants.Add(_personFactory.GetNewPerson(Participants.Count)));


            Participants = _model.Participants
                                    .CreateDerivedCollection(x => new ParticipantViewModel(x));
            
            Participants.ChangeTrackingEnabled = true;

            var deleteCanExecute = Observable.Merge(Participants.ItemChanged
                                                 .Select(_ => Participants.Any(p => p.IsSelected)),
                                             Participants.CollectionCountChanged
                                             .Select(_ => Participants.Any(p=> p.IsSelected)));

            DeleteSelectedCommand = new ReactiveCommand
                (
                       deleteCanExecute
                );
            DeleteSelectedCommand.Subscribe(
                x =>
                    {
                        RemoveSelected();
                    }
                );

            AddNewPersonCommand.Execute(null);

        }

        private void RemoveSelected()
        {
            var res = Participants.Where(p => p.IsSelected)
                 .Select(x => x.Model).ToList();
            foreach (var person in res)
            {
                _model.Participants.Remove(person);
            }
        }

    }
}
