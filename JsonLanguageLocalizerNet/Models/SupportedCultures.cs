using System.Globalization;
using System.Text.Json.Serialization;

namespace JsonLanguageLocalizerNet
{
    public class SupportedCultures
    {
        [JsonPropertyName("name")]
        public string Name { get; set; }
        [JsonPropertyName("localUri")]
        public string LocalUri { get; set; }
        [JsonPropertyName("remoteUri")]
        public string RemoteUri { get; set; }
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
