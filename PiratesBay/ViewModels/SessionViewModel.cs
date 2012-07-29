using System;
using System.Collections.Generic;
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

        public SessionViewModel(SessionModel model ,IPersonFactory<Person> personFactory)
        {
            _model = model.ThrowIfNull("model");
            _personFactory = personFactory.ThrowIfNull("personFactory");

            AddNewPersonCommand = new ReactiveAsyncCommand();
            AddNewPersonCommand.Subscribe(dontcare => 
                _model.Participants.Add(_personFactory.GetNewPerson(Participants.Count)));

            Participants = model.Participants
                .CreateDerivedCollection(x => new ParticipantViewModel(x));

        }


        public ReactiveAsyncCommand AddNewPersonCommand { get; private set; }

        public ReactiveCollection<ParticipantViewModel> Participants { get; protected set; }
    }
}
