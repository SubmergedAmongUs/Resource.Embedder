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

 Thus these warnings can be safely ignored.