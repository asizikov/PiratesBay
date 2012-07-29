using PiratesBay.Domain;
using PiratesBay.Model;

namespace PiratesBay.ViewModels
{
    public static class ViewModelLocator
    {
        private static SessionViewModel _sessionViewModel;

        public static SessionViewModel SessionViewModel 
        {
            get 
            {
                return _sessionViewModel ??
                    (_sessionViewModel = BuildSessionViewModel());
            }
        }

        private static SessionViewModel BuildSessionViewModel()
        {
            var personsFactory = new ParticipantFactory();
            return new SessionViewModel(new SessionModel(), personsFactory);
        }
    }
}
