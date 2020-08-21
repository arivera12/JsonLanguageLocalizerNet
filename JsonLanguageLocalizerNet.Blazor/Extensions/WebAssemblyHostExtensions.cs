using BlazorBrowserStorage;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace JsonLanguageLocalizerNet.Blazor
{
    public static class WebAssemblyHostExtension
    {
        /// <summary>
        /// Sets the DefaultThreadCurrentCulture && DefaultThreadCurrentUICulture for the application.  
        /// </summary>
        /// <param name="webAssemblyHost"></param>
        /// <param name="fallbackCulture"></param>
        /// <returns></returns>
        public static async Task SetBlazorCurrentThreadCultureFromJsonLanguageLocalizerSupportedCulturesServiceAsync(this WebAssemblyHost webAssemblyHost, string fallbackCulture)
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
            var localStorage = webAssemblyHost.Services.GetRequiredService<ILocalStorage>();
            var applicationLocale = await localStorage.GetItem<string>("ApplicationLocale");
            if (string.IsNullOrWhiteSpace(applicationLocale))
            {
                //We try use the browser navigator language
                await webAssemblyHost.TryInitializeJsonLanguageLocalizerSupportedCulturesServiceFromNavigatorLanguageAsync(fallbackCulture);
            }
            else
            {
                //we check that the application locale from the browser storage is supported
                if (supportedCultures.GetLanguageLocalizerSupportedCultures().SupportedCultures.Any(w => w.Name == applicationLocale))
                {
                    //We use the browser storage locale since it's supported
                    InitializeDefaultThreadCurrentCultureAndUI(applicationLocale);
                }
                else
                {
                    //We try use the browser navigator language
                    await webAssemblyHost.TryInitializeJsonLanguageLocalizerSupportedCulturesServiceFromNavigatorLanguageAsync(fallbackCulture);
                }
            }
        }
        private static async Task TryInitializeJsonLanguageLocalizerSupportedCulturesServiceFromNavigatorLanguageAsync(this WebAssemblyHost webAssemblyHost, string fallbackCulture)
        {
            var supportedCultures = webAssemblyHost.Services.GetRequiredService<IJsonLanguageLocalizerSupportedCulturesService>();
            //We try to lookup the locale from the navigator language
            var jsInterop = webAssemblyHost.Services.GetRequiredService<IJSRuntime>();
            var navigatorLanguage = await jsInterop.InvokeAsync<string>("eval", "navigator.language");
            //If is empty we use the fallback culture
            if (string.IsNullOrWhiteSpace(navigatorLanguage))
            {
                //The navigator language is not supported then we use the fallback culture
                InitializeDefaultThreadCurrentCultureAndUI(fallbackCulture);
            }
            else
            {
                //We check the navigator language is supported
                if (supportedCultures.GetLanguageLocalizerSupportedCultures().SupportedCultures.Any(w => w.Name == navigatorLanguage))
                {
                    //We use the navigator language culture since it's supported
                    InitializeDefaultThreadCurrentCultureAndUI(navigatorLanguage);
                }
                else
                {
                    //The navigator language is not supported then we use the fallback culture
                    InitializeDefaultThreadCurrentCultureAndUI(fallbackCulture);
                }
            }
        }
        private static void InitializeDefaultThreadCurrentCultureAndUI(string name)
        {
            var cultureInfo = new CultureInfo(name);
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
            CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
        }
    }
}


