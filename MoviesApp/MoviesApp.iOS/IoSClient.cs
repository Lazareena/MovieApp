using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using MoviesApp.iOS;
using Xamarin.Forms;
using MoviesApp.Interfaces;
using MoviesApp.Infrastructure;
using System.Threading.Tasks;
using System.Net.Http;

[assembly: Dependency(typeof(IoSClient))]
namespace MoviesApp.iOS
{
    public class IoSClient : IHttpClient
    { 
        public IHttpClient GetClient()
        {
            HttpClient client = new HttpClient(new NSUrlSessionHandler());
            return client;
        }
    }
}