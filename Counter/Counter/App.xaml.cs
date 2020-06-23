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
            // TODO MIght need to store the occupancyCount here to persist the value
        }

        protected override void OnResume()
        {
            // TODO MIght need to load the occupancyCount here
        }
    }
}
