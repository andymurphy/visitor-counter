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
        // Hodls the hourly count value
        private int hourlyCount;

        public MainPage()
        {
            
            InitializeComponent();            
            
            maximumOccupancy = 20; 
            maximumOccupancyLabel.Text = "Maximum: " + maximumOccupancy.ToString();
            hourlyCount = 0;
            hourlyCountLabel.Text = "Hourly Count: " + hourlyCount.ToString();
        }

        // Sets the initial values of the counts
        protected override void OnAppearing()
        {
            base.OnAppearing();
            currentOccupancyLabel.Text = App.occupancyCount.ToString();
        }

        // Event handlers for the + and - buttons so that increase ior decrease the current occupency
        private void Add_Button_Clicked(object sender, EventArgs e)
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
            hourlyCount += 1;
            hourlyCountLabel.Text = "Hourly Count: " +  hourlyCount.ToString();
        }
        private void Subtract_Button_Clicked(object sender, EventArgs e)
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
        // TODO This could have a modal asking for confirmation and prompting the user to enter the hourly figures in the visitor register.
        private void Hourly_Count_Reset_Clicked(object sender, EventArgs e)
        {
            hourlyCount = 0;
            hourlyCountLabel.Text = "Hourly Count: " + hourlyCount.ToString();
        }
    }
}
