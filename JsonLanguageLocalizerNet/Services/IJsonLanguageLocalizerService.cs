using Microsoft.Extensions.Configuration;

namespace JsonLanguageLocalizerNet
{
    /// <summary>
    /// This service manage language localization using IConfiguration
    /// </summary>
    public interface IJsonLanguageLocalizerService : IConfiguration
    {
        void ChangeLanguageLocalizer(JsonLanguageLocalizerService jsonLanguageLocalizerService);
    }
}
