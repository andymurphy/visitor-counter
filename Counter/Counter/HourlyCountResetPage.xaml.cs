using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Counter
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HourlyCountResetPage : ContentPage
    {
        public HourlyCountResetPage()
        {
            InitializeComponent();
        }
        // Handles the user clicking the OK button
        private async void OnOkClicked(object sender, EventArgs e)
        {
            // Reset the hourly count variable
            App.hourlyCount = 0;            
            await Navigation.PopModalAsync();
        }
        // Handles the user clicking the Cancel button
        private async void OnCancelClicked(object sender, EventArgs e)
        {
            // Do nothing but return
            await Navigation.PopModalAsync();
        }
        // If the user clicks the back button (e.g. the hardware back on Android) the modal is dismissed.
        // This behaviour could be overidden if necessary.

    }
}