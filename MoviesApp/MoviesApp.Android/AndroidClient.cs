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
        private int _maxRetryIfNetworkTimeout = 3;
        public async Task<NetworkStatusCode<string>> GetAsync(string url)
        {
            HttpClient client = new HttpClient(new Xamarin.Android.Net.AndroidClientHandler());
            var result = new NetworkStatusCode<string>() { Succeeded = false };
            bool done = false;
            int retryCounts = 0;
            while (!done)
            {
                done = true;
                try
                {
                    var response = await client.GetAsync(url).ConfigureAwait(false);
                    response.EnsureSuccessStatusCode();
                    result.Succeeded = true;
                    result.Result = await response.Content.ReadAsStringAsync();
                }
                catch (Exception ex)
                {
                    result.Ex = ex;
                    if (ex is System.Net.WebException)
                    {
                        retryCounts++;
                        if (retryCounts < _maxRetryIfNetworkTimeout)
                            done = false;
                    }
                }
            }
            return result;
        }
    }
}