using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using MoviesApp.Droid;
using MoviesApp.Interfaces;
using System.Net.Http;
using MoviesApp.Infrastructure;
using System.Threading.Tasks;

[assembly: Dependency(typeof(AndroidClient))]
namespace MoviesApp.Droid
{
    public class AndroidClient : IHttpClient
    {
        public HttpClient GetClient()
        {
            HttpClient client = new HttpClient(new Xamarin.Android.Net.AndroidClientHandler());
            return client;
        }
    }
}