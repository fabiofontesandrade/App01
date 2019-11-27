using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App02
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new TipoPagina.Carousel.IntroducaoApp();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
