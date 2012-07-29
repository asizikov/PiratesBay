using PiratesBay.Model;
using ReactiveUI;

namespace PiratesBay.ViewModels
{
    public class ParticipantViewModel : ReactiveObject
    {
        private readonly Person _person;

        public ParticipantViewModel(Person person)
        {
            _person = person;
        }
    }
}