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
        private const int maximumOccupancy = 20;
        private const string hourly = "Hourly Count: ";

        public MainPage()
        {
            InitializeComponent();            
            
            maximumOccupancyLabel.Text = "Maximum: " + maximumOccupancy.ToString();            
        }
        
        // Sets the initial values of the counts
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // An occupancy count and/or hourly count might have been loaded so update the UI
            currentOccupancyLabel.Text = App.occupancyCount.ToString();
            CheckForColourChange();
            hourlyCountLabel.Text = hourly + App.hourlyCount.ToString();
        }

        #region Click Handlers

        // Event handlers for the + and - buttons so that increase ior decrease the current occupency
        private void AddButtonClicked(object sender, EventArgs e)
        {
            // Update the occupancy counter and check to see if we need to change the colour of the occupancy value
            App.occupancyCount += 1;
            currentOccupancyLabel.Text = App.occupancyCount.ToString();
            CheckForColourChange();

            // Update the hourly count value
            App.hourlyCount += 1;
            hourlyCountLabel.Text = hourly + App.hourlyCount.ToString();
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
            hourlyCountLabel.Text = hourly + App.hourlyCount.ToString();
        }
        #endregion

        /// <summary>
        /// Checks to see if the Occupancy Count figue on the UI needs to change colour after an increase
        /// </summary>
        private void CheckForColourChange()
        {
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
        }
    }
}
