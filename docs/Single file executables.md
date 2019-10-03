# Single-file executables in .Net Core

With the release of .Net Core 3 and its support for [single-file executables](https://docs.microsoft.com/dotnet/core/whats-new/dotnet-core-3-0#single-file-executables) .Net now natively supports bundling of all files into a single executable (libraries, satellite assemblies and resources).

For now the .Net support is limited to platform-specific executables (see [SingleFileConsole](https://github.com/MarcStan/Resource.Embedder/tree/master/src/testmodules/SingleFileConsole) for an example) which means the executable defaults to ~60MB for a simple hello world project.

Using [assembly linking](https://docs.microsoft.com/dotnet/core/whats-new/dotnet-core-3-0#assembly-linking) it is possible to shrink such a hello world example to ~23MB at the cost of losing reflection capabilities (and having to manually specify needed assembly by [rooting them](https://github.com/mono/linker/blob/master/src/ILLink.Tasks/README.md#adding-reflection-roots)).

As per the [design document](https://github.com/dotnet/designs/blob/master/accepted/single-file/design.md) future versions of .Net may also support platform-dependent executables which should drastically reduce the executable size.
