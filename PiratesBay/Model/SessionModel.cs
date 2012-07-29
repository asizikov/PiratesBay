using ReactiveUI;

namespace PiratesBay.Model
{
    public class SessionModel : ReactiveObject
    {
        public SessionModel()
        {
                Participants = new ReactiveCollection<Person>();
        }

        public ReactiveCollection<Person> Participants { get; private set; }
    }
}
