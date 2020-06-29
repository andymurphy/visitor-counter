using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


namespace Counter
{
    public partial class App : Application
    {        
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
            
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            // TODO Might need to store the occupancyCount here to persist the value
            // This might mean putting the variable in this file and providing getter setter for MainPage to access
            
        }

        protected override void OnResume()
        {
            // TODO MIght need to load the occupancyCount here
        }
    }
}
