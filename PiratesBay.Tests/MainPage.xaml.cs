using System.Windows;
using Microsoft.Phone.Controls;
using PiratesBay.Tests.Utils;

namespace PiratesBay.Tests
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPageLoaded(object sender, RoutedEventArgs e)
        {
            this.StartTestRunner();
        }
    }
}