using Microsoft.Extensions.Configuration;

namespace JsonLanguageLocalizerNet
{
    /// <summary>
    /// This service manage language localization supported cultures using IConfiguration
    /// </summary>
    public interface IJsonLanguageLocalizerSupportedCulturesService : IConfiguration
    {
        /// <summary>
        /// This method specs that the configuration file is on the expected format of <see cref="LanguageLocalizerSupportedCultures"/>.
        /// </summary>
        /// <returns></returns>
        LanguageLocalizerSupportedCultures GetLanguageLocalizerSupportedCultures();
    }
}
