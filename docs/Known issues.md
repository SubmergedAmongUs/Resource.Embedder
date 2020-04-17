# Known issues

## Compatibility issue with Fody/Costura

There is an incompatibility with Fody 4.x, I suggest you upgrade to Fody 5.0.6+ or downgrade to Costura 3.3.2 (which uses Fody \< 4).

Fody 4 embeds its class multiple times into the same assembly if used in conjunction with resource embedder. This will cause a BadImageException on launch ([#13](https://github.com/MarcStan/Resource.Embedder/issues/13)).

## SDK style project + PostBuild

If you use this combination **and** you happen to run something like `xcopy * *` to copy all your files elsewhere, you will find that the culture folders are included in the postbuild. This is due to the cleanup running after the postbuild event.

I recommend you use "dotnet publish" instead (with -o you can specific where to copy the files to) as the cleanup runs before publish

## .Net Core deps file

If you build or publish a .Net Core app, it will have a *.deps.json file that is required to run.

The .Net Core host inspects them at runtime to verify all required dependencies can be found.

Inside the file you will still find sections that reference the satellite assemblies even though the files don't exist on disk anymore.

``` json
"resources": {
  "de/DemoWebAppDotNetCore.resources.dll": {
  "locale": "fr"
}
```
The .Net runtime will thus issue [runtime warnings](https://github.com/Fody/Costura/issues/358#issuecomment-460785377) as it expects the files to exist on disk.

Despite these warnings the .Net Core app will run just fine and is automatically & correctly localized (as the satellite assembles are loaded from the dll's resources) .

 These warnings can be ignored at runtime however if you use `dotnet pack` to generate a nuget package you will run into [this error](https://github.com/MarcStan/resource-embedder/issues/19). As a workaround consider using `nuget pack` instead.

 ## Embedded symbols and .Net Framework

 .NET Framework 4.7.2 is required for proper support of portable/embedded symbols.

See [dotnet issues](https://github.com/microsoft/dotnet/blob/37165eac02f7fdbbc04efffdd32c378ca70c00fa/releases/net471/KnownIssues/517815-BCL%20Stack%20traces%20are%20missing%20source%20information%20for%20frames%20with%20debug%20information%20in%20the%20Portable%20PDB%20format.md) for details.