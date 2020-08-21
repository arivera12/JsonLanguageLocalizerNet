using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace JsonLanguageLocalizerNet
{
    public class LanguageLocalizerSupportedCultures
    {
        [JsonPropertyName("supportedCultures")]
        public IEnumerable<SupportedCultures> SupportedCultures { get; set; }
        [JsonPropertyName("fallbackCulture")]
        public string FallbackCulture { get; set; }
        [JsonPropertyName("httpMethod")]
        public string HttpMethod { get; set; }
        [JsonPropertyName("useRemoteSourceAlwaysWhenAvailable")]
        public bool UseRemoteSourceAlwaysWhenAvailable { get; set; }
        [JsonPropertyName("useLocalSourceWhenRemoteSourceFails")]
        public bool UseLocalSourceWhenRemoteSourceFails { get; set; }
        [JsonPropertyName("localSourceStrategy")]
        public SourceStrategy LocalSourceStrategy { get; set; }
        [JsonPropertyName("remoteRetryTimes")]
        public int RemoteRetryTimes { get; set; }
    }
}
