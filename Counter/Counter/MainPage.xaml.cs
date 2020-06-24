using System;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Counter
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        // Holds the current occupancy value for the building
        private int occupancyCount;
        // Holds the maximum Occupancy value for the building
        private int maximumOccupancy;
        // Hodls the hourly count value
        private int hourlyCount;

        public MainPage()
        {
            InitializeComponent();
            // TODO Do I need to check for a stored value here or just in App.Xaml.cs in OnStart and/or OnResume
            occupancyCount = 0;
            currentOccupancyLabel.Text = occupancyCount.ToString();
            maximumOccupancy = 10;
            maximumOccupancyLabel.Text = "Maximum: " + maximumOccupancy.ToString();
            hourlyCount = 0;
            hourlyCountLabel.Text = "Hourly Count: " + hourlyCount.ToString();
        }

        // Event handlers for the + and - buttons so that increase ior decrease the current occupency
        private void Add_Button_Clicked(object sender, EventArgs e)
        {
            // Update the occupancy counter
            occupancyCount += 1;
            currentOccupancyLabel.Text = occupancyCount.ToString();

            // Check for the count approaching the maximum
            if (maximumOccupancy - occupancyCount <= 5)
            {
                currentOccupancyLabel.TextColor = Color.Orange;
            }
            else if (maximumOccupancy == occupancyCount)
            {
                currentOccupancyLabel.TextColor = Color.Red;
                // TODO Perhaps a reminder could be displayed reminding the user not to let anyone else in.
            }
            
            

            // Update the hourly count value
            hourlyCount += 1;
            hourlyCountLabel.Text = "Hourly Count: " +  hourlyCount.ToString();
        }
        private void Subtract_Button_Clicked(object sender, EventArgs e)
        {
            occupancyCount -= 1;
            if (occupancyCount < 0)
            {
                occupancyCount = 0;
            }
            // Check to see if the occuoancy is less than a color warning boundary
            if (maximumOccupancy - occupancyCount == 6)
            {
                currentOccupancyLabel.TextColor = Color.Black;
            }
            else if (maximumOccupancy - occupancyCount == 1)
            {
                currentOccupancyLabel.TextColor = Color.Orange;
            }
            currentOccupancyLabel.Text = occupancyCount.ToString();
        }

        // Resets the hourly count
        // TODO This could have a modal asking for confirmation and prompting the user to enter the hourly figures.
        private void Hourly_Count_Reset_Clicked(object sender, EventArgs e)
        {
            hourlyCount = 0;
            hourlyCountLabel.Text = "Hourly Count: " + hourlyCount.ToString();
        }
    }
}
