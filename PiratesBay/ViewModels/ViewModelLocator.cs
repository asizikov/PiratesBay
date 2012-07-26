using System.Collections.ObjectModel;
using PiratesBay.Domain;

namespace PiratesBay.ViewModels
{
    public static class ViewModelLocator
    {
        private static MainViewModel _mainViewModel;

        public static MainViewModel MainViewModel 
        {
            get 
            {
                return _mainViewModel ??
                    (_mainViewModel = BuildMainViewModel());
            }
        }

        private static MainViewModel BuildMainViewModel()
        {
            var persons = new ObservableCollection<IPerson>();
            var personsFactory = new PersonFactory();
            return new MainViewModel(new Calculation(persons), persons, personsFactory);
        }
    }
}
