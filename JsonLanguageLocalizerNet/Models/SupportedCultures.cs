using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace JsonLanguageLocalizerNet
{
    public class LanguageLocalizerSupportedCultures
    {
        [JsonPropertyName("supportedCultures")]
        public IEnumerable<string> SupportedCultures { get; set; }
    }
}
