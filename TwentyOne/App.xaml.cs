using System;
using TwentyOne.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TwentyOne
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new GameScreenPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
