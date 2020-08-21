# JsonLanguageLocalizerNet

JsonLanguageLocalizerNet is an alternative to Microsoft's ResourceManager. 

JsonLanguageLocalizerNet manage language localizations by using a json file instead of *.resx file. 

## Features

- [x] String notation
- [x] Strong data types
- [x] Json nested structures
- [x] Reloading when file changes (Disk load only)
- [x] Loading from
  - [x] Disk
  - [x] Network
- [x] Change culture and/or translations with or without reloading
- [x] Integrations
  - [x] AspNetCore (Manually, Auto Integration With Supported Cultures Soon)
  - [x] Xamarin (Manually, Auto Integration With Supported Cultures Soon)
  - [x] Blazor Wasm & Server (Auto Integrated With Supported Cultures)
  - [x] Everywhere .net is able to run
  
## Installation

```
Install-Package JsonLanguageLocalizerNet -Version 1.0.0
//For blazor
Install-Package JsonLanguageLocalizerNet.Blazor -Version 1.0.0
```

## Register the services in your services method

### IJsonLanguageLocalizerService

```
services.AddJsonLanguageLocalizer();
services.AddJsonLanguageLocalizer(sonLanguageLocalizerService jsonLanguageLocalizerService);
services.AddJsonLanguageLocalizer(Func<IServiceProvider, JsonLanguageLocalizerService> provider);
services.AddJsonLanguageLocalizer(ConfigurationBuilder configurationBuilder);
services.AddJsonLanguageLocalizer(IConfiguration configuration);
services.AddJsonLanguageLocalizer(IConfigurationRoot configurationRoot);
services.AddJsonLanguageLocalizer(Stream stream);
services.AddJsonLanguageLocalizer(string path);
services.AddJsonLanguageLocalizerAction<JsonConfigurationSource> configureSource);
services.AddJsonLanguageLocalizer(string path, bool optional);
services.AddJsonLanguageLocalizer(string path, bool optional, bool reloadOnChange);
```

Take note that the default constructor register the instance without any data loaded.

Data should be provided when registering the service but it can be loaded/overrided at any time since it's a singleton service.

### IJsonLanguageLocalizerSupportedCulturesService

```
services.AddJsonLanguageLocalizerSupportedCultures();
services.AddJsonLanguageLocalizerSupportedCultures(JsonLanguageLocalizerSupportedCulturesService jsonLanguageLocalizerSupportedCulturesService);
services.AddJsonLanguageLocalizerSupportedCultures(Func<IServiceProvider, JsonLanguageLocalizerSupportedCulturesService> provider);
services.AddJsonLanguageLocalizerSupportedCultures(ConfigurationBuilder configurationBuilder);
services.AddJsonLanguageLocalizerSupportedCultures(IConfiguration configuration);
services.AddJsonLanguageLocalizerSupportedCultures(IConfigurationRoot configurationRoot);
services.AddJsonLanguageLocalizerSupportedCultures(Stream stream);
services.AddJsonLanguageLocalizerSupportedCultures(string path);
services.AddJsonLanguageLocalizerSupportedCultures<JsonConfigurationSource> configureSource);
services.AddJsonLanguageLocalizerSupportedCultures(string path, bool optional);
services.AddJsonLanguageLocalizerSupportedCultures(string path, bool optional, bool reloadOnChange);
```

Take note that the default constructor register the instance without any data loaded.

Data should be provided when registering the service but it can be loaded/overrided at any time since it's a singleton service.

## Usage

```
IJsonLanguageLocalizerService JsonLanguageLocalizerService { get; set; }

IJsonLanguageLocalizerSupportedCulturesService JsonLanguageLocalizerSupportedCulturesService { get; set; }
```

### IJsonLanguageLocalizerService Methods

```
void ChangeLanguageLocalizer(JsonLanguageLocalizerService jsonLanguageLocalizerService);
```

- [IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration?view=dotnet-plat-ext-3.1)

### JsonLanguageLocalizerService Methods

```
void ChangeLanguageLocalizer(JsonLanguageLocalizerService jsonLanguageLocalizerService);
```

- [IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration?view=dotnet-plat-ext-3.1)

```
public JsonLanguageLocalizerService();
public JsonLanguageLocalizerService(ConfigurationBuilder configurationBuilder);
public JsonLanguageLocalizerService(Stream stream);
public JsonLanguageLocalizerService(string path);
public JsonLanguageLocalizerService(Action<JsonConfigurationSource> configureSource);
public JsonLanguageLocalizerService(string path, bool optional);
public JsonLanguageLocalizerService(string path, bool optional, bool reloadOnChange);
public JsonLanguageLocalizerService(IConfiguration configuration);
public JsonLanguageLocalizerService(IConfigurationRoot configurationRoot);
```

### IJsonLanguageLocalizerSupportedCulturesService Methods

```
void ChangeLanguageLocalizerSupportedCultures(JsonLanguageLocalizerSupportedCulturesService jsonLanguageLocalizerSupportedCulturesService);
LanguageLocalizerSupportedCultures GetLanguageLocalizerSupportedCultures();
```

