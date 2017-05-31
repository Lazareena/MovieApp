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
        private int _maxRetryIfNetworkTimeout = 3;
        public async Task<NetworkStatusCode<string>> GetAsync(string url)
        {
            HttpClient client = new HttpClient(new NSUrlSessionHandler());
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