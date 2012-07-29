using Microsoft.Phone.Controls;
using PiratesBay.ViewModels;

namespace PiratesBay
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            DataContext = ViewModelLocator.SessionViewModel;
            InitializeComponent();
        }
    }
}