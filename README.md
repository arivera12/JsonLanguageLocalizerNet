# JsonLanguageLocalizerNet

<p>
	<a href="https://www.nuget.org/packages/JsonLanguageLocalizerNet">
	    <img src="https://buildstats.info/nuget/JsonLanguageLocalizerNet?v=1.0.5" />
	</a>
</p>

# JsonLanguageLocalizerNet.Blazor
<p>
  	<a href="https://www.nuget.org/packages/JsonLanguageLocalizerNet.Blazor">
	    <img src="https://buildstats.info/nuget/JsonLanguageLocalizerNet.Blazor?v=1.0.5" />
	</a>
</p>

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
Install-Package JsonLanguageLocalizerNet -Version 1.0.5
//For blazor
Install-Package JsonLanguageLocalizerNet.Blazor -Version 1.0.5
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
services.AddJsonLanguageLocalizer(Action<JsonConfigurationSource> configureSource);
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
services.AddJsonLanguageLocalizerSupportedCultures(Action<JsonConfigurationSource> configureSource);
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

string applicationLocale;

//We try to lookup the locale in the browser storage
var jsRuntime = host.Services.GetRequiredService<IJSRuntime>();
applicationLocale = await jsRuntime.InvokeAsync<string>("window.localStorage.getItem", "ApplicationLocale");
if (string.IsNullOrWhiteSpace(applicationLocale))
{
    //We try use the browser navigator language
    var navigatorLanguage = await jsRuntime.InvokeAsync<string>("eval", "navigator.language");
    //If is empty we use the fallback culture
    if (string.IsNullOrWhiteSpace(navigatorLanguage))
    {
	//The navigator language is not supported then we use the fallback culture
	applicationLocale = LanguageLocalizerSupportedCultures.FallbackCulture;
    }
}
//Set the application locale with the current or fallback
await jsRuntime.InvokeAsync<string>("window.localStorage.setItem", "ApplicationLocale", applicationLocale);

//Set's the default thread current culture
var cultureInfo = new CultureInfo(applicationLocale);
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
	    
//Loads the jsonLanguageLocalizer service 
var jsonLanguageLocalizer = host.Services.GetRequiredService<IJsonLanguageLocalizerService>();

//Loads the service with the source by the specified application locale
var jsonLanguageLocalizerService = await host.GetJsonLanguageLocalizerServiceFromSupportedCulturesAsync(httpClient, LanguageLocalizerSupportedCultures, applicationLocale);

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

## Developer Farewell Note
	
It has been a lifetime for me to work as a developer, as an employee as well as a professional service provider, but it is very sad to have been working for the last 12 years on more than 40+ projects in the banking industry, payment processing, government applications, web servers, databases, reports, web and mobile applications, github contributions in different projects including my personal ones and never see economic growth.

I have been exploited, I have even done developments that gave me half or less or they never paid me even under contracts.

Once, some time ago, I developed an application to serve and help citizens and the same government ended up giving the idea to a third service provider who developed it and were the ones who sold it to them and to other entities.

That filled me with a lot of anger and frustration because I wasted 1 year of my life for nothing, just like the 12 that I currently have.

I have always had good will together with many ideas of how to change the way we develop, but nobody has given me the opportunity to be heard and I have never had a problem that I could not solve, because I solve problems by the nature of my profession.

My idea of ​​programming templates and functionalities has been an idea that took me about 8 years to perfect and that would save any entity millions in development costs but nobody seems to see the fruit of the effort I have put into it.

I have submitted my development tool and no one seems to be interested, I have contacted microsoft several times, I have contacted PRITS several times and have never been answered.

I tried to sell my product on various sites and well I have reached a point in my life where I am very frustrated, unfocused and no longer feel love or passion for what I do.

I have completely lost interest in everything in life and honestly I have a family to support and I have lost what little I had when I have never had anything in my life.

I come from a poor and dysfunctional family who have never supported me.

That is not why you have to follow the same negative pattern.

You and all of us can make a difference, but when you are poor the things around you are almost like a curse.

It takes much more than good ideas to be successful, you have to have connections, you have to have a good presentation, you have to be tactful when speaking and know how to sell, you have to know how to implement things correctly by phase, you have to have a reputation for everything.

Surround yourself with positive people who are willing to help you or they are not affected by seeing you grow but that is where I have unintentionally failed.

Family circles and friends who have never given me any help or support and there is nothing worse than looking back and seeing how long I have walked alone, then I look at the present and I am still just as alone and there is no way to progress in that way.

You have to open your eyes, take a deep breath, see things as they are and know when to retire with dignity.

I don't know if I'll be back tomorrow, I just don't know.

I only leave this note here for interested developers to contribute.

I will leave everything there public and transparent as I have always been.

Life is hard, and when you cling to something that is hurting you, just let it go and seek to change your path.

I wish that many people benefit from my contributions and ideas, that at least my lost time will save time for other developers.

Of what one day was a dream for me, has been thrown into darkness.
