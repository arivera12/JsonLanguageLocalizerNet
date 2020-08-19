using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Globalization;

namespace JsonLanguageLocalizerNet
{
    /// <summary>
    /// This service manage language localization supported cultures using IConfiguration
    /// </summary>
    public interface IJsonLanguageLocalizerSupportedCulturesService : IConfiguration
    {
        /// <summary>
        /// This method specs that the configuration file is on the expected format of <see cref="LanguageLocalizerSupportedCultures"/> and returns a enumerable of cultureinfo.
        /// </summary>
        /// <returns></returns>
        IEnumerable<CultureInfo> GetLanguageLocalizerSupportedCulturesInfos();
    }
}
