using System;

namespace ResourceEmbedder.Core
{
    /// <summary>
    /// Helpers for debug symbols.
    /// </summary>
    public static class DebugSymbolHelper
    {
        /// <summary>
        /// Convert from msbuild strings.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static DebugSymbolType FromString(string input)
        {
            if (Enum.TryParse(input, ignoreCase: true, out DebugSymbolType debugType))
            {
                return debugType;
            }
            throw new NotSupportedException($"DebugType '{input}' is not supported.");
        }
    }
}
