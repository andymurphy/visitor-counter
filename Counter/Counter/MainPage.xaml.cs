using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            maximumOccupancy = 50;
            maximumOccupancyLabel.Text = maximumOccupancy.ToString();
            hourlyCount = 0;
            hourlyCountLabel.Text = "Hourly Count: " + hourlyCount.ToString();
        }

        // Event handlers for the + and - buttons so that increase ior decrease the current occupency
        private void Add_Button_Clicked(object sender, EventArgs e)
        {
            // Update the occupancy counter
            occupancyCount += 1;
            currentOccupancyLabel.Text = occupancyCount.ToString();

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
            currentOccupancyLabel.Text = occupancyCount.ToString();
        }
    }
}
