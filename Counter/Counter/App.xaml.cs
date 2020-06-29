using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Counter
{
    public partial class App : Application
    {
        // \key used for storing preference
        const string savedOccupancyCount = "savedOccupancyCount";

        // Holds the current occupancy value for the building
        public static int occupancyCount { get; set; }        

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
        }

        protected override void OnSleep()
        {
            // TODO Might need to store the occupancyCount here to persist the value
            // This might mean putting the variable in this file and providing getter setter for MainPage to access
            Console.WriteLine("OnSleep, saving occupancyCount value of " + occupancyCount.ToString());
            Properties[savedOccupancyCount] = occupancyCount;
        }

        protected override void OnResume()
        {
            Console.WriteLine("OnResume");
        }
    }
}
