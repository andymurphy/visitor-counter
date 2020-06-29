using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Counter
{
    public partial class App : Application
    {
        // \key used for storing preference
        const string savedOccupancyCount = "savedOccupancyCount";
        const string savedHourlyCount = "savedHourlyCount";

        // Holds the current occupancy value for the building
        public static int occupancyCount { get; set; }
        // Holds the hourly count value
        public static int hourlyCount { get; set; }

        public App()
        {
            InitializeComponent();
            MainPage = new MainPage();            
        }

        protected override void OnStart()
        {
            // TODO Might need to load the occupancyCount here
            Console.WriteLine("OnResume");
            if (Properties.ContainsKey(savedOccupancyCount))
            {
                occupancyCount = (int)Properties[savedOccupancyCount];
                Console.WriteLine("Loading occupancyCount value of " + occupancyCount.ToString());
            }
            else
            {
                occupancyCount = 0;
            }
            if (Properties.ContainsKey(savedHourlyCount))
            {
                hourlyCount = (int)Properties[savedHourlyCount];
                Console.WriteLine("Loading hourlyCount value of " + hourlyCount.ToString());
            }
            else
            {
                hourlyCount = 0;
            }
        }

        protected override void OnSleep()
        {
            // Store the occupancyCount here to persist the value if the app is destroyed by the OS when app switching            
            Console.WriteLine("OnSleep, saving occupancyCount value of " + occupancyCount.ToString());
            Properties[savedOccupancyCount] = occupancyCount;
            // Store the hourly count as well
            Console.WriteLine("Saving hourly count of " + hourlyCount.ToString());
            Properties[savedHourlyCount] = hourlyCount;
        }

        protected override void OnResume()
        {
            Console.WriteLine("OnResume");
        }
    }
}