- [IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration?view=dotnet-plat-ext-3.1)

Take note that `GetLanguageLocalizerSupportedCultures()` specs that the json structure is an object of type of `LanguageLocalizerSupportedCultures`.

```
{
  "supportedCultures": [
    {
      "name": "en",
      "localSource": "/locales/en.json",
      "remoteSource": "https://www.myawesomedomain.com/cultures/en.json"
    },
    {
      "name": "es",
      "localSource": "/locales/es.json",
      "remoteSource": "https://www.myawesomedomain.com/cultures/es.json"
    }
  ],
  "fallbackCulture": "en",
  "httpMethod": "GET",
  "useRemoteSourceAlwaysWhenAvailable": true,
  "useLocalSourceWhenRemoteSourceFails": true,
  "localSourceStrategy": 0, //0 - FileSystem, 1 - HttpClient
  "remoteRetryTimes": 3
}
```

If you want to name this something else then you manage this on your own. 

I still invite you to use the built-in supported structure.

### JsonLanguageLocalizerSupportedCulturesService Methods

```
void ChangeLanguageLocalizerSupportedCultures(JsonLanguageLocalizerSupportedCulturesService jsonLanguageLocalizerSupportedCulturesService);
LanguageLocalizerSupportedCultures GetLanguageLocalizerSupportedCultures();
```

- [IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration?view=dotnet-plat-ext-3.1)

```
public JsonLanguageLocalizerSupportedCulturesService();
public JsonLanguageLocalizerSupportedCulturesService(ConfigurationBuilder configurationBuilder);
public JsonLanguageLocalizerSupportedCulturesService(Stream stream);
public JsonLanguageLocalizerSupportedCulturesService(string path);
public JsonLanguageLocalizerSupportedCulturesService(Action<JsonConfigurationSource> configureSource);
public JsonLanguageLocalizerSupportedCulturesService(string path, bool optional);
public JsonLanguageLocalizerSupportedCulturesService(string path, bool optional, bool reloadOnChange);
public JsonLanguageLocalizerSupportedCulturesService(IConfiguration configuration);
public JsonLanguageLocalizerSupportedCulturesService(IConfigurationRoot configurationRoot);
```

## Blazor Example

```
using JsonLanguageLocalizerNet;
using JsonLanguageLocalizerNet.Blazor;
using JsonLanguageLocalizerNet.Blazor.Helpers;

..//Omitted for brevity

WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);

var httpClient = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };

builder.Services.AddTransient(sp => httpClient);

var LanguageLocalizerSupportedCultures = await httpClient.GetJsonAsync<LanguageLocalizerSupportedCultures>("cultures/supported.json");

builder.Services
.AddJsonLanguageLocalizerSupportedCultures(new MemoryStream(Encoding.ASCII.GetBytes(Newtonsoft.Json.JsonConvert.SerializeObject(LanguageLocalizerSupportedCultures))));

builder.Services.AddJsonLanguageLocalizer();

... //Continue others service registrations

WebAssemblyHost host = builder.Build();

//Sets the Current Thread Culture Info
await host.SetBlazorCurrentThreadCultureFromJsonLanguageLocalizerSupportedCulturesServiceAsync(LanguageLocalizerSupportedCultures.FallbackCulture);

//Loads the jsonLanguageLocalizer service 
var jsonLanguageLocalizer = host.Services.GetRequiredService<IJsonLanguageLocalizerService>();

//Loads the service with the source by the current thread culture info
var jsonLanguageLocalizerService = await JsonLanguageLocalizerServiceHelper.GetJsonLanguageLocalizerServiceFromSupportedCulturesAsync(httpClient, LanguageLocalizerSupportedCultures);

//Initializes the jsonLanguageLocalizer service
jsonLanguageLocalizer.ChangeLanguageLocalizer(jsonLanguageLocalizerService);

await host.RunAsync();
```

This example works with Blazor WASM.

For Blazor Server/MVC/Web Api this may work as well but you should use the overloads which reads from the web server path instead of the http client, since it's more faster and efficient.

I will provide Blazor Server/MVC/Web Api examples later.

## Frequently Asked Questions

### What are the benefits for JsonLanguageLocalizerNet over Microsoft Resource Manager?

The benefits are:

- [x] No need of compiling
- [x] Lightweight structure over the wire compared to .resx (.xml)
- [x] Supports compression algorithms
- [x] Human Readable
- [x] Shareable
- [x] Extendable
- [x] Portable to other platforms
- [x] Remotely accessible or Embeddable (embedding is not recommended)

### Why I would use JsonLanguageLocalizerNet over Microsoft Resource Manager?

You may use JsonLanguageLocalizerNet over Resource Manager if:

- [x] Wording may or could be changed over time.
- [x] Translations can be remotely accessed.
- [x] Application needs to be as lightweight as possible.
- [x] New languages are added frequently over time.

Take note that including *.resx for every in language in your application will make your application build output bigger over time.

Take note that adding support to a new language remotely doesn't never need compiling and deploying, were .resx needs all this extra work since it's need to be compiled.

## License

MIT
