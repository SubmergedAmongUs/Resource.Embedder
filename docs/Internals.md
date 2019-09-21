# Internals

The NuGet package uses MSBuild events to hook into the build pipeline and:

It embeds the satellite assemblies into themain  assembly as resources after the main compile step [as per Jeffrey Richters example](https://blogs.msdn.com/b/microsoft_press/archive/2010/02/03/jeffrey-richter-excerpt-2-from-clr-via-c-third-edition.aspx).

It then uses Cecil to add/edit the [module initializer](http://einaregilsson.com/module-initializers-in-csharp/) which will call the hooking code to load the satellite assemblies from resources.

The module initializer will run once the assembly is loaded. It will hook up the required events. [See the Injected code](https://github.com/MarcStan/Resource.Embedder/blob/master/src/ResourceEmbedder.Core/GeneratedCode/InjectedResourceLoader.cs).
