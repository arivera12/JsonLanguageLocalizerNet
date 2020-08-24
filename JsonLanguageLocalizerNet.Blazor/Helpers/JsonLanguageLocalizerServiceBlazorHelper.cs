using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace JsonLanguageLocalizerNet.Blazor.Helpers
{
    public static class JsonLanguageLocalizerServiceBlazorHelper
    {
        /// <summary>
        /// The main difference between this helper method and the one on JsonLanguageLocalizerServiceHelper is that this method prevent caching by the browser when requesting static files.
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="httpMethod"></param>
        /// <param name="requestUri"></param>
        /// <param name="remoteRetryTimes"></param>
        /// <returns></returns>
        public static async Task<JsonLanguageLocalizerService> TryGetRemoteSourceAsync(HttpClient httpClient, string httpMethod, string requestUri, int remoteRetryTimes)
        {
            do
            {
                try
                {
                    var request = new HttpRequestMessage(new HttpMethod(httpMethod), requestUri);
                    request.SetBrowserRequestCache(BrowserRequestCache.NoCache);
                    var response = await httpClient.SendAsync(request);
                    return new JsonLanguageLocalizerService(await response.Content.ReadAsStreamAsync());
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            } while (--remoteRetryTimes > 0);
            return null;
        }
    }
}
