using System;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Markup;

namespace Counter
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {        
        // Holds the maximum Occupancy value for the building. Ask if this will be fixed or need a way of changing in the app
        private int maximumOccupancy;
        

        public MainPage()
        {            
            InitializeComponent();            
            
            maximumOccupancy = 20; 
            maximumOccupancyLabel.Text = "Maximum: " + maximumOccupancy.ToString();            
        }

        // Sets the initial values of the counts
        protected override void OnAppearing()
        {
            base.OnAppearing();
            currentOccupancyLabel.Text = App.occupancyCount.ToString();
            // TODO Check to see if a font colour change is needed. Make a method
            hourlyCountLabel.Text = "Hourly Count: " + App.hourlyCount.ToString();
        }

        // Event handlers for the + and - buttons so that increase ior decrease the current occupency
        private void AddButtonClicked(object sender, EventArgs e)
        {
            // Update the occupancy counter
            App.occupancyCount += 1;
            currentOccupancyLabel.Text = App.occupancyCount.ToString();

            // Check for the count approaching the maximum
            if (App.occupancyCount >= maximumOccupancy)
            {
                currentOccupancyLabel.TextColor = Color.Red;
                // TODO A reminder could be displayed telling the user maximum occupancy has been reached and wait for people to leave before anyone else is allowed to enter.
            }
            else if (maximumOccupancy - App.occupancyCount <= 5)
            {
                currentOccupancyLabel.TextColor = Color.Orange;                
            }

            // Update the hourly count value
            App.hourlyCount += 1;
            hourlyCountLabel.Text = "Hourly Count: " + App.hourlyCount.ToString();
        }
        private void SubtractButtonClicked(object sender, EventArgs e)
        {
            App.occupancyCount -= 1;
            if (App.occupancyCount < 0)
            {
                App.occupancyCount = 0;
            }
            // Check to see if the occupancy is less than a color warning boundary
            if (maximumOccupancy - App.occupancyCount == 6)
            {
                currentOccupancyLabel.TextColor = Color.Default;
            }
            else if (maximumOccupancy - App.occupancyCount == 1)
            {
                currentOccupancyLabel.TextColor = Color.Orange;
            }
            currentOccupancyLabel.Text = App.occupancyCount.ToString();
        }

        // Resets the hourly count        
        private async void HourlyCountResetClicked(object sender, EventArgs e)
        {
            // Check the user wanted to do this.
            await Navigation.PushModalAsync(new HourlyCountResetPage());   
            // Refresh the hourly count on the UI
            hourlyCountLabel.Text = "Hourly Count: " + App.hourlyCount.ToString();
        }
    }
}
