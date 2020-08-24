﻿using Microsoft.AspNetCore.Components.WebAssembly.Http;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JsonLanguageLocalizerNet.Blazor.Helpers
{
    public static class JsonLanguageLocalizerServiceHelper
    {
        /// <summary>
        /// Loads the json file into the service using the supported cultures service within the desired strategy and loading preference. 
        /// </summary>
        /// <param name="webAssemblyHost"></param>
        /// <returns></returns>
        public static async Task<JsonLanguageLocalizerService> GetJsonLanguageLocalizerServiceFromSupportedCulturesAsync(HttpClient httpClient, LanguageLocalizerSupportedCultures languageLocalizerSupportedCultures)
        {
            if (!languageLocalizerSupportedCultures.SupportedCultures.Any())
            {
                throw new Exception("There is no supported cultures defined. Make sure there is at least one supported language.");
            }
            JsonLanguageLocalizerService result = null;
            var languageLocalizerSupportedCultureSelected = languageLocalizerSupportedCultures.SupportedCultures.FirstOrDefault(w => w.CultureInfo.Equals(CultureInfo.DefaultThreadCurrentCulture));
            if(languageLocalizerSupportedCultureSelected == null)
            {
                languageLocalizerSupportedCultureSelected = languageLocalizerSupportedCultures.SupportedCultures.FirstOrDefault(w => w.CultureInfo.Equals(new CultureInfo(languageLocalizerSupportedCultures.FallbackCulture)));
            }
            if (languageLocalizerSupportedCultures.UseRemoteSourceAlwaysWhenAvailable)
            {
                result = await TryGetRemoteSourceAsync(httpClient, languageLocalizerSupportedCultures.HttpMethod, languageLocalizerSupportedCultureSelected.RemoteSource, languageLocalizerSupportedCultures.RemoteRetryTimes);
                if (result != null)
                {
                    return result;
                }
            }
            if (result == null && !languageLocalizerSupportedCultures.UseLocalSourceWhenRemoteSourceFails)
            {
                throw new Exception("We could not load the remote source of Language Localizer");
            }
            if (result == null && languageLocalizerSupportedCultures.UseLocalSourceWhenRemoteSourceFails)
            {
                if (languageLocalizerSupportedCultures.LocalSourceStrategy == SourceStrategy.FileSystem)
                {
                    result = TryGetLocalSourceFromFileSystem(languageLocalizerSupportedCultureSelected.LocalSource);
                }
                else if (languageLocalizerSupportedCultures.LocalSourceStrategy == SourceStrategy.HttpRequest)
                {
                    result = await TryGetRemoteSourceAsync(httpClient, languageLocalizerSupportedCultures.HttpMethod, languageLocalizerSupportedCultureSelected.LocalSource, languageLocalizerSupportedCultures.RemoteRetryTimes);
                }
                if (result != null)
                {
                    return result;
                }
            }
            if (result == null)
            {
                throw new Exception("We could not load neither remote or local source of Language Localizer");
            }
            return null;
        }
        private static async Task<JsonLanguageLocalizerService> TryGetRemoteSourceAsync(HttpClient httpClient, string httpMethod, string requestUri, int remoteRetryTimes)
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
        private static JsonLanguageLocalizerService TryGetLocalSourceFromFileSystem(string path)
        {
            try
            {
                return new JsonLanguageLocalizerService(File.OpenRead(path));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }
    }
}