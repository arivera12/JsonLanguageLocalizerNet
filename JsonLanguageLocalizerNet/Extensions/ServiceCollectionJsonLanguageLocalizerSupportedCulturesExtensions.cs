using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace JsonLanguageLocalizerNet
{
    public static partial class ServiceCollectionExtensions
    {                   
        public static IServiceCollection AddJsonLanguageLocalizerSupportedCultures(this IServiceCollection services)
        {
            return services.AddSingleton<IJsonLanguageLocalizerSupportedCulturesService, JsonLanguageLocalizerSupportedCulturesService>(provider => new JsonLanguageLocalizerSupportedCulturesService(new ConfigurationBuilder().Build()));
        }
        public static IServiceCollection AddJsonLanguageLocalizerSupportedCultures(this IServiceCollection services, ConfigurationBuilder configurationBuilder)
        {
            return services.AddSingleton<IJsonLanguageLocalizerSupportedCulturesService, JsonLanguageLocalizerSupportedCulturesService>(provider => new JsonLanguageLocalizerSupportedCulturesService(configurationBuilder));
        }
        public static IServiceCollection AddJsonLanguageLocalizerSupportedCultures(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton<IJsonLanguageLocalizerSupportedCulturesService, JsonLanguageLocalizerSupportedCulturesService>(provider => new JsonLanguageLocalizerSupportedCulturesService(configuration));
        }
        public static IServiceCollection AddJsonLanguageLocalizerSupportedCultures(this IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            return services.AddSingleton<IJsonLanguageLocalizerSupportedCulturesService, JsonLanguageLocalizerSupportedCulturesService>(provider => new JsonLanguageLocalizerSupportedCulturesService(configurationRoot));
        }
        public static IServiceCollection AddJsonLanguageLocalizerSupportedCultures(this IServiceCollection services, Stream stream)
        {
            return services.AddSingleton<IJsonLanguageLocalizerSupportedCulturesService, JsonLanguageLocalizerSupportedCulturesService>(provider => new JsonLanguageLocalizerSupportedCulturesService(stream));
        }
        public static IServiceCollection AddJsonLanguageLocalizerSupportedCultures(this IServiceCollection services, string path)
        {
            return services.AddSingleton<IJsonLanguageLocalizerSupportedCulturesService, JsonLanguageLocalizerSupportedCulturesService>(provider => new JsonLanguageLocalizerSupportedCulturesService(path));
        }
        public static IServiceCollection AddJsonLanguageLocalizerSupportedCultures(this IServiceCollection services, Action<JsonConfigurationSource> configureSource)
        {
            return services.AddSingleton<IJsonLanguageLocalizerSupportedCulturesService, JsonLanguageLocalizerSupportedCulturesService>(provider => new JsonLanguageLocalizerSupportedCulturesService(configureSource));
        }
        public static IServiceCollection AddJsonLanguageLocalizerSupportedCultures(this IServiceCollection services, string path, bool optional)
        {
            return services.AddSingleton<IJsonLanguageLocalizerSupportedCulturesService, JsonLanguageLocalizerSupportedCulturesService>(provider => new JsonLanguageLocalizerSupportedCulturesService(path, optional));
        }
        public static IServiceCollection AddJsonLanguageLocalizerSupportedCultures(this IServiceCollection services, string path, bool optional, bool reloadOnChange)
        {
            return services.AddSingleton<IJsonLanguageLocalizerSupportedCulturesService, JsonLanguageLocalizerSupportedCulturesService>(provider => new JsonLanguageLocalizerSupportedCulturesService(path, optional, reloadOnChange));
        }
    }
}