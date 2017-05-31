using MoviesApp.Infrastructure;
using MoviesApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MoviesApp.Data
{
    public class DataLayer
    {
        private HttpClient _client;
        public DataLayer(HttpClient client)
        {
            _client = client;
        }

        private int _maxRetryIfNetworkTimeout = 3;
        public async Task<NetworkStatusCode<string>> GetAsync(string url)
        {
            var result = new NetworkStatusCode<string>() { Succeeded = false };
            bool done = false;
            int retryCounts = 0;
            while (!done)
            {
                done = true;
                try
                {
                    var response = await _client.GetAsync(url).ConfigureAwait(false);
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
