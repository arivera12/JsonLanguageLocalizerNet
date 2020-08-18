# JsonLanguageLocalizerNet

JsonLanguageLocalizerNet is an alternative to Microsoft's ResourceManager. 

JsonLanguageLocalizerNet manage language localizations by using a json file instead of *.resx file. 

## Features
- [x] Lightweight
- [x] Human Readable
- [x] Extendable
- [x] Portable
- [x] Supports: 
  - [x] String notation
  - [x] Strong data types
  - [x] Json nested structures
  - [x] Reloading when file changes (Disk load)
  - [x] Loading from
    - [x] Disk
    - [x] Network
## Installation

`Install-Package JsonLanguageLocalizerNet -Version 1.0.0`

## Register the services in your services method

### IJsonLanguageLocalizerService

```
services.AddJsonLanguageLocalizer();
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

`IJsonLanguageLocalizerService JsonLanguageLocalizerService { get; set; }`

`IJsonLanguageLocalizerSupportedCulturesService JsonLanguageLocalizerSupportedCulturesService { get; set; }`

### IJsonLanguageLocalizerService Methods

- [IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration?view=dotnet-plat-ext-3.1)

### JsonLanguageLocalizerService Methods

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

- [IConfiguration](https://docs.microsoft.com/en-us/dotnet/api/microsoft.extensions.configuration.iconfiguration?view=dotnet-plat-ext-3.1)
- IEnumerable&lt;CultureInfo&gt; GetLanguageLocalizerSupportedCulturesInfos()

Take note that `GetLanguageLocalizerSupportedCulturesInfos()` specs that the json structure is an object of type of `LanguageLocalizerSupportedCultures` which it's as simple structure as this:

`{ "supportedCultures": ["en-US", "en", "es"] }`

If you want to name this something else then you manage this on your own. 

I still invite you to use the built-in supported structure.

### JsonLanguageLocalizerSupportedCulturesService Methods

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

## Why I would use JsonLanguageLocalizerNet over Microsoft Resource Manager?

You may use JsonLanguageLocalizerNet over Resource Manager if:

- [x] Wording may or could be changed over time.
- [x] Translations can be remotely accessed.
- [x] Application needs to be as lightweight as possible.
- [x] New languages are added over time.

Take note that including *.resx for every in language in your application will make your application build output bigger over time.

Take note that adding support to a new language remotely doesn't never need compiling and deploying, were .resx needs all this extra work since it's need to be compiled.

## License
MIT
