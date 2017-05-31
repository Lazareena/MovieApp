using MoviesApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MoviesApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MainBtn.Clicked += MainBtn_Clicked;
        }

        private SemaphoreSlim _lockBtn = new SemaphoreSlim(1);
        private async void MainBtn_Clicked(object sender, EventArgs e)
        {
            try
            {
                if (_lockBtn.Wait(30))
                {
                    var moviesPageRes = await MoviesPage.CreatePage();
                    if (moviesPageRes.Succeeded)
                    {
                        await Navigation.PushAsync(moviesPageRes.Result);
                    }
                    else
                    {
                        await DisplayAlert("Error", moviesPageRes.Ex.Message, "Ok");
                    }
                }
            }
            finally
            {
                _lockBtn.Release();
            }
        }
    }
}
