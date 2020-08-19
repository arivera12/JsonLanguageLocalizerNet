using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JsonLanguageLocalizerNet
{
    public class LanguageLocalizerSupportedCultures
    {
        [JsonPropertyName("supportedCultures")]
        public IEnumerable<SupportedCultures> SupportedCultures { get; set; }
        [JsonPropertyName("useRemoteSourceAlwaysWhenAvailable")]
        public bool UseRemoteSourceAlwaysWhenAvailable { get; set; }
        [JsonPropertyName("useLocalSourceWhenRemoteSourceFails")]
        public bool UseLocalSourceWhenRemoteSourceFails { get; set; }
        [JsonPropertyName("remoteRetryTimes")]
        public int RemoteRetryTimes { get; set; }
    }
}
