using System.IO.IsolatedStorage;

namespace PiratesBay.Storage
{
    public class StateManager
    {
        private IsolatedStorageFile _storage;
        
        public StateManager()
        {
            _storage = IsolatedStorageFile.GetUserStoreForApplication();
        }

        public bool HasSavedState
        {
            get { return false; }
        }
    }
}
