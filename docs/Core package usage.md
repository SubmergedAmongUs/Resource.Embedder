# Inject your own assemblies/files (using Resource.Embedder.Core)

Resource.Embedder itself uses the core package to do the actual embedding.

If you have a custom workflow that doesn't quite fit with resource embedder you are free to use the core package to embed your own files.

# Usage

By adding the NuGet package to an assembly it is possible to manually inject resources and code into other assemblies.

See [this code for injecting resources](https://github.com/MarcStan/Resource.Embedder/blob/master/src/ResourceEmbedder.Core.Tests/EmbedFilesTests.cs#L162) and [this code for injecting code](https://github.com/MarcStan/Resource.Embedder/blob/master/src/ResourceEmbedder.Core.Tests/InjectCodeTests.cs#L40).

# Example usecases 

## Allow drag & drop style embedding

When a user drags a file onto an exe the exe can embed the file into itself.

I have used this in the past to embed plugins with the exe.

That way I can build the components seperately and then ship different versions of the same exe to various customers, each preconfigured with certain plugins (without having to recompile or distribute multiple files).

## Include default plugins (that are always loaded) inside your dll

While you could directly reference the default plugin in the main project. 

## Embed any file dyamically during runtime

Based on user workflow it may be necessary to store settings/files. Usually this is done in a seperate file next to the exe (or in a seperate data dir).

By storing it in the exe, you would ensure that the settings always travel with the exe and that multiple exes with different settings could exist.