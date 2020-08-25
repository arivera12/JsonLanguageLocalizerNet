using JsonLanguageLocalizerNet.Blazor.Helpers;
using JsonLanguageLocalizerNet.Helpers;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace JsonLanguageLocalizerNet.Blazor
{
    public static class WebAssemblyHostExtension
    {
        /// <summary>
        /// Sets the DefaultThreadCurrentCulture && DefaultThreadCurrentUICulture for the application.
        /// Take note that localStorageKey default value ApplicationLocale is compatible with OneLine Framework implementation.
        /// </summary>
        /// <param name="webAssemblyHost"></param>
        /// <param name="fallbackCulture"></param>
        /// <param name="localStorageKey"></param>
        /// <returns></returns>
        public static async Task SetBlazorCurrentThreadCultureFromJsonLanguageLocalizerSupportedCulturesServiceAsync(this WebAssemblyHost webAssemblyHost, string fallbackCulture, string localStorageKey = "ApplicationLocale")
        {
            var supportedCultures = webAssemblyHost.Services.GetRequiredService<IJsonLanguageLocalizerSupportedCulturesService>();
            //Verify that there is at least one supported culture
            if (!supportedCultures.GetLanguageLocalizerSupportedCultures().SupportedCultures.Any())
            {
                throw new Exception("There is no supported cultures defined. Make sure there is at least one supported language.");
            }
            //Verify that fallback culture is included in the supported cultures
            if (!supportedCultures.GetLanguageLocalizerSupportedCultures().SupportedCultures.Any(w => w.Name == fallbackCulture))
            {
                throw new ArgumentException($"The fallbackCulture value ({fallbackCulture}) could not be found the supported cultures. The fallbackCulture value must be included in the suppoted cultures.");
            }
            //We try to lookup the locale in the browser storage
            var jsRuntime = webAssemblyHost.Services.GetRequiredService<IJSRuntime>();
            var applicationLocale = await jsRuntime.InvokeAsync<string>("window.localStorage.getItem", localStorageKey);
            if (string.IsNullOrWhiteSpace(applicationLocale))
            {
                //We try use the browser navigator language
                await webAssemblyHost.TryInitializeJsonLanguageLocalizerSupportedCulturesServiceFromNavigatorLanguageAsync(fallbackCulture, localStorageKey);
            }
            else
            {
                //we check that the application locale from the browser storage is supported
                if (supportedCultures.GetLanguageLocalizerSupportedCultures().SupportedCultures.Any(w => w.Name == applicationLocale))
                {
                    //We use the browser storage locale since it's supported
                    await webAssemblyHost.InitializeDefaultThreadCurrentCultureAndUIAsync(applicationLocale, localStorageKey);
                }
                else
                {
                    //We try use the browser navigator language
                    await webAssemblyHost.TryInitializeJsonLanguageLocalizerSupportedCulturesServiceFromNavigatorLanguageAsync(fallbackCulture, localStorageKey);
                }
            }
        }
        private static async Task TryInitializeJsonLanguageLocalizerSupportedCulturesServiceFromNavigatorLanguageAsync(this WebAssemblyHost webAssemblyHost, string fallbackCulture, string localStorageKey)
        {
            var supportedCultures = webAssemblyHost.Services.GetRequiredService<IJsonLanguageLocalizerSupportedCulturesService>();
            //We try to lookup the locale from the navigator language
            var jsInterop = webAssemblyHost.Services.GetRequiredService<IJSRuntime>();
            var navigatorLanguage = await jsInterop.InvokeAsync<string>("eval", "navigator.language");
            //If is empty we use the fallback culture
            if (string.IsNullOrWhiteSpace(navigatorLanguage))
            {
                //The navigator language is not supported then we use the fallback culture
                await webAssemblyHost.InitializeDefaultThreadCurrentCultureAndUIAsync(fallbackCulture, localStorageKey);
            }
            else
            {
                //We check the navigator language is supported
                if (supportedCultures.GetLanguageLocalizerSupportedCultures().SupportedCultures.Any(w => w.Name == navigatorLanguage))
                {
                    //We use the navigator language culture since it's supported
                    await webAssemblyHost.InitializeDefaultThreadCurrentCultureAndUIAsync(navigatorLanguage, localStorageKey);
                }
                else
                {
                    //The navigator language is not supported then we use the fallback culture
                    await webAssemblyHost.InitializeDefaultThreadCurrentCultureAndUIAsync(fallbackCulture, localStorageKey);
                }
            }
        }
        private static async Task InitializeDefaultThreadCurrentCultureAndUIAsync(this WebAssemblyHost webAssemblyHost, string name, string localStorageKey)
        {
            var jsRuntime = webAssemblyHost.Services.GetRequiredService<IJSRuntime>();
            await jsRuntime.InvokeAsync<string>("window.localStorage.setItem", localStorageKey, name);
            var cultureInfo = new CultureInfo(name);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
        /// <summary>
        /// Loads the json file into the service using the supported cultures service within the desired strategy and loading preference. 
        /// </summary>
        /// <param name="webAssemblyHost"></param>
        /// <returns></returns>
        public static async Task<JsonLanguageLocalizerService> GetJsonLanguageLocalizerServiceFromSupportedCulturesAsync(this WebAssemblyHost webAssemblyHost, HttpClient httpClient, LanguageLocalizerSupportedCultures languageLocalizerSupportedCultures, string localStorageKey = "ApplicationLocale")
        {
            if (!languageLocalizerSupportedCultures.SupportedCultures.Any())
            {
                throw new Exception("There is no supported cultures defined. Make sure there is at least one supported language.");
            }
            JsonLanguageLocalizerService result = null;
            var jsRuntime = webAssemblyHost.Services.GetRequiredService<IJSRuntime>();
            var applicationLocale = await jsRuntime.InvokeAsync<string>("window.localStorage.getItem", localStorageKey);
            var languageLocalizerSupportedCultureSelected = languageLocalizerSupportedCultures.SupportedCultures.FirstOrDefault(w => w.Name == applicationLocale);
            if (languageLocalizerSupportedCultureSelected == null)
            {
                languageLocalizerSupportedCultureSelected = languageLocalizerSupportedCultures.SupportedCultures.FirstOrDefault(w => w.CultureInfo.Equals(new CultureInfo(languageLocalizerSupportedCultures.FallbackCulture)));
            }
            if (languageLocalizerSupportedCultures.UseRemoteSourceAlwaysWhenAvailable)
            {
                result = await JsonLanguageLocalizerServiceBlazorHelper.TryGetRemoteSourceAsync(httpClient, languageLocalizerSupportedCultures.HttpMethod, languageLocalizerSupportedCultureSelected.RemoteSource, languageLocalizerSupportedCultures.RemoteRetryTimes);
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
                    result = JsonLanguageLocalizerServiceHelper.TryGetLocalSourceFromFileSystem(languageLocalizerSupportedCultureSelected.LocalSource);
                }
                else if (languageLocalizerSupportedCultures.LocalSourceStrategy == SourceStrategy.HttpRequest)
                {
                    result = await JsonLanguageLocalizerServiceHelper.TryGetRemoteSourceAsync(httpClient, languageLocalizerSupportedCultures.HttpMethod, languageLocalizerSupportedCultureSelected.LocalSource, languageLocalizerSupportedCultures.RemoteRetryTimes);
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
    }
}


