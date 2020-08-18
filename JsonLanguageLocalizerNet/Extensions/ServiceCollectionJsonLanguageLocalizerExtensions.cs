using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;

namespace JsonLanguageLocalizerNet
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddJsonLanguageLocalizer(this IServiceCollection services)
        {
            return services.AddSingleton<IJsonLanguageLocalizerService, JsonLanguageLocalizerService>(provider => new JsonLanguageLocalizerService(new ConfigurationBuilder().Build()));
        }
        public static IServiceCollection AddJsonLanguageLocalizer(this IServiceCollection services, ConfigurationBuilder configurationBuilder)
        {
            return services.AddSingleton<IJsonLanguageLocalizerService, JsonLanguageLocalizerService>(provider => new JsonLanguageLocalizerService(configurationBuilder));
        }
        public static IServiceCollection AddJsonLanguageLocalizer(this IServiceCollection services, IConfiguration configuration)
        {
            return services.AddSingleton<IJsonLanguageLocalizerService, JsonLanguageLocalizerService>(provider => new JsonLanguageLocalizerService(configuration));
        }
        public static IServiceCollection AddJsonLanguageLocalizer(this IServiceCollection services, IConfigurationRoot configurationRoot)
        {
            return services.AddSingleton<IJsonLanguageLocalizerService, JsonLanguageLocalizerService>(provider => new JsonLanguageLocalizerService(configurationRoot));
        }
        public static IServiceCollection AddJsonLanguageLocalizer(this IServiceCollection services, Stream stream)
        {
            return services.AddSingleton<IJsonLanguageLocalizerService, JsonLanguageLocalizerService>(provider => new JsonLanguageLocalizerService(stream));
        }
        public static IServiceCollection AddJsonLanguageLocalizer(this IServiceCollection services, string path)
        {
            return services.AddSingleton<IJsonLanguageLocalizerService, JsonLanguageLocalizerService>(provider => new JsonLanguageLocalizerService(path));
        }
        public static IServiceCollection AddJsonLanguageLocalizer(this IServiceCollection services, Action<JsonConfigurationSource> configureSource)
        {
            return services.AddSingleton<IJsonLanguageLocalizerService, JsonLanguageLocalizerService>(provider => new JsonLanguageLocalizerService(configureSource));
        }
        public static IServiceCollection AddJsonLanguageLocalizer(this IServiceCollection services, string path, bool optional)
        {
            return services.AddSingleton<IJsonLanguageLocalizerService, JsonLanguageLocalizerService>(provider => new JsonLanguageLocalizerService(path, optional));
        }
        public static IServiceCollection AddJsonLanguageLocalizer(this IServiceCollection services, string path, bool optional, bool reloadOnChange)
        {
            return services.AddSingleton<IJsonLanguageLocalizerService, JsonLanguageLocalizerService>(provider => new JsonLanguageLocalizerService(path, optional, reloadOnChange));
        }
    }
}