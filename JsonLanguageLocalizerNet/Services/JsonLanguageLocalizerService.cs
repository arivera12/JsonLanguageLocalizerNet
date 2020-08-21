using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;

namespace JsonLanguageLocalizerNet
{
    public class JsonLanguageLocalizerService : IJsonLanguageLocalizerService
    {
        public JsonLanguageLocalizerService()
        {
            Configuration = new ConfigurationBuilder().Build();
        }
        public JsonLanguageLocalizerService(ConfigurationBuilder configurationBuilder)
        {
            Configuration = configurationBuilder.Build();
        }
        public JsonLanguageLocalizerService(Stream stream)
        {
            Configuration = new ConfigurationBuilder().AddJsonStream(stream).Build();
        }
        public JsonLanguageLocalizerService(string path)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile(path).Build();
        }
        public JsonLanguageLocalizerService(Action<JsonConfigurationSource> configureSource)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile(configureSource).Build();
        }
        public JsonLanguageLocalizerService(string path, bool optional)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile(path, optional).Build();
        }
        public JsonLanguageLocalizerService(string path, bool optional, bool reloadOnChange)
        {
            Configuration = new ConfigurationBuilder().AddJsonFile(path, optional, reloadOnChange).Build();
        }
        public JsonLanguageLocalizerService(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public JsonLanguageLocalizerService(IConfigurationRoot configurationRoot)
        {
            Configuration = configurationRoot;
        }
        private protected IConfiguration Configuration { get; set; }
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

        public void ChangeLanguageLocalizer(JsonLanguageLocalizerService jsonLanguageLocalizerService)
        {
            Configuration = jsonLanguageLocalizerService.Configuration;
        }
    }
}