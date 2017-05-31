using MoviesApp.Infrastructure;
using MoviesApp.Interfaces;
using MoviesApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MoviesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MoviesPage : ContentPage
    {
        public MoviesPage(MovieData movieData)
        {
            this.BindingContext = movieData;
            InitializeComponent();
        }

        public static async Task<PageStatus<MoviesPage>> CreatePage()
        {
            var client = DependencyService.Get<IHttpClient>();
            var jsonResult = await client.GetAsync(App.UrlMovies);
            if (jsonResult.Succeeded)
            {
                var movieData = JsonConvert.DeserializeObject<MovieData>(jsonResult.Result);
                return new PageStatus<MoviesPage>
                {
                    Succeeded = true,
                    Result = new MoviesPage(movieData),
                };
            }
            else
            {
                return new PageStatus<MoviesPage>
                {
                    Succeeded = false,
                    Ex = jsonResult.Ex
                };
            }
        }
    }
}
        
