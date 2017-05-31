using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace MoviesApp
{
    public partial class App : Application
    {
        public const string UrlMovies = "https://facebook.github.io/react-native/movies.json";
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage(new MoviesApp.MainPage());
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
