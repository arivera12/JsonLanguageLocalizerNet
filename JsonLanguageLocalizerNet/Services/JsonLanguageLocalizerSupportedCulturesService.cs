using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;

namespace JsonLanguageLocalizerNet
{
    public class JsonLanguageLocalizerSupportedCulturesService : IJsonLanguageLocalizerSupportedCulturesService
    {
        public JsonLanguageLocalizerSupportedCulturesService()
        {
            Configuration = new ConfigurationBuilder().Build();
        }
        public JsonLanguageLocalizerSupportedCulturesService(ConfigurationBuilder configurationBuilder)
        {
            Configuration = configurationBuilder.Build();
        }
        public JsonLanguageLocalizerSupportedCulturesService(Stream stream)
        {
            Configuration = new ConfigurationBuilder().AddJsonStream(stream).Build();
        }
        public JsonLanguageLocalizerSupportedCulturesService(string path)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile(path).Build();
        }
        public JsonLanguageLocalizerSupportedCulturesService(Action<JsonConfigurationSource> configureSource)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile(configureSource).Build();
        }
        public JsonLanguageLocalizerSupportedCulturesService(string path, bool optional)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile(path, optional).Build();
        }
        public JsonLanguageLocalizerSupportedCulturesService(string path, bool optional, bool reloadOnChange)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile(path, optional, reloadOnChange).Build();
        }
        public JsonLanguageLocalizerSupportedCulturesService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public JsonLanguageLocalizerSupportedCulturesService(IConfigurationRoot configurationRoot)
        {
            Configuration = configurationRoot;
        }
        private IConfiguration Configuration { get; set; }
        public string this[string key] { get => Configuration[key]; set => _ = value; }
        public IEnumerable<IConfigurationSection> GetChildren()
        {
            return Configuration.GetChildren();
        }
        public IChangeToken GetReloadToken()
        {
            return Configuration.GetReloadToken();
        }
        public IConfigurationSection GetSection(string key)
        {
            return Configuration.GetSection(key);
        }
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public LanguageLocalizerSupportedCultures GetLanguageLocalizerSupportedCultures()
        {
            return Configuration.Get<LanguageLocalizerSupportedCultures>();
        }

        public void ChangeLanguageLocalizerSupportedCultures(JsonLanguageLocalizerSupportedCulturesService jsonLanguageLocalizerSupportedCulturesService)
        {
            Configuration = jsonLanguageLocalizerSupportedCulturesService.Configuration;
        }
    }
}
