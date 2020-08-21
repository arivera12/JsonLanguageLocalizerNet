using System.Globalization;
using System.Text.Json.Serialization;

namespace JsonLanguageLocalizerNet
{
    public class SupportedCultures
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("localSource")]
        public string LocalSource { get; set; }
        [JsonPropertyName("remoteSource")]
        public string RemoteSource { get; set; }
        [JsonIgnore]
        private CultureInfo cultureInfo { get; set; }
        [JsonIgnore]
        public CultureInfo CultureInfo
        {
            get
            {
                if (cultureInfo == null)
                {
                    cultureInfo = new CultureInfo(Name);
                }
                return cultureInfo;
            }
        }
    }
}
