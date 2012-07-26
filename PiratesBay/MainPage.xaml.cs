using Microsoft.Phone.Controls;
using Microsoft.Silverlight.Testing;
using PiratesBay.ViewModels;

namespace PiratesBay
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();

            const bool runUnitTests = false;

            if (runUnitTests)
            {
                Content = UnitTestSystem.CreateTestPage();
                IMobileTestPage imtp = Content as IMobileTestPage;

                if (imtp != null)
                {
                    BackKeyPress += (x, xe) => xe.Cancel = imtp.NavigateBack();
                }
            }
            else 
            {
                DataContext = ViewModelLocator.MainViewModel;
            }
            
        }
    }
}