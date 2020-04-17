using System;

namespace SymbolHelper
{
    public static class Symbols
    {
        public static bool AreLoaded()
        {
            try
            {
                throw new Exception("Ensuring that debug symbols are embedded.");
            }
            catch (Exception ex)
            {
                // with symbols:    at Embedded.Program.Main(String[] args) in <path>\resource-embedder\src\testmodules\Symbols\FullFramework\Embedded\Program.cs:line
                // without symbols: at Embedded.Program.Main(String[] args)
                Console.WriteLine(ex.StackTrace);
                return ex.StackTrace.Contains(nameof(Symbols) + ".cs");
            }
        }
    }
}
