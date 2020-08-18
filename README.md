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
  
## Why I would use JsonLanguageLocalizerNet over Microsoft Resource Manager?

You may use JsonLanguageLocalizerNet over Resource Manager if:

- [x] Wording may or could be changed over time.
- [x] Translations can be remotely accessed.
- [x] Application needs to be as lightweight as possible.
- [x] New languages are added over time.

Take note that including *.resx for every language will make your app output build bigger over time.

Take note that adding support to a new language remotely doesn't never need recompiling and/or deploying.

## TODO - DOCUMENTATION

### IJsonLanguageLocalizerService

### JsonLanguageLocalizerService

### IJsonLanguageLocalizerSupportedCulturesService

### JsonLanguageLocalizerSupportedCulturesService
